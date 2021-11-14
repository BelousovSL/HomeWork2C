using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Otus2.Data
{
    [Table("trainings")]
    public class Training
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { set; get; }

        [Column("start_date_training")]
        public DateTime StartDateTraining { get; set; }

        [Column("end_date_training")]
        public DateTime EndDateTraining { get; set; }

        [Column("date_issue_certificates")]
        public DateTime DateIssueCertificates { get; set; }

        [Column("test_int")]
        public int? TestInt { get; set; }

        public virtual TrainingProgram TrainingProgram { get; set; }

        public ICollection<ClientTraining> ClientTrainings { get; set; }

    }
}