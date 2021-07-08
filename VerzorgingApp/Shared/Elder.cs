using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerzorgingApp.Shared
{
    public class Elder : Person
    {
        public List<Medicine> Medicines { get; set; }

        //[ForeignKey("Person")]
        [Required]
        public int CaretakerId { get; set; }

        public Caretaker Caretaker { get; set; }
    }
}
