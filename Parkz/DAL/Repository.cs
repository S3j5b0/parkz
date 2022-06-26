using Microsoft.EntityFrameworkCore;
using Parkz.DAL;
using Parkz.Models;
using X.PagedList;

namespace Parkz;

using System.Collections.Generic;
using System.Linq;




public class Repository
{
    private readonly ApplicationDbContext _context;
    public Repository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IPagedList<CustomerModel>> FindCustomers(QueryModel query, int page, int pageSize)
    {
        var customers = await _context.Customers
            .AsNoTracking()
            .Include(x => x.Adress)
            .Include(x => x.purchases).ThenInclude(x => x.Car)
            .Include(x => x.purchases).ThenInclude(x => x.SalesPerson.Adress)
            .AddCustomerFilters(query)
            .AddSorting(query)
            .ToListAsync();
        var c = customers.ToPagedList(page, pageSize);
        return customers.ToPagedList(page,pageSize);
    }
}