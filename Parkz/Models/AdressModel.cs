
namespace Parkz.Models;
using System.ComponentModel.DataAnnotations;

public class AdressModel
{
    public int Id { get; set; }
    [Required]
    public string street { get; set; }
    [Required]
    
    public int HouseNumber { get; set; }
    [Required]
    public string Town { get; set; }
    [Required]
    public string ZipCode { get; set; }
    [Required]
    public string Country { get; set; }
}