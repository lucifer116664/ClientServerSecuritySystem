using System;
using System.Text;
using System.Windows.Forms;

namespace Client
{
    public partial class AddGuardian : Form
    {
        private SocketETC socket;
        private byte[] login;
        private byte[] password;
        private byte[] command = Encoding.UTF8.GetBytes("addGuardian");
        private bool adminAccess;

        public AddGuardian(SocketETC socket, byte[] login, byte[] password, bool adminAccess)
        {
            InitializeComponent();

            this.socket = socket;
            this.login = login;
            this.password = password;
            this.adminAccess = adminAccess;

            StartPosition = FormStartPosition.CenterScreen;
            
        }

        private void AddGuardian_Load(object sender, EventArgs e)
        {
            ControlBox = false;

            loginLabel.Text = Encoding.UTF8.GetString(login);

            socket.connect();

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

        private void addGuardianButton_Click(object sender, EventArgs e)
        {
            if(loginTextBox.Text.Length < 1 || loginTextBox.Text.Length > 50)
            {
                MessageBox.Show("Login must be at least 1 symbol and less then 50 symbols long", "Wrong login format", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (passwordTextBox.Text.Length < 4 || loginTextBox.Text.Length > 50)
                {
                    MessageBox.Show("Password must be at least 4 symbols and less then 50 symbols long", "Wrong password format", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    var guardsAdminAccess = Encoding.UTF8.GetBytes(hasAdminAccess());
                    var guardsLogin = Encoding.UTF8.GetBytes(loginTextBox.Text);
                    var guardsPassword = Encoding.UTF8.GetBytes(RepeatedMethods.passwordHashing(passwordTextBox.Text));

                    string serverAnswer = RepeatedMethods.checkLoginPassword(socket, login, password, command);

                    switch (serverAnswer)
                    {
                        case "AdminSuccess":
                            byte[] buffer = new byte[256];
                            int size;
                            var answer = new StringBuilder();

                            socket.send(guardsLogin);

                            do
                            {
                                size = socket.receive(buffer);
                                answer.Append(Encoding.UTF8.GetString(buffer, 0, size));
                            }
                            while (socket.availableBiggerThanZero());

                            if (answer.ToString() != "GotData")
                            {
                                MessageBox.Show("Server didn`t got the login", "Server ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                            {
                                answer.Clear();
                                socket.send(guardsPassword);

                                do
                                {
                                    size = socket.receive(buffer);
                                    answer.Append(Encoding.UTF8.GetString(buffer, 0, size));
                                }
                                while (socket.availableBiggerThanZero());

                                if (answer.ToString() != "GotData")
                                {
                                    MessageBox.Show("Server didn`t got the login", "Server ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                                else
                                {
                                    answer.Clear();
                                    socket.send(guardsAdminAccess);

                                    do
                                    {
                                        size = socket.receive(buffer);
                                        answer.Append(Encoding.UTF8.GetString(buffer, 0, size));
                                    }
                                    while (socket.availableBiggerThanZero());

                                    if (answer.ToString() != "GotData")
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

                                        serverAnswer = answer.ToString();
                                    }
                                }
                            }
                            if (serverAnswer.Equals("Success"))
                            {
                                MessageBox.Show("Guardian was successfully added", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                loginTextBox.Text = "";
                                passwordTextBox.Text = "";
                                adminAccessCheckBox.Checked = false;
                            }
                            else if (serverAnswer.Equals("Error"))
                                MessageBox.Show("User with this login is already registered", "Login already exists", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            else
                                MessageBox.Show("Something has gone wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;

                        case "Error":
                            MessageBox.Show("You can not add a guardian", "No admin access", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            //socket.disconnect();
                            break;

                        default:
                            MessageBox.Show(serverAnswer, "Server ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            //socket.disconnect();
                            break;
                    }
                }
            }
        }

        public string hasAdminAccess()
        {
            if (adminAccessCheckBox.Checked)
            {
                return "1";
            }
            else
            {
                return "0";
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
