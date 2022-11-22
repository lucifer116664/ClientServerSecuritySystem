using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Client
{
    public partial class WatchCameras : Form
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

        public WatchCameras(SocketETC socket, byte[] login, byte[] password, bool adminAccess)
        {
            InitializeComponent();

            this.login = login;
            this.password = password;
            this.adminAccess = adminAccess;
            this.socket = socket;

            StartPosition = FormStartPosition.CenterScreen;
            this.adminAccess = adminAccess;
        }

        private void WatchCameras_Load(object sender, EventArgs e)
        {
            ControlBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;

            loginLabel.Text = Encoding.UTF8.GetString(login);

            socket.connect();
        }

        private void cameraChooseComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void timeChooseComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        private void watchCamerasButton_Click(object sender, EventArgs e)
        {
            byte[] choosedCamera = Encoding.UTF8.GetBytes(cameraChooseComboBox.SelectedIndex.ToString());

            command = Encoding.UTF8.GetBytes("watchVideo");
            serverAnswer = RepeatedMethods.checkLoginPassword(socket, login, password, command);

            if (serverAnswer != "Success")
            {
                MessageBox.Show("Wrong login or password", "Accaunt not exists", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                socket.send(choosedCamera);
                
                do
                {
                    size = socket.receive(buffer);
                    answer.Append(Encoding.UTF8.GetString(buffer, 0, size));
                }
                while (socket.availableBiggerThanZero());

                string url = answer.ToString();
                
                answer.Clear();

                System.Diagnostics.Process.Start(url);
            }
        }
    }
}
