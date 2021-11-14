using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Otus2.Data
{
    [Table("training_programs")]
    public class TrainingProgram
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { set; get; }

        [Column("name")]
        public string Name { set; get; }

        public virtual ICollection<Training> Trainings { get; set; }
    }
}