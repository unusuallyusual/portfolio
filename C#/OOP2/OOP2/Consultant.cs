using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2
{
    /// <summary>
    /// Консультант
    /// </summary>
    internal class Consultant : Worker
    {
        public override List<Client> ShowData(List<Client> clients)
        {
            List<Client> ClientsDb = clients;
            // Серия и номер паспорта. Данные не доступны для просмотра.
            for (int i = 0; i < clients.Count; i++)
            {
                ClientsDb[i].Passport = new string('*', clients[i].Passport.Length);
            }
            return ClientsDb;
        }

        public override List<Client> DeleteData(List<Client> clients, int num)
        {
            return clients;
        }
    }
}
