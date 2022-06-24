using System.ComponentModel.DataAnnotations;

namespace Parkz.Models;

public class PurchaseModel
{
    public int Id{get;set; }
    

    [Required]
    public virtual CarModel Car { get; set; }
    [Required]
    public DateTime OrderDate { get; set; }
    [Required]
    public float PricePaid { get; set; }
    [Required]
    public  SalesPersonModel SalesPerson { get; set; }
}