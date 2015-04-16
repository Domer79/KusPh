using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using DataRepository;

namespace KusPh.Data.Models
{
    public class Kus : ModelBase
    {
        [Key]
        public int Id { get; set; }
        public string ObjectName { get; set; }
        public string Street { get; set; }
        public string House { get; set; }
        public string Apartment { get; set; }
        public double TotalArea { get; set; }
        public int Floors { get; set; }

        [NotMapped]
        public string AreaTotal
        {
            get { return TotalArea.ToString(CultureInfo.InvariantCulture); }
            set { TotalArea = double.Parse(value); }
        }
    }
}
