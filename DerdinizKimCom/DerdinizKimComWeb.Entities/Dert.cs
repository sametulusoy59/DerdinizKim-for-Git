using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerdinizKimComWeb.Entities
{
    [Table("Dertler")]
    public class Dert:EntityBase
    {
        [Required,StringLength(60)]
        public string baslik { get; set; }

        [Required,StringLength(2000)]
        public string dert { get; set; }

        public bool taslakmi { get; set; }

        public int begenisayisi { get; set; }

        public int KategoriId { get; set; }

        public virtual User sahibi { get; set; }
        public virtual List<Yorum> Yorumlar { get; set; }
        public virtual Kategori kategori { get; set; }
        public virtual List<begenilmils>begenilmis { get; set; }

        public Dert()
        {
            Yorumlar = new List<Yorum>();
            begenilmis = new List<begenilmils>();
        }
    }
}
