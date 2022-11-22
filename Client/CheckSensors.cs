using System;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace Client
{
    public partial class CheckSensors : Form
    {
        private SocketETC socket;
        private byte[] command = Encoding.UTF8.GetBytes("getSensors");
        private byte[] login;
        private byte[] password;
        private bool adminAccess;

        public CheckSensors(SocketETC socket, byte[] login, byte[] password, bool adminAccess)
        {
            InitializeComponent();

            this.login = login;
            this.password = password;
            this.adminAccess = adminAccess;
            this.socket = socket;

            StartPosition = FormStartPosition.CenterScreen;
            this.adminAccess = adminAccess;
        }

        private void WatchSensors_Load(object sender, EventArgs e)
        {
            ControlBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;

            loginLabel.Text = Encoding.UTF8.GetString(login);

            socket.connect();

            string serverAnswer = RepeatedMethods.checkLoginPassword(socket, login, password, command);

            if(serverAnswer != "Success")
            {
                MessageBox.Show("Wrong login or password", "Accaunt not exists", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                byte[] buffer = new byte[256];
                var size = 0;
                var answer = new StringBuilder();

                do
                {
                    size = socket.receive(buffer);
                    answer.Append(Encoding.UTF8.GetString(buffer, 0, size));
                }
                while (socket.availableBiggerThanZero());

                textBox.Text = answer.ToString();

                refreshSensors(sender, e);
            }
        }

        private async void refreshSensors(object sender, EventArgs e)
        {
            await Task.Delay(5000);
            WatchSensors_Load(sender, e);
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            command = Encoding.UTF8.GetBytes("quit");
            socket.send(command);

            socket.disconnect();
            Application.Exit();
        }

        private void backButton_Click_1(object sender, EventArgs e)
        {
            if(adminAccess)
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
    }
}
