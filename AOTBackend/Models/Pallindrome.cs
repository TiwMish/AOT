using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AOTBackend.Models
{
    public class Pallindrome
    {
        [Key]
        public string QueryString { get; set; }
    }
}
