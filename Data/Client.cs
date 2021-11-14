using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Otus2.Data
{
    [Table("clients")]
    public class Client
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { set; get; }

        [Column("surname")]
        public string Surname { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("middle_name")]
        public string MiddleName { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("date_birth")]
        public DateTime? DateBirth { get; set; }

        public virtual ICollection<ClientTraining> ClientTrainings { get; set; }
    }
}