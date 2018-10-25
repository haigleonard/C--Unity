using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;
/*If the requirement changed such that a much larger number of users or screens needed to be stored what changes if any would you make to the program? 
 *      As the system below uses a list structure, there is no limit on how many users can be stored, as well as the number of screens a user has access to.
 * */
namespace ConsoleApp1
{
    
    class Program
    {
        
        static List<ConsoleApplication1.User> users = new List<ConsoleApplication1.User>();
        static string filepath = System.IO.Path.GetFullPath(Directory.GetCurrentDirectory() + @"\file.txt");
        static int screen;
        static string username;

        static void Main(string[] args)
        {
            Console.WriteLine("File has been read:" + init_access(filepath));
            while (true)
            {
                Console.WriteLine("Enter UserName");
                username = Console.ReadLine();
                Console.WriteLine("Enter Access Number");
                screen = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(username + " access to {0} is: {1}",  screen, has_access(username, screen));
            }
        }
        static bool init_access(string file_path)
        {
            string[] fileLines;
            /*Try catch for file not being present*/
            try
            {
                fileLines = System.IO.File.ReadAllLines(@file_path);
            }
            catch
            {
                Console.WriteLine("File not Found");
                return false;
            }

            foreach (string line in fileLines)
            {
                string[] words = line.Split(' ');
                if (words[0].Length > 5 || words[0].Any(char.IsDigit))
                {
                    return false;
                }
                /*If the Admin user wishes to comment out a entry, a '/' can be put in front of the name*/
                if (words[0][0]!='/') {
                    ConsoleApplication1.User u = new ConsoleApplication1.User(words[0]);
                    foreach (string word in words.Skip(1))
                    {
                        /*Try catch for if one of the access screens is not an int*/
                        try
                        {
                            /*Checks the access number is between 0 and 9*/
                            if (Int32.Parse(word) > 9 || Int32.Parse(word) < 1)
                            {
                                return false;
                            }
                            u.addAccess(Int32.Parse(word));
                        }
                        catch
                        {
                            return false;
                        }

                    }
                    users.Add(u);
                }
            }

            return true;
        }
        static bool has_access(string user_name, int screen)
        {
            
            foreach (var u in users)
                /*Iterates through List, if username is present, and contains screen number, return true, else return false as either username, or user does not have access to that screen*/
                if (u.getUser.Equals(user_name))
                {
                    if (u.access.Contains(screen))
                    {
                        return true;
                    }
                }
            return false;
        }
    }
}
