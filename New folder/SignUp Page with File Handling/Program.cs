using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        string file = "users.txt";

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the User System");
            Console.WriteLine("1. Sign Up");
            Console.WriteLine("2. Sign In");
            Console.WriteLine("3. Exit");
            Console.Write("Choose an option (1/2/3): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    SignUp(file);
                    break;
                case "2":
                    SignIn(file);
                    break;
                case "3":
                    Console.WriteLine("Exiting... Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void SignUp(string file)
    {
        Console.Clear();
        Console.WriteLine("Sign Up Page");

        Console.Write("Enter a username: ");
        string username = Console.ReadLine();

        if (IsUsernameTaken(file, username))
        {
            Console.WriteLine("Username already exists. Please try a different one.");
            Console.ReadKey();
            return;
        }

        Console.Write("Enter a password: ");
        string password = Console.ReadLine();

        Console.Write("Confirm your password: ");
        string confirmPassword = Console.ReadLine();

        if (password != confirmPassword)
        {
            Console.WriteLine("Passwords do not match. Please try again.");
            Console.ReadKey();
            return;
        }
        SaveUser(file, username, password);
        Console.WriteLine("Signup successful! Press any key to return to the menu.");
        Console.ReadKey();
    }

    static void SignIn(string file)
    {
        Console.Clear();
        Console.WriteLine("Sign In Page");

        Console.Write("Enter your username: ");
        string username = Console.ReadLine();

        Console.Write("Enter your password: ");
        string password = Console.ReadLine();

        if (ValidateUser(file, username, password))
        {
            Console.WriteLine("Login successful! Welcome, " + username + ".");
        }
        else
        {
            Console.WriteLine("Invalid username or password. Please try again.");
        }

        Console.WriteLine("Press any key to return to the menu.");
        Console.ReadKey();
    }

    static bool IsUsernameTaken(string file, string username)
    {
        if (!File.Exists(file)) return false;

        using (StreamReader reader = new StreamReader(file))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] details = line.Split(',');
                if (details.Length == 2 && details[0] == username)
                {
                    return true;
                }
            }
        }

        return false;
    }

    static bool ValidateUser(string filePath, string username, string password)
    {
        if (!File.Exists(filePath)) return false;

        using (StreamReader reader = new StreamReader(filePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] details = line.Split(',');
                if (details.Length == 2 && details[0] == username && details[1] == password)
                {
                    return true;
                }
            }
        }

        return false;
    }

    static void SaveUser(string filePath, string username, string password)
    {
        using (StreamWriter writer = new StreamWriter(filePath, true))
        {
            writer.WriteLine(username + "," + password);
        }
    }
}
