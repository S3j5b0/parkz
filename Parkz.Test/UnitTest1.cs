using Microsoft.EntityFrameworkCore;
using Parkz.Models;
using Parkz.DAL;
using Parkz.Models;

namespace Parkz.Test;

public class Tests
{
    private ApplicationDbContext _context;
    
    [SetUp]
    public void Setup()
    {
        var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("Test");
        
        
        _context = new ApplicationDbContext(dbContextOptions.Options);
        _context.Database.EnsureCreated();

        SalesPersonModel s = new SalesPersonModel()
        {
            Name = "Bob salesGuy",
            JobTitle = Title.Analyst,
            Adress = new AdressModel()
            {
                Country  = "Sweden",
                Town = "Häfting",
                street = "huvudgatan",
                HouseNumber = 5,
                ZipCode = "1010",
            },
            Salary = 20000,
        };


        CustomerModel c = new CustomerModel()
        {
            Name = "jon",
            Surname = "Jensen",
            Age = 30,
            Adress = new AdressModel()
            {
              Country  = "Denmark",
              Town = "AArhus",
              street = "hovedgaden",
              HouseNumber = 22,
              ZipCode = "3000",
            },
            Created = new DateTime(2022,10,12),
            purchases = new List <PurchaseModel>
            {
                new PurchaseModel()
                {
                    OrderDate = new DateTime(2022,10,12),
                    PricePaid = 200000,
                    SalesPerson = s,
                    Car = new CarModel()
                    {
                        Model = "camaro",
                        Make = "v100",
                        CarColor = Color.Black,
                        RecommendedPrice = 200001,
                    }
                }
            }
        };
        CustomerModel c1 = new CustomerModel()
        {
            Name = "jon",
            Surname = "Nielsen",
            Age = 30,
            Adress = new AdressModel()
            {
                Country  = "Denmark",
                Town = "København",
                street = "Smallegade",
                HouseNumber = 10,
                ZipCode = "3300",
            },
            Created = new DateTime(2021,10,12),
            purchases = new List <PurchaseModel>
            {
                new PurchaseModel()
                {
                    OrderDate = new DateTime(2022,01,3),
                    PricePaid = 200000,
                    SalesPerson = s,
                    Car = new CarModel()
                    {
                        Model = "Ford",
                        Make = "v100",
                        CarColor = Color.Black,
                        RecommendedPrice = 200001,
                    }
                }
            }
        };

        _context.Customers.AddRange(c,c1);
        _context.SalesPeople.Add(s);

        _context.SaveChanges();
    }
    
    [TearDown]
    public void TearDown()
    {
        _context.Database.EnsureDeleted();
    }

    
// getting customers by name
    [Test]
    public async Task Test1()
    {
        var Repo = new Repository(_context);
        var customers=  await Repo.FindCustomers(new QueryModel() {Name = "jon"},1,20);

        foreach (var customer in customers)
        {
            Assert.That(customer.Name, Is.EqualTo("jon"));
        }
        Assert.That(customers.Count, Is.EqualTo(2));
        
        Assert.Pass();
    }
    
    // getting customers by street
    [Test]
    public async Task Test2()
    {
        var Repo = new Repository(_context);
        var customers=  await Repo.FindCustomers(new QueryModel() {Street = "Smallegade"},1,20);

        foreach (var customer in customers)
        {
            Assert.That(customer.Adress.street, Is.EqualTo("Smallegade"));
        }
        Assert.That(customers.Count, Is.EqualTo(1));
        
        Assert.Pass();
    }
    
    // getting customers by bought make
    [Test]
    public async Task Test3()
    {
        var Repo = new Repository(_context);
        var customers=  await Repo.FindCustomers(new QueryModel() {make = "v100"},1,20);

        foreach (var customer in customers)
        {
            Assert.True(customer.purchases.Any(x => x.Car.Make.Equals("v100")));
        }
        Assert.That(customers.Count, Is.EqualTo(2));
        
        Assert.Pass();
    }
    // getting customers by bought model
    [Test]
    public async Task Test4()
    {
        var Repo = new Repository(_context);
        var customers=  await Repo.FindCustomers(new QueryModel() {model = "camaro"},1,20);

        foreach (var customer in customers)
        {
            Assert.True(customer.purchases.Any(x => x.Car.Model.Equals("camaro")));
        }
        Assert.That(customers.Count, Is.EqualTo(1));
        
        Assert.Pass();
    }
    // getting customers by salesperson used
    [Test]
    public async Task Test5()
    {
        var Repo = new Repository(_context);
        var customers=  await Repo.FindCustomers(new QueryModel() {salespersonName = "Bob salesGuy"},1,20);

        foreach (var customer in customers)
        {
            Assert.True(customer.purchases.Any(x => x.SalesPerson.Name.Equals("Bob salesGuy")));
        }
        Assert.That(customers.Count, Is.EqualTo(2));
        
        Assert.Pass();
    }
}