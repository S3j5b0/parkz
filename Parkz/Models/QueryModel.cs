namespace Parkz.Models;

public class QueryModel
{
    
    /// <summary>
    ///  Customer
    /// </summary>
    public string Name {get;set; }
    
    public string Surname { get; set; }
    
    public uint? Age { get; set; }
    
    public DateTime From { get; set; }
    
    public DateTime To { get; set; }
    
    public  SortBy sortBy { get; set; }
    
    
    /// <summary>
    ///  Customer adress
    /// </summary>
    
    public string ZipCode { get; set; }
    
    public  string Country { get; set; }
    
    public  string Street { get; set; }
    
    public  string Town { get; set; }
    public  int HouseNr { get; set; }
    
    /// <summary>
    ///  car
    /// </summary>

    public string model { get; set; }
    public string make { get; set; }
    
    public Color color { get; set; }
    public float recPrice { get; set; }
    
    public float paidPrice { get; set; }
    
    public float recPriceLow { get; set; }
    
    public float recPriceTop { get; set; }
    
    public float paidPriceLow { get; set; }
    
    public float paidPriceTop { get; set; }
    
    
    public DateTime purchaseDateFrom { get; set; }
    
    public DateTime purchaseDateTo { get; set; }
    
    
    /// <summary>
    ///  Salesperson
    /// </summary>

    public string salespersonName { get; set; }

    public Title salespersonJobTitle { get; set; }
    
    public int salesPersonSalary { get; set; }
    
    public int salesPersonSalaryFrom { get; set; }
    
    public int salesPersonSalaryTo { get; set; }
    
    public  string SalesPersonCountry { get; set; }
    
    public  string SalesPersonTown { get; set; }
    
    public string SalesPersonZipCode { get; set; }
    
    public string SalesPersonStreet { get; set; }
    
    public int salesPersonHouseNr { get; set; }
    
    
   
}

public class Inner
{
    public string innething { get; set; }
}

public enum SortBy
{
    Age_desc,
    CreationDate_desc,
    Age_asc,
    CreationDate_asc
}

