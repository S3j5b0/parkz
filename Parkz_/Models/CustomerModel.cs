using System.ComponentModel.DataAnnotations;

namespace Parkz.Models;

public class CustomerModel
{
        public int Id{get;set; }
        [Required]
        public string Name {get;set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        [Range(18,110)]
        public uint Age { get; set; }
        [Required]
        public AdressModel Adress { get; set; }
        [Required]
        public  DateTime Created { get; set; }
        [Required]
        public List<PurchaseModel> purchases { get; set; }
}