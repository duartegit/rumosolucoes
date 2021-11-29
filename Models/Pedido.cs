using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace test.Models
{
    public class Pedido
    {
        [Key]
        public int Id_pedido { get; set; }
        [Required]
        [DisplayName("Nome do Prato")]
        public string? NomePrato { get; set; }
        [Required]
        [DisplayName("Nome do Cliente")]
        public string? NomeCliente { get; set; }
        [DisplayName("Bebida")]
        public string? Bebida { get; set; }
        [DisplayName("Quantidade")]
        [Range(0, 20, ErrorMessage = "Pode-se pedir apenas 0 a 20 bebidas")]
        public int Quantidade { get; set; }
        [Required]
        [DisplayName("Mesa")]
        [Range(1,50, ErrorMessage="O número da mesa deve estar entre 1 e 50")]
        public int Mesa { get; set; }


    }
}
