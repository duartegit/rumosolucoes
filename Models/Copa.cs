using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace test.Models
{
    public class Copa
    {
        [Key]
        public int Id_pedido { get; set; }
        [Required]
        public int FK_id_pedido { get; set; }
        [DisplayName("Bebida")]
        public string? Bebida { get; set; }
        [DisplayName("Quantidade")]
        public int? Quantidade { get; set; }

    }
}
