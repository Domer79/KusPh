using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public float TotalArea { get; set; }
        public int Floors { get; set; }
    }
}
