using Pustok.Database.DomainModels;
using Pustok.Database.Repositories;
using System;

namespace Pustok.Controllers.Admin
{
    internal class EmployeeRepository
    {
        internal void Insert(Employee employee)
        {
            throw new NotImplementedException();
        }

        internal void Update(Employee employee)
        {
            throw new NotImplementedException();
        }

        public static implicit operator EmployeeRepository(Database.Repositories.EmployeeRepository v)
        {
            throw new NotImplementedException();
        }
    }
}