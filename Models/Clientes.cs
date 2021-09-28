using System.ComponentModel.DataAnnotations;
namespace Api_Catalogos.Models
{
    public class Clientes{
        [Key]
        public int IdClientes{get; set;}
        public string Nombre{get; set;}
        public string Apellido{get; set;}
        public string Cuit{get; set;}

    }
}