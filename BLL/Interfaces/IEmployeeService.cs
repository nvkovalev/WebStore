using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.BLL.Model;

namespace WebStore.BLL.Interfaces
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAllEmployees();
        Employee GetEmployee(int id);
    }
}
