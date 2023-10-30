using Pustok.Database.DomainModels;
using System.Collections.Generic;

namespace Pustok.ViewModels;

public class EmployeeAddResponseViewModel : BaseEmployeeViewModel
{

    public List<Category> Categories { get; set; }
}
