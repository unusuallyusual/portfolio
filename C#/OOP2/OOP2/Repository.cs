using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2
{
    internal partial class Repository
    {
        public List<Client> ClientsDb { get; set; }
        public List<Department> DepartmentsDb { get; set; }
        private Repository(string path)
        {
            string[] files = Directory.GetFiles(path);
            ClientsDb = new List<Client>();
            DepartmentsDb = new List<Department>();

            int i = 0;
            foreach (string s in files)
            {
                DepartmentsDb.Add(new Department(Path.GetFileName(s), i++));
                int nubmbStr = File.ReadAllLines(s).Length;
                for (int j = 0; j < nubmbStr; j++)
                {
                    string line = File.ReadLines(s).Skip(j).Take(1).First();
                    string[] subs = line.Split('#');
                    ClientsDb.Add(new Client(subs[0], subs[1], subs[2], subs[3], subs[4], subs[5], subs[6]));
                }
            }
        }

        public static Repository CreateRepository(string path)
        {
            return new Repository(path);
        }
    }
}

