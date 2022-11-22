using System;
using System.Security.Cryptography;
using System.Text;

namespace Client
{
    public class RepeatedMethods //Here lie often repeated in other classes methods
    {
        public static string checkLoginPassword(SocketETC socket, byte[] login, byte[] password, byte[] command)
        {
            byte[] buffer = new byte[256];
            var size = 0;
            var answer = new StringBuilder();

            socket.send(command);

            do
            {
                size = socket.receive(buffer);
                answer.Append(Encoding.UTF8.GetString(buffer, 0, size));
            }
            while (socket.availableBiggerThanZero());

            if (answer.ToString() != "GotData")
            {
                return "Server didn`t got the command";
            }
            else
            {
                answer.Clear();
                socket.send(login);

                do
                {
                    size = socket.receive(buffer);
                    answer.Append(Encoding.UTF8.GetString(buffer, 0, size));
                }
                while (socket.availableBiggerThanZero());

                if (answer.ToString() != "GotData")
                {
                    return "Server didn`t got the login";
                }
                else
                {
                    answer.Clear();
                    socket.send(password);

                    do
                    {
                        size = socket.receive(buffer);
                        answer.Append(Encoding.UTF8.GetString(buffer, 0, size));
                    }
                    while (socket.availableBiggerThanZero());

                    if (answer.ToString() != "GotData")
                    {
                        return "Server didn`t got the password";
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

                        return answer.ToString();
                    }
                }
            }
        }

        public static string passwordHashing(string password)
        {
            byte[] data = Encoding.Default.GetBytes(password);
            SHA1 sha = new SHA1CryptoServiceProvider();
            byte[] result = sha.ComputeHash(data);
            password = Convert.ToBase64String(result);
            return password;
        }
    }
}
