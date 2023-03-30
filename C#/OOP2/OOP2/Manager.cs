using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP2
{
    internal class Manager : Worker
    {
        public override List<Client> ShowData(List<Client> clients)
        {
            return clients;
        }

        public override List<Client> DeleteData(List<Client> clients, int num)
        {
            List<Client> ClientsDb = new List<Client>(clients.Count - 1);
            if (num <= clients.Count && num > 0)
            {
                for (int i = 0; i < clients.Count; i++)
                {
                    if (i != num - 1)
                        ClientsDb.Add(clients[i]);
                }
            }
            else
                System.Windows.MessageBox.Show("Нет такой строки данных!");
            return ClientsDb;
        }
    }
}
