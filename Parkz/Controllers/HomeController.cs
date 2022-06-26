using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;
using Parkz.Models;

using X.PagedList;
namespace Parkz.Controllers;

public class HomeController : Controller
{
    private readonly Repository _repository;
    
    public HomeController(Repository repository)
    {
        _repository = repository;
    }
    public IActionResult Index()
    {

        return View();
    }

    
    public async Task<IActionResult> Query(QueryModel query, int page =1)
    {

        IPagedList<CustomerModel> customers = await _repository.FindCustomers(query,page,10);
    
        return View("Index", customers);
    }


    
    
    


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }
}

