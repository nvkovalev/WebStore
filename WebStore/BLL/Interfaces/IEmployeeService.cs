using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.BLL.Model;

namespace WebStore.BLL.Interfaces
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAll();
        Employee GetById(int id);
        void AddNew(Employee employee);
        void Delete(int id);
    }
}
