using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_2
{
    public class User
    {
        public string Username;
        private string password;
        public List<string> Messages = new List<string>();

        public User(string user, string pass)
        {
            Username = user;
            password = pass;
        }

        public string EncryptPassword(string str)
        {
            // Add # until length is divisible by 3
            while (str.Length % 3 != 0)
            {
                str += "#";
            }

            int partLength = str.Length / 3;
            string[] parts = new string[3];

            // Split into 3 parts using loops
            for (int i = 0; i < 3; i++)
            {
                parts[i] = "";
                for (int j = 0; j < partLength; j++)
                {
                    int index = i * partLength + j;
                    parts[i] += str[index];
                }
            }

            // Combine parts with password
            int middle = password.Length / 2;
            string firstPart = password.Substring(0, middle);
            string secondPart = password.Substring(middle);

            return parts[0] + firstPart + parts[1] + secondPart + parts[2];
        }

        public bool CheckPassword(string candidate)
        {
            return candidate == password;
        }

        public string GetPassword()
        {
            string stars = "";
            for (int i = 0; i < password.Length; i++)
            {
                stars += "*";
            }
            return stars;
        }

        public void ChangePassword(string newPassword)
        {
            password = newPassword;
        }
    }
}
