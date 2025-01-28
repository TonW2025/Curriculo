using System.ComponentModel.DataAnnotations;

namespace Curriculo.API.Models
{
    public class Candidato
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        // Adicione outras propriedades aqui
    }
}
