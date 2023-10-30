using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Npgsql;
using Pustok.Database.DomainModels;
using Pustok.Database.Repositories;
using Pustok.ViewModels;

namespace Pustok.Controllers.Admin;

[Route("admin/employees")]
public class EmployeeController : Controller
{
    private readonly EmployeeRepository _productRepository;
    private readonly Database.Repositories.EmployeeRepository _employeeRepository;
    private readonly ILogger<EmployeeController> _logger;

    public EmployeeController()
    {
        _employeeRepository = new Database.Repositories.EmployeeRepository();
   

        var factory = LoggerFactory.Create(builder => { builder.AddConsole(); });

        _logger = factory.CreateLogger<EmployeeController>();
    }

    #region Employee

    [HttpGet] //admin/employee
  

    #endregion

    #region Add

    [HttpGet("add")]
    public IActionResult Add()
    {
  
   
        return View("Views/Admin/Employee/EmployeeAdd.cshtml", model);
    }

    [HttpPost("add")]
    public IActionResult Add(EmployeeAddRequestViewModel model)
    {
        if (!ModelState.IsValid)
            return PrepareValidationView("Views/Admin/Employee/EmployeeAdd.cshtml");

        if (model.CategoryId != null)
        {
            var category = _categoryRepository.GetById(model.CategoryId.Value);
            if (category == null)
            {
                ModelState.AddModelError("CategoryId", "Category doesn't exist");

                return PrepareValidationView("Views/Admin/Employee/EmployeeAdd.cshtml");
            }
        }

        var employee = new Employee
        {
            Name = model.Name,
            Price = model.Price,
            Rating = model.Rating,
            CategoryId = model.CategoryId,
        };

        try
        {
            _employeeRepository.Insert(employee);
        }
        catch (PostgresException e)
        {
            _logger.LogError(e, "Postgresql Exception");

            throw e;
        }

        return RedirectToAction("Employees");
    }

    #endregion

    #region Edit

    [HttpGet("edit")]
    public IActionResult Edit(int id)
    {
        Employee employee = _employeeRepository.GetById(id);
        if (employee == null)
            return NotFound();


        var model = new EmployeeUpdateResponseViewModel
        {
            Id = employee.Id,
            Name = employee.Name,
            Surname = employee.Surname,
            FatherName = employee.FatherName,
            Categories = _categoryRepository.GetAll(),
            CategoryId = employee.CategoryId
        };

        return View("Views/Admin/Employee/EmployeeE.cshtml", model);
    }

    [HttpPost("edit")]
    public IActionResult Edit(EmployeeUpdateRequestViewModel model)
    {
        if (!ModelState.IsValid)
            return PrepareValidationView("Views/Admin/Product/ProductEdit.cshtml");

        if (model.CategoryId != null)
        {
            var category = _categoryRepository.GetById(model.CategoryId.Value);
            if (category == null)
            {
                ModelState.AddModelError("CategoryId", "Category doesn't exist");

                return PrepareValidationView("Views/Admin/Product/ProductAdd.cshtml");
            }
        }

        Employee employee = _employeeRepository.GetById(model.Id);
        if (employee == null)
            return NotFound();


        employee.Name = model.Name;
       employee.Surname = model.


        try
        {
            _productRepository.Update(employee);
        }
        catch (PostgresException e)
        {
            _logger.LogError(e, "Postgresql Exception");

            throw e;
        }


        return RedirectToAction("Employees");
    }

    #endregion

    #region Delete

    [HttpGet("delete")]
    public IActionResult Delete(int id)
    {
        Employee employee = _employeeRepository.GetById(id);
        if (employee == null)
        {
            return NotFound();
        }

        _employeeRepository.RemoveById(id);

        return RedirectToAction("Employees");
    }

    #endregion


    protected override void Dispose(bool disposing)
    {
        _employeeRepository.Dispose();
 

        base.Dispose(disposing);
    }
}
