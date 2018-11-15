using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.BLL.Interfaces;
using WebStore.BLL.Model;

namespace WebStore.BLL.Implementation
{
    public class InMemoryEmployeeService : IEmployeeService
    {
        private readonly List<Employee> _employees = new List<Employee>
        {
            new Employee
            {
                Id = 1,
                FirstName = "Иван",
                SurName = "Иванов",
                Patronymic = "Иванович",
                Age = 22,
                Position = "Начальник",
                BirthDate = DateTime.Today.Subtract(TimeSpan.FromDays(10000))
    },
            new Employee
            {
                Id = 2,
                FirstName = "Владислав",
                SurName = "Петров",
                Patronymic = "Иванович",
                Age = 35,
                Position = "Шэф",
                BirthDate = DateTime.Today.Subtract(TimeSpan.FromDays(20000))
    },
            new Employee
            {
                Id = 3,
                FirstName = "Василий",
                SurName = "Пупкин",
                Patronymic = "",
                Age = 40,
                Position = "Босс",
                BirthDate = DateTime.Today.Subtract(TimeSpan.FromDays(30000))
            }
        };

        public void AddNew(Employee employee)
        {
            _employees.Add(employee);
        }

        public void Delete(int id)
        {
            var employee = _employees.FirstOrDefault(x => x.Id == id);

            if (employee != null)
                _employees.Remove(employee);
        }

        public IEnumerable<Employee> GetAll()
        {
            return _employees;
        }

        public Employee GetById(int id)
        {
            return _employees.FirstOrDefault(x => x.Id == id);
        }
        
    }
}
