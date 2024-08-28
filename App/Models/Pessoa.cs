namespace App.Models{
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.VisualBasic;

    public class Pessoa
  {  
    
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Required]
    [Column("apelido")]
    public string Apelido { get; set; }

    [Required]
    [Column("nome")]
    public string Nome { get; set; }
   
    [Column("nascimento")]
    public DateOnly Nascimento { get; set; }
    
    [Column("stack")]
    public string[] Stack { get; set; } = null!;
    }
}

