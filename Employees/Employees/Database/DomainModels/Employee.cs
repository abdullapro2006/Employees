using System;

namespace Pustok.Database.DomainModels
{
    public class Employee
    {
        public Employee(int id, string pin, string name, string surname, string fatherName, string email)
        {
            Id = id;
            Pin = pin;
            Name = name;
            Surname = surname;
            FatherName = fatherName;
            Email = email;
        }

        public int Id { get; set; }
        public string Pin { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FatherName { get; set; }
        public string Email { get; set; }


    }
}
