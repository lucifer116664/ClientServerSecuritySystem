using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading;

namespace Server
{
    public class Server
    {
        const string IP = "127.0.0.1";
        const int PORT = 8080;
       
        static void Main(string[] args)
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Socket listener;
            IPEndPoint tcpEndPoint = new IPEndPoint(IPAddress.Parse(IP), PORT);

            Console.WriteLine("Server is online");

                socket.Bind(tcpEndPoint);
                socket.Listen(5);

                while (true)
                {
                    listener = socket.Accept();
                    Thread thread = new Thread(() => { inEveryThread(listener); });
                    thread.Start();
                }
        }
   
        public static void inEveryThread(Socket listener)
        {
            string login = "";
            string password;
            string whatToDo;
            string sqlQuery;

            byte[] buffer = new byte[256];

            int size;

            SqlCommand cmd;
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            StringBuilder data = new StringBuilder();

            while (true)
            {
                SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);
                sqlConnection.Open();

                if (sqlConnection.State != ConnectionState.Open)
                {
                    Console.WriteLine("DataBase connection ERROR!!!");
                }
                else
                {
                    do
                    {
                        size = listener.Receive(buffer);
                        data.Append(Encoding.UTF8.GetString(buffer, 0, size));
                    }
                    while (listener.Available > 0);

                    whatToDo = data.ToString();
                    data.Clear();


                    if (!whatToDo.Equals("quit"))
                    {
                        listener.Send(Encoding.UTF8.GetBytes("GotData"));

                        do
                        {
                            size = listener.Receive(buffer);
                            data.Append(Encoding.UTF8.GetString(buffer, 0, size));
                        }
                        while (listener.Available > 0);

                        login = data.ToString();
                        data.Clear();

                        listener.Send(Encoding.UTF8.GetBytes("GotData"));

                        do
                        {
                            size = listener.Receive(buffer);
                            data.Append(Encoding.UTF8.GetString(buffer, 0, size));
                        }
                        while (listener.Available > 0);

                        password = data.ToString();
                        data.Clear();

                        listener.Send(Encoding.UTF8.GetBytes("GotData"));

                        sqlQuery = $"SELECT * FROM Guardians WHERE Login = @Login AND Password = @Password";

                        cmd = new SqlCommand(sqlQuery, sqlConnection);

                        cmd.Parameters.Add("@Login", SqlDbType.VarChar, 50).Value = login;
                        cmd.Parameters.Add("@Password", SqlDbType.VarChar, 50).Value = password;

                        adapter.SelectCommand = cmd;
                        table.Clear();
                        adapter.Fill(table);

                        if (table.Rows.Count != 1)
                        {
                            Console.WriteLine("Unregistered user tries to get access.");
                            listener.Send(Encoding.UTF8.GetBytes("Error"));
                        }
                        else
                        {
                            switch (whatToDo)
                            {
                                case "authorisation":
                                    authorisation(listener, login, password);
                                    break;

                                case "guardAccess":
                                    listener.Send(Encoding.UTF8.GetBytes("Success"));
                                    break;

                                case "adminAccess":
                                    adminAccess(listener, login, password);
                                    break;

                                case "getSensors":
                                    getSensors(listener);
                                    break;

                                case "addGuardian":
                                    addGuardian(listener, login, password);
                                    break;

                                case "showGuardians":
                                    showGuardians(listener, login, password);
                                    break;

                                case "deleteGuardians":
                                    deleteGuardians(listener, login, password);
                                    break;

                                case "watchVideo":
                                    watchVideo(listener);
                                    break;
                            }
                        }
                    }
                    else //quit
                    {
                        listener.Shutdown(SocketShutdown.Both);
                        listener.Close();
                        Console.WriteLine($"{login} has disconnected.");
                        break;
                    }
                }
                sqlConnection.Close();
            }
        }
        public static void authorisation(Socket listener, string login, string password)
        {
            if (checkIfAdmin(login, password).Equals("AdminSuccess"))
            {
                Console.WriteLine($"{login} was successfully connected as admin.");
                listener.Send(Encoding.UTF8.GetBytes("AdminSuccess"));
            }
            else
            {
                Console.WriteLine($"{login} was successfully connected as common guardian.");
                listener.Send(Encoding.UTF8.GetBytes("Success"));
            }
        }

        public static void adminAccess(Socket listener, string login, string password)
        {
            if (checkIfAdmin(login, password).Equals("AdminSuccess"))
            {
                listener.Send(Encoding.UTF8.GetBytes("AdminSuccess"));
            }
            else
            {
                Console.WriteLine($"{login} tries to get admin access.");
                listener.Send(Encoding.UTF8.GetBytes("Error"));
            }
        }

        public static void getSensors(Socket listener)
        {
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);
            sqlConnection.Open();

            if (sqlConnection.State != ConnectionState.Open)
            {
                Console.WriteLine("DataBase connection ERROR!!!");
            }
            else
            {

                listener.Send(Encoding.UTF8.GetBytes("Success"));

                DataTable dataTable = new DataTable();

                string sqlQuery = $"SELECT * FROM Sensors";

                SqlCommand cmd = new SqlCommand(sqlQuery, sqlConnection);

                dataTable.Load(cmd.ExecuteReader());

                string sensors = dataTableToByteArray(dataTable).ToString();
                listener.Send(Encoding.UTF8.GetBytes(sensors));
            }
            sqlConnection.Close();
        }

        public static void addGuardian(Socket listener, string login, string password)
        {
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);
            sqlConnection.Open();

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            StringBuilder data = new StringBuilder();

            byte[] buffer = new byte[256];

            if (sqlConnection.State != ConnectionState.Open)
            {
                Console.WriteLine("DataBase connection ERROR!!!");
            }
            else
            {
                int size;

                string newLogin;
                string newPassword;
                string newAdminAccess;

                if (checkIfAdmin(login, password).Equals("AdminSuccess"))
                {
                    listener.Send(Encoding.UTF8.GetBytes("AdminSuccess"));

                    do
                    {
                        size = listener.Receive(buffer);
                        data.Append(Encoding.UTF8.GetString(buffer, 0, size));
                    }
                    while (listener.Available > 0);

                    newLogin = data.ToString();
                    data.Clear();

                    listener.Send(Encoding.UTF8.GetBytes("GotData"));

                    do
                    {
                        size = listener.Receive(buffer);
                        data.Append(Encoding.UTF8.GetString(buffer, 0, size));
                    }
                    while (listener.Available > 0);

                    newPassword = data.ToString();
                    data.Clear();

                    listener.Send(Encoding.UTF8.GetBytes("GotData"));

                    do
                    {
                        size = listener.Receive(buffer);
                        data.Append(Encoding.UTF8.GetString(buffer, 0, size));
                    }
                    while (listener.Available > 0);

                    newAdminAccess = data.ToString();
                    data.Clear();

                    listener.Send(Encoding.UTF8.GetBytes("GotData"));

                    string sqlQuery = $"SELECT * FROM Guardians WHERE Login = @Login";

                    SqlCommand cmd = new SqlCommand(sqlQuery, sqlConnection);

                    cmd.Parameters.Add("@Login", SqlDbType.VarChar, 50).Value = newLogin;

                    adapter.SelectCommand = cmd;
                    table.Clear();
                    adapter.Fill(table);

                    if (table.Rows.Count >= 1)  //if login already exists
                    {
                        listener.Send(Encoding.UTF8.GetBytes("Error"));
                    }
                    else
                    {
                        sqlQuery = "INSERT INTO [dbo].[Guardians] ([Login], [Password], [AdminAccess]) VALUES (@Login, @Password, @Admin)";

                        cmd = new SqlCommand(sqlQuery, sqlConnection);

                        cmd.Parameters.Add("@Login", SqlDbType.VarChar, 50).Value = newLogin;
                        cmd.Parameters.Add("@Password", SqlDbType.VarChar, 50).Value = newPassword;
                        cmd.Parameters.Add("@Admin", SqlDbType.VarChar, 1).Value = newAdminAccess;

                        if (cmd.ExecuteNonQuery() == 1)
                        {
                            listener.Send(Encoding.UTF8.GetBytes("Success"));
                        }
                        else
                        {
                            listener.Send(Encoding.UTF8.GetBytes("Shit"));
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"{login} tries to get admin access.");
                    listener.Send(Encoding.UTF8.GetBytes("Error"));
                }
            }
            sqlConnection.Close();
        }

        public static void showGuardians(Socket listener, string login, string password)
        {
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);
            sqlConnection.Open();

            if (sqlConnection.State != ConnectionState.Open)
            {
                Console.WriteLine("DataBase connection ERROR!!!");
            }
            else
            {
                if (checkIfAdmin(login, password).Equals("AdminSuccess"))
                {
                    listener.Send(Encoding.UTF8.GetBytes("AdminSuccess"));

                    DataTable guardiansTable = new DataTable();

                    string sqlQuery = $"SELECT Login FROM Guardians";

                    using (sqlConnection)
                    using (SqlCommand cmd = new SqlCommand(sqlQuery, sqlConnection))
                    {
                        guardiansTable.Load(cmd.ExecuteReader());
                    }

                    string guardians = dataTableToByteArray(guardiansTable).ToString();
                    listener.Send(Encoding.UTF8.GetBytes(guardians));
                }
                else
                {
                    Console.WriteLine($"{login} tries to get admin access.");
                    listener.Send(Encoding.UTF8.GetBytes("Error"));
                }
            }
            sqlConnection.Close();
        }

        public static void deleteGuardians(Socket listener, string login, string password)
        {
            if (checkIfAdmin(login, password).Equals("AdminSuccess"))
            {
                listener.Send(Encoding.UTF8.GetBytes("AdminSuccess"));

                StringBuilder data = new StringBuilder();

                byte[] buffer = new byte[256];
                string guardsLogin = "";

                while (guardsLogin != "thatWasLastOne")
                {
                    SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);
                    sqlConnection.Open();

                    if (sqlConnection.State != ConnectionState.Open)
                    {
                        Console.WriteLine("DataBase connection ERROR!!!");
                    }
                    else
                    {
                        do
                        {
                            int size = listener.Receive(buffer);
                            data.Append(Encoding.UTF8.GetString(buffer, 0, size));
                        }
                        while (listener.Available > 0);

                        guardsLogin = data.ToString();
                        data.Clear();

                        listener.Send(Encoding.UTF8.GetBytes("GotData"));
                        if (guardsLogin != "thatWasLastOne")
                        {
                            string sqlQuery = "DELETE FROM Guardians WHERE Login = @Login";

                            SqlCommand cmd = new SqlCommand(sqlQuery, sqlConnection);

                            cmd.Parameters.Add("@Login", SqlDbType.VarChar, 50).Value = guardsLogin;

                            if (cmd.ExecuteNonQuery() == 1)
                            {
                                listener.Send(Encoding.UTF8.GetBytes("Success"));
                            }
                            else
                            {
                                listener.Send(Encoding.UTF8.GetBytes("Shit"));
                            }
                        }
                    }
                    sqlConnection.Close();
                }
            }
            else
            {
                Console.WriteLine($"{login} tries to get admin access.");
                listener.Send(Encoding.UTF8.GetBytes("Error"));
            }
        }

        public static void watchVideo(Socket listener)
        {
            StringBuilder data = new StringBuilder();

            byte[] buffer = new byte[256];

            listener.Send(Encoding.UTF8.GetBytes("Success"));

            string[] url = {"https://drive.google.com/drive/u/0/folders/1ZTXE3kVlQv__GZHUEslmeYF5NzxujLGL",
                            "https://drive.google.com/drive/u/0/folders/1V0ZQwmpDWaPnDNEF1thvQ5RXlg0T3ayK",
                            "https://drive.google.com/drive/u/0/folders/1r0UL26UWKVRlJ6bxErnZrXOj7UKq6D-o",
                            "https://drive.google.com/drive/u/0/folders/1nVx4BLWIBYwloBKA6h3wR3j7klLGRKfY",
                            "https://drive.google.com/drive/u/0/folders/1pUnmXIa5wN7IXTriv3IbVboZDNnXgBLF"};

            do
            {
                int size = listener.Receive(buffer);
                data.Append(Encoding.UTF8.GetString(buffer, 0, size));
            }
            while (listener.Available > 0);

            int cameraID = int.Parse(data.ToString());
            data.Clear();

            listener.Send(Encoding.UTF8.GetBytes(url[cameraID]));
        }

        public static string checkIfAdmin(string login, string password)
        {
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);
            sqlConnection.Open();

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            if (sqlConnection.State != ConnectionState.Open)
            {
                Console.WriteLine("DataBase connection ERROR!!!");
                return "Error";
            }
            else
            {
                string sqlQuery = $"SELECT * FROM Guardians WHERE Login = @Login AND Password = @Password AND AdminAccess = {1}";

                SqlCommand cmd = new SqlCommand(sqlQuery, sqlConnection);

                cmd.Parameters.Add("@Login", SqlDbType.VarChar, 50).Value = login;
                cmd.Parameters.Add("@Password", SqlDbType.VarChar, 50).Value = password;

                adapter.SelectCommand = cmd;
                table.Clear();
                adapter.Fill(table);

                if (table.Rows.Count != 1)
                {
                    sqlConnection.Close();
                    return "Error";
                }
                else
                {
                    sqlConnection.Close();
                    return "AdminSuccess";
                }
            }
            
        }

        private static string dataTableToByteArray(DataTable dt)
        {
            StringBuilder builder = new StringBuilder();

            foreach (DataRow row in dt.Rows)
            {
                for (int i = 0; i < row.ItemArray.Length; i++)
                {
                    string rowText = row.ItemArray[i].ToString();
                    if (rowText.Contains(","))
                    {
                        rowText = rowText.Replace(",", "/");
                    }

                    builder.Append(rowText + ",  ");
                }
                builder.Append(Environment.NewLine);
            }
            return builder.ToString();
        }
    }
}