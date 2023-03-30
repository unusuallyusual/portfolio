using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2
{
  public class Department
  {
    public string DepartmentName { get; set; }
    public int DepartmentId { get; set; }

    public Department(string Name, int Id)
    {
      DepartmentName = Name;
      DepartmentId = Id;
    }
  }
}
