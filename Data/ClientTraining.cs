using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Otus2.Data
{
    [Table("client_trainings")]
    public class ClientTraining
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { set; get; }

        [Column("training")]
        public virtual Training Training { get; set; }

        [Column("client")]
        public virtual Client Client { get; set; }
    }
}