using System;
using System.Windows.Forms;
using System.Text;

namespace Client
{
    public partial class Authorisation : Form
    {
        private SocketETC socket = new SocketETC();
        private byte[] command = Encoding.UTF8.GetBytes("authorisation");

        public Authorisation()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void Authorisation_Load(object sender, EventArgs e)
        {
            ControlBox = false;
            FormBorderStyle= FormBorderStyle.FixedSingle;

            passwordTextBox.PasswordChar = '•';
            showPicture.Visible = true;
            hidePicture.Visible = false;
            loginTextBox.MaxLength = 50;
            passwordTextBox.MaxLength = 50;
        }

        private void showPicture_Click(object sender, EventArgs e)
        {
            passwordTextBox.UseSystemPasswordChar = true;
            showPicture.Visible = false;
            hidePicture.Visible = true;
        }

        private void hidePicture_Click(object sender, EventArgs e)
        {
            passwordTextBox.UseSystemPasswordChar = false;
            showPicture.Visible = true;
            hidePicture.Visible = false;
        }

        private void logInButton_Click(object sender, EventArgs e)
        {
            socket.connect();

            var login = Encoding.UTF8.GetBytes(loginTextBox.Text);
            var password = Encoding.UTF8.GetBytes(RepeatedMethods.passwordHashing(passwordTextBox.Text));

            string serverAnswer = RepeatedMethods.checkLoginPassword(socket, login, password, command);

            switch (serverAnswer)
            {
                case "Success":
                    GuardianCabinet guardCab = new GuardianCabinet(socket, login, password, false);
                    guardCab.Show();
                    Hide();
                    break;

                case "AdminSuccess":
                    AdminCabinet adminCab = new AdminCabinet(socket, login, password, true);
                    adminCab.Show();
                    Hide();
                    break;

                case "Error":
                    MessageBox.Show("Wrong login or password", "Accaunt not exists", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //socket.disconnect();
                    break;

                default:
                    MessageBox.Show(serverAnswer, "Server ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //socket.disconnect();
                    break;
            }
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
