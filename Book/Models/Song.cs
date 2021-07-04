using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Book.Models
{
    public class Song
    {
        [Key]
        public int Id { get; set; }

        [Required (ErrorMessage ="Şarkı adı girmek zorunludur!")]
        public string SarkiAd { get; set; }
        public string Sarkici { get; set; }
        public string Album { get; set; }
    }
}
