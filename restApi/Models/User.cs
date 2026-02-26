using System.ComponentModel.DataAnnotations.Schema;

namespace restApi.Models;

[Table("Persons", Schema = "Persondata")]
public class User
{
    public int Id { get; set; } // Primary key i db
    public string Navn {get; set;} 
    public string? Mail {get; set;}
    public string? Telefon{get; set;}
}