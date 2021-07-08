using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerzorgingApp.Shared
{
    public class Appointment
    {
        public int Id { get; set; }

        public string Subject { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string CategoryColor { get; set; }


    }
}
