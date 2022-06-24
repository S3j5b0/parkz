using System.ComponentModel.DataAnnotations;

namespace Parkz.Models;

public class CarModel
{
    public int Id{get;set; }
    [Required]
    public string Make { get; set; }
    [Required]
    public string Model { get; set; }

    
    [Required]
    public Color CarColor { get; set; }
    

    
    [Required]
    public float RecommendedPrice { get; set; }
    public string[] Extras { get; set; }

}
public enum Color
{
    Red,
    Green,
    Blue,
    Black,
    Silver,
}

