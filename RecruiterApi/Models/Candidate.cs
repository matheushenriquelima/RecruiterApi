using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecruiterApi.Models
{
    [Table("tb_candidato")]
    public class Candidate
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("nome")]
        public string Name { get; set; }
        [Column("contato")]
        public string Contact { get; set; }
        [Column("habilidades")]
        public string Skills { get; set; }
        [Column("status")]
        public bool IsHired { get; set; }
        [Column("dataContratacao")]
        public DateTime? HiringDate { get; set; }
    }
}
