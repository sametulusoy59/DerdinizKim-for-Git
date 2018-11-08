using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerdinizKimComWeb.Entities
{
    public class EntityBase
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        public DateTime olusturulduguzaman { get; set; }

        [Required]
        public DateTime duzenlendigitarih { get; set; }

        [Required,StringLength(20)]
        public string duzenleyenkullanici { get; set; }
    }
}
