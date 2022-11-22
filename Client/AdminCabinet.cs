using System;
using System.Text;
using System.Windows.Forms;

namespace Client
{
    public partial class AdminCabinet : Form
    {
        private SocketETC socket;
        private byte[] command;
        private byte[] login;
        private byte[] password;
        private bool adminAccess;
        private string serverAnswer;

        public AdminCabinet(SocketETC socket, byte[] login, byte[] password, bool adminAccess)
        {
            InitializeComponent();

            this.login = login;
            this.password = password;
            this.socket = socket;
            this.adminAccess = adminAccess;

            StartPosition = FormStartPosition.CenterScreen;
        }

        private void AdminCabinet_Load(object sender, EventArgs e)
        {
            ControlBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;

            loginLabel.Text = Encoding.UTF8.GetString(login);

            socket.connect();
        }

        private void watchCamerasButton_Click_1(object sender, EventArgs e)
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

        private void checkSensorsButton_Click_1(object sender, EventArgs e)
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

        private void addGuardianButton_Click(object sender, EventArgs e)
        {
            command = Encoding.UTF8.GetBytes("adminAccess");

            serverAnswer = RepeatedMethods.checkLoginPassword(socket, login, password, command);

            switch (serverAnswer)
            {
                case "AdminSuccess":
                    AddGuardian add = new AddGuardian(socket, login, password, adminAccess);
                    add.Show();
                    Hide();
                    break;
                case "Error":
                    MessageBox.Show("You can`t add guardians", "No admin access", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                default:
                    MessageBox.Show(serverAnswer, "Server ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }
        }

        private void deleteGuardiansButton_Click(object sender, EventArgs e)
        {
            command = Encoding.UTF8.GetBytes("adminAccess");

            serverAnswer = RepeatedMethods.checkLoginPassword(socket, login, password, command);

            switch (serverAnswer)
            {
                case "AdminSuccess":
                    DeleteGuardians del = new DeleteGuardians(socket, login, password, adminAccess);
                    del.Show();
                    Hide();
                    break;
                case "Error":
                    MessageBox.Show("You can`t delete guardians", "No admin access", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                default:
                    MessageBox.Show(serverAnswer, "Server ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }
        }

        private void quitButton_Click_1(object sender, EventArgs e)
        {
            command = Encoding.UTF8.GetBytes("quit");
            socket.send(command);

            socket.disconnect();
            Application.Exit();
        }
    }
}
