using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerdinizKimComWeb.Entities
{
    [Table("Kullanicilar")]
    public class User:EntityBase
    {
        [Required,StringLength(25)]
        public string username { get; set; }

        [Required,StringLength(70)]
        public string email { get; set; }

        [Required,StringLength(150)]
        public string password { get; set; }

        [StringLength(25)]
        public string surname { get; set; }

        [StringLength(25)]
        public string name { get; set; }

        public bool aktifmi { get; set; }

        [Required]
        public Guid activate { get; set; }

        public bool adminmi { get; set; }

        public virtual List<Dert> Dertler { get; set; }

        public virtual List<Yorum> Yorumlar { get; set; }

        public virtual List<begenilmils> begenilmis { get; set; }


    }
}
