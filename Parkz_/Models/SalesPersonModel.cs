using System.ComponentModel.DataAnnotations;

namespace Parkz.Models;

public class SalesPersonModel
{
    public int Id{get;set; }
    [Required]
    public string Name { get; set; }
    // would we really want coworkers to see each others salary?
    [Required]
    public Title JobTitle { get; set; }
    [Required]
    public virtual AdressModel Adress { get; set; }
    [Required]
    public uint Salary { get; set; }
}


public enum Title
{
    Consultant,
    Analyst,
    Manager,
}