using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataRepository;

namespace KusPh.Data.Models
{
    [Table("Settings")]
    public class Settings : ModelBase
    {
        [Key]
        public int IdSettings { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
        public bool Visible { get; set; }
    }
}
