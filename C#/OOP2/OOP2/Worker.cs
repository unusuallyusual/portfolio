using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2
{
    internal abstract class Worker
    {
        public abstract List<Client> ShowData(List<Client> clients);

        public abstract List<Client> DeleteData(List<Client> clients, int num);
    }
}
