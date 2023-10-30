using Pustok.Database.DomainModels;
using System.Collections.Generic;

namespace Pustok.ViewModels
{
    public class EmployeeUpdateResponseViewModel : BaseEmployeeViewModel
    {
        public int Id { get; set; }

        public List<Category> Categories { get; set; }
        public string Surname { get; internal set; }
    }
}
