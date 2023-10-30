using Microsoft.AspNetCore.Mvc;
using Pustok.Database;
using Pustok.Database.Repositories;

namespace Pustok.Controllers.Client;

//controller 
public class HomeController : Controller
{
    private readonly EmployeeRepository _employeeRepository;

    public HomeController()
    {
        _employeeRepository = new EmployeeRepository();
    }

    // localhost:2323/home/index
    //action
    //url mapping, route mapping
    public ViewResult Index()
    {
        return View(_employeeRepository.GetAll());
    }

    // localhost:2323/home/contact
    //action
    public ViewResult Contact()
    {
        return View();
    }

    // localhost:2323/home/about
    //action
    public ViewResult About()
    {
        return View();
    }

    protected override void Dispose(bool disposing)
    {
        _employeeRepository.Dispose();

        base.Dispose(disposing);
    }
}
