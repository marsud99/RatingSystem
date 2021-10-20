using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatingSystem.Models
{
    public class ConferenceXAttendee
    {
        public string AttendeeEmail { get; set; }
        public int ConferenceId { get; set; }
        public decimal Rating { get; set; }
        public string Hash { get; set; }
    }
}
