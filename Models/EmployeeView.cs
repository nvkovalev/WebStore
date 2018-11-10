using System;
using WebStore.BLL.Model;

namespace WebStore.Models
{
    public class EmployeeView
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string Patronymic { get; set; }
        public int Age { get; set; }

        public string Position { get; set; }
        public DateTime BirthDate { get; set; }

        public void FromBll(Employee bll)
        {
            Id = bll.Id;
            FirstName = bll.FirstName;
            SurName = bll.SurName;
            Patronymic = bll.Patronymic;
            Age = bll.Age;
            Position = bll.Position;
            BirthDate = bll.BirthDate;
        }

        public override string ToString()
        {
            return $"Карточка сотрудника: {SurName} {FirstName}";
        }
    }
}
