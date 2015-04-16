using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using DataRepository;

namespace KusPh.Data.Models
{
    public class Kus : ModelBase
    {
        [Key]
        [Column("Id")]
        public int IdKus { get; set; }
        public string ObjectName { get; set; }
        public string Street { get; set; }
        public string House { get; set; }
        public string Apartment { get; set; }
        public double TotalArea { get; set; }
        public int Floors { get; set; }
        public string RegOperator { get; set; }
        public string SpecAccount { get; set; }
        public string RegOperatorFund { get; set; }
    }
}
