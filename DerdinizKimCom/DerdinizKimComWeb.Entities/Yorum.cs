using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerdinizKimComWeb.Entities
{
    [Table("Yorumlar")]
    public class Yorum:EntityBase
    {
        [Required,StringLength(300)]
        public string yorum { get; set; }

        public virtual Dert dert { get; set; }
        public virtual User sahibi { get; set; }


    }
}
