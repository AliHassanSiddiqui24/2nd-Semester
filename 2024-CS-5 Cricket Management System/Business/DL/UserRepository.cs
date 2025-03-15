using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.BL;
using System.IO;
using Business.DL;
using System.Data;

public class UserRepository
{
    public List<User> LoadUsers()
    {
        List<User> users = new List<User>();
        DataTable dt = SqlHelper.GetTable("SELECT * FROM Users");

        foreach (DataRow row in dt.Rows)
        {
            users.Add(new User(
                row["Username"].ToString(),
                row["Password"].ToString(),
                row["Role"].ToString()
            ));
        }
        return users;
    }

    public void SaveUsers(List<User> users)
    {
        SqlHelper.ExecuteDML("DELETE FROM Users");

        foreach (User u in users)
        {
            string query = $@"INSERT INTO Users VALUES(
                '{u.Username}', '{u.Password}', '{u.Role}')";

            SqlHelper.ExecuteDML(query);
        }
    }
}
