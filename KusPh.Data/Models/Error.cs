using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataRepository;

namespace KusPh.Data.Models
{
    [Table("Error")]
    public class Error : ModelBase
    {
        [Key]
        [Column("idError")]
        public int IdError { get; set; }

        [Column("type")]
        public string TypeError { get; set; }

        [Column("message")]
        public string Message { get; set; }

        [Column("stackTrace")]
        public string StackTrace { get; set; }

        [Column("timeLabel")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime TimeLabel { get; set; }
    }
}