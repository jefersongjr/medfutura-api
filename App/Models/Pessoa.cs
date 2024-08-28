namespace App.Models{
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


public class Pessoa
  {  
    
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("apelido")]
    public string Apelido { get; set; }
   
    [Column("nome")]
    public string Nome { get; set; }
   
    [Column("nascimento")]
    public DateTime Nascimento { get; set; }

    [Column("stack")]
    public string[] Stack { get; set; } = null!;
    }
}

