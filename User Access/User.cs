using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace ConsoleApplication1
{
    public class User
    {
        private String userName;
        public ArrayList access = new ArrayList();
        public User(string s)
        {
            this.userName = s;
        }
        public string getUser
        {
            get { return userName; }
        }
        public void addAccess(int i)
        {
            access.Add(i);
        }
        public void print()
        {
            Console.WriteLine(this.getUser);
            foreach (var a in access)
                Console.WriteLine("\t" + a);
        }
    }
}
