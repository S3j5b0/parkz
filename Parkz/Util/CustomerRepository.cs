using Parkz.Models;
using System.Linq.Expressions;

using Microsoft.EntityFrameworkCore;
namespace Parkz.DAL;



public static class QueryableEx
{
    public static IQueryable<T> Where<T>(
        this IQueryable<T> @this,
        bool condition,
        Expression<Func<T, bool>> @where)
    {
        return condition ? @this.Where(@where) : @this;
    }

    public static async Task<List<CustomerModel>> FilterCustomerList(this IQueryable<CustomerModel> customersQuery, QueryModel query)
    {


        customersQuery = customersQuery
            .Include(x => x.Adress)
            .Include(x => x.purchases).ThenInclude(x => x.Car)
            .Include(x => x.purchases).ThenInclude(x => x.SalesPerson.Adress)
            .Where(query.Name != default, x => x.Name.Equals(query.Name))
            .Where(query.Surname != default, x => x.Surname.Equals(query.Surname))
            .Where(query.Age != default, x => x.Age.Equals(query.Age))
            .Where(query.Country != default, x => x.Adress.Country.Equals(query.Country))
            .Where(query.Town != default, x => x.Adress.Town.Equals(query.Town))
            .Where(query.ZipCode != default, x => x.Adress.ZipCode.Equals(query.ZipCode))
            .Where(query.Street != default, x => x.Adress.street.Equals(query.Street))
            .Where(query.HouseNr != default, x => x.Adress.HouseNumber.Equals(query.HouseNr))
            .Where(query.To != query.From, x => x.Created > query.From && x.Created < query.To)
            .Where(query.purchaseDateFrom != query.purchaseDateTo, x => x.purchases.Any(
                x => x.OrderDate > query.purchaseDateFrom && x.OrderDate < query.purchaseDateTo))
            .Where(query.model != default, x => x.purchases.Any(p => p.Car.Model.Equals(query.model)))
            .Where(query.make != default, x => x.purchases.Any(p => p.Car.Make.Equals(query.make)))
            .Where(query.color != default, x => x.purchases.Any(p => p.Car.CarColor == query.color))
            .Where(query.paidPrice != default, x => x.purchases.Any(p => p.PricePaid.Equals(query.recPrice)))
            .Where(query.recPrice != default,
                x => x.purchases.Any(p => p.Car.RecommendedPrice.Equals(query.recPrice)))
            .Where(query.recPriceLow != default && query.recPriceTop != default, x
                => x.purchases.Any(p =>
                    p.Car.RecommendedPrice > query.recPriceLow && p.Car.RecommendedPrice < query.recPriceTop))
            .Where(query.paidPriceTop != default && query.paidPriceLow != default, x
                => x.purchases.Any(p => p.PricePaid > query.paidPriceLow && p.PricePaid < query.paidPriceTop))
            .Where(query.salespersonName != default,
                c => c.purchases.Any(p => p.SalesPerson.Name.Equals(query.salespersonName)))
            .Where(query.salespersonJobTitle != default,
                c => c.purchases.Any(x => x.SalesPerson.JobTitle == query.salespersonJobTitle))
            .Where(query.salesPersonSalary != default, c => c.purchases.Any(x => query.salesPersonSalary.Equals(x
                .SalesPerson.Salary)))
            .Where(query.salesPersonSalaryFrom != default && query.salesPersonSalaryFrom != default, c =>
                c.purchases.Any(x => x.SalesPerson.Salary < query.salesPersonSalaryFrom &&
                                     x.SalesPerson.Salary > query.salesPersonSalaryTo))
            .Where(query.SalesPersonCountry != default,
                c => c.purchases.Any(x => x.SalesPerson.Adress.Country.Equals(query.SalesPersonCountry)))
            .Where(query.SalesPersonTown != default,
                c => c.purchases.Any(x => x.SalesPerson.Adress.Town.Equals(query.SalesPersonTown)))
            .Where(query.SalesPersonZipCode != default, c => c.purchases.Any(x =>
                x.SalesPerson.Adress.ZipCode.Equals(query.ZipCode)))
            .Where(query.SalesPersonStreet != default, c => c.purchases.Any(x =>
                x.SalesPerson.Adress.street.Equals(query.SalesPersonStreet)))
            .Where(query.salesPersonHouseNr != default, c => c.purchases.Any(x =>
                x.SalesPerson.Adress.HouseNumber.Equals(query.salesPersonHouseNr)));
        
        
        

        
        switch (query.sortBy)
        {
            case SortBy.Age_desc:
            {
                customersQuery = customersQuery.OrderByDescending(c => c.Age);
                break;
            }
            case SortBy.CreationDate_desc:
            {
                customersQuery = customersQuery.OrderByDescending(c => c.Created);
                break;
            }
            case SortBy.Age_asc:
            {
                customersQuery = customersQuery.OrderBy(c => c.Age);
                break;
            }
            case SortBy.CreationDate_asc:
            {
                customersQuery = customersQuery.OrderBy(c => c.Created);
                break;
            }
        }

        
        

        var customers = await customersQuery
            .ToListAsync();
        

        return customers;
    }


}