using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace restApi.Models;

[Table("Persons")]
 public class User
{
    public int Id { get; set; } // Primary key i db
    
    [Required(ErrorMessage = "Navn er påkrevd")]
    public string Name {get; set;} 
    
    [EmailAddress(ErrorMessage = "Ugyldig e-postadresse")]
    public string? Email {get; set;}
    
    [RegularExpression(@"^\d{8}$", ErrorMessage = "Telefon må være 8 siffer")]
    public string? Number{ get; set; }
    
    public string? Address { get; set; }
}