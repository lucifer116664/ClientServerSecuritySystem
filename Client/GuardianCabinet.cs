using System;
using System.Text;
using System.Windows.Forms;

namespace Client
{
    public partial class GuardianCabinet : Form
    {
        private SocketETC socket;
        private byte[] command;
        private byte[] login;
        private byte[] password;
        private string serverAnswer;
        private bool adminAccess;

        public GuardianCabinet(SocketETC socket, byte[] login, byte[] password, bool adminAccess)
        {
            InitializeComponent();

            this.login = login;
            this.password = password;
            this.adminAccess = adminAccess;
            this.socket = socket;

            StartPosition = FormStartPosition.CenterScreen;  
        }

        private void GuardianCabinet_Load(object sender, EventArgs e)
        {
            ControlBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;

            loginLabel.Text = Encoding.UTF8.GetString(login);

            socket.connect();
        }

        private void watchCamerasButton_Click(object sender, EventArgs e)
        {
            command = Encoding.UTF8.GetBytes("guardAccess");

            serverAnswer = RepeatedMethods.checkLoginPassword(socket, login, password, command);

            switch (serverAnswer)
            {
                case "Success":
                    WatchCameras watch = new WatchCameras(socket, login, password, adminAccess);
                    watch.Show();
                    Hide();
                    break;
                case "Error":
                    MessageBox.Show("You can`t watch cameras", "Accaunt not exists", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                default:
                    MessageBox.Show(serverAnswer, "Server ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }
        }

        private void checkSensorsButton_Click(object sender, EventArgs e)
        {
            command = Encoding.UTF8.GetBytes("guardAccess");

            serverAnswer = RepeatedMethods.checkLoginPassword(socket, login, password, command);

            switch (serverAnswer)
            {
                case "Success":
                    CheckSensors check = new CheckSensors(socket, login, password, adminAccess);
                    check.Show();
                    Hide();
                    break;
                case "Error":
                    MessageBox.Show("You can`t check sensors", "Accaunt not exists", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                default:
                    MessageBox.Show(serverAnswer, "Server ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }
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
