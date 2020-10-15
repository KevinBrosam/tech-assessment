using System.ComponentModel.DataAnnotations;

namespace CSharp.Models{
    public class Customer{
        [Key]
        public int Id{get;set;}
        [Required]
        [MaxLength(20)]
        public string Name{get;set;}
    }
}