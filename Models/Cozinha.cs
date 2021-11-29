using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace test.Models
{
    public class Cozinha
    {
        [Key]
        public int Id_pedido { get; set; }
        [Required]
        public int FK_id_pedido { get; set; }
        [DisplayName("Prazo")]
        public DateTime? Prazo { get; set; }

    }
}
