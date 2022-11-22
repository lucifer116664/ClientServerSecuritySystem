using System;
using System.Text;
using System.Windows.Forms;

namespace Client
{
    public partial class DeleteGuardians : Form
    {
        private SocketETC socket;
        private byte[] login;
        private byte[] password;
        private byte[] command;
        private string serverAnswer;
        private bool adminAccess;

        private byte[] buffer = new byte[256];
        private int size;
        private StringBuilder answer = new StringBuilder();
        private byte[] guardsLogin;

        public DeleteGuardians(SocketETC socket, byte[] login, byte[] password, bool adminAccess)
        {
            InitializeComponent();

            this.socket = socket;
            this.login = login;
            this.password = password;
            this.adminAccess = adminAccess;

            StartPosition = FormStartPosition.CenterScreen;
        }

        private void DeleteGuardians_Load(object sender, EventArgs e)
        {
            ControlBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;

            loginLabel.Text = Encoding.UTF8.GetString(login);

            socket.connect();

            command = Encoding.UTF8.GetBytes("showGuardians");
            serverAnswer = RepeatedMethods.checkLoginPassword(socket, login, password, command);

            if (serverAnswer != "AdminSuccess")
            {
                MessageBox.Show("Wrong login or password", "Accaunt not exists", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                do
                {
                    size = socket.receive(buffer);
                    answer.Append(Encoding.UTF8.GetString(buffer, 0, size));
                }
                while (socket.availableBiggerThanZero());
                
                string[] guardsArray = new string[1];
                char[] guardsBuffer = answer.ToString().ToCharArray();
                int guardsArrayCounter = 0;

                answer.Clear();
                //put the login values into guardsArray
                for(int guardsBufferCounter = 0; guardsBufferCounter < guardsBuffer.Length; guardsBufferCounter++)
                {
                    if (guardsBuffer[guardsBufferCounter].Equals(','))
                    {
                        Array.Resize(ref guardsArray, guardsArray.Length + 1);
                        guardsArrayCounter++;
                    }
                    else if(guardsBuffer[guardsBufferCounter].Equals('\r') || guardsBuffer[guardsBufferCounter].Equals('\n'))
                    {
                        continue;
                    }
                    else
                    {
                        guardsArray[guardsArrayCounter] += guardsBuffer[guardsBufferCounter];
                    }
                }

                guardiansCheckedListBox.Items.Clear();

                for (int i = 0; i < guardsArray.Length-1; i++)
                {
                    guardiansCheckedListBox.Items.Insert(i, guardsArray[i]);
                }
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            command = Encoding.UTF8.GetBytes("deleteGuardians");
            serverAnswer = RepeatedMethods.checkLoginPassword(socket, login, password, command);
            if (serverAnswer != "AdminSuccess")
            {
                MessageBox.Show("Wrong login or password", "Accaunt not exists", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                foreach (string item in guardiansCheckedListBox.CheckedItems)
                {
                    //item = item
                    guardsLogin = Encoding.UTF8.GetBytes(item.Replace(" ", ""));
                    socket.send(guardsLogin);

                    do
                    {
                        size = socket.receive(buffer);
                        answer.Append(Encoding.UTF8.GetString(buffer, 0, size));
                    }
                    while (socket.availableBiggerThanZero());

                    if (!answer.ToString().Equals("GotData"))//
                    {
                        MessageBox.Show("Server didn`t got the login", "Server ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        answer.Clear();

                        do
                        {
                            size = socket.receive(buffer);
                            answer.Append(Encoding.UTF8.GetString(buffer, 0, size));
                        }
                        while (socket.availableBiggerThanZero());

                        if (answer.ToString() != "Success")
                        {
                            MessageBox.Show("Server can not delete this users", "Server ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            answer.Clear();
                        }
                        else
                        {
                            answer.Clear();
                        }
                    }
                }
                socket.send(Encoding.UTF8.GetBytes("thatWasLastOne"));

                do
                {
                    size = socket.receive(buffer);
                    answer.Append(Encoding.UTF8.GetString(buffer, 0, size));
                }
                while (socket.availableBiggerThanZero());

                if (answer.ToString() != "GotData")
                {
                    MessageBox.Show("Server didn`t got the command to stop", "Server ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                answer.Clear();
                DeleteGuardians_Load(sender, e);
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            if (adminAccess)
            {
                AdminCabinet cabinet = new AdminCabinet(socket, login, password, adminAccess);
                cabinet.Show();
            }
            else
            {
                GuardianCabinet cabinet = new GuardianCabinet(socket, login, password, adminAccess);
                cabinet.Show();
            }
            Hide();
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            command = Encoding.UTF8.GetBytes("quit");
            socket.send(command);

            socket.disconnect();
            Application.Exit();
        }

    }
}
