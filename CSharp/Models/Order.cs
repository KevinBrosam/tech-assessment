using System.ComponentModel.DataAnnotations;

namespace CSharp.Models{
    public class Order{
        [Key]
        public int Id{get;set;}
        [Required]
        public int OrderNumber{get;set;}
        [Required]
        public string Description{get;set;}
        [Required]
        public int CustomerId{get;set;}
    }
}