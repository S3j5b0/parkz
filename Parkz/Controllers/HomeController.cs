using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;
using ParkingApp.Models;
using Parkz.DAL;
using Parkz.Models;

namespace Parkz.Controllers;

public class HomeController : Controller
{
    private readonly DemoContext _context;
    
    public HomeController(DemoContext ctx)
    {
        _context = ctx;
    }
    public IActionResult Index()
    {

        return View();
    }

    [HttpPost]
    
    public async Task<IActionResult> Query(QueryModel query)
    {
        var customers = await _context.Customers.AsQueryable().FilterCustomerList(query);


        return View("Index", customers);
    }


    
    
    


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }
}

