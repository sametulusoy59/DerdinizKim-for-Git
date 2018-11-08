using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerdinizKimComWeb.Entities
{
    [Table("Kategoriler")]
    public class Kategori:EntityBase
    {
        [Required,StringLength(50)]
        public string baslik { get; set; }

        [StringLength(150)]
        public string aciklama { get; set; }

        public virtual List<Dert> Dertler { get; set; }

        public Kategori()
        {
            Dertler = new List<Dert>();
        }
       
    }
}
