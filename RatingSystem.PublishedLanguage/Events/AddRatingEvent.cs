using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatingSystem.PublishedLanguage.Events
{
    public class AddRatingEvent:INotification
    {
        public int ConferenceId { get; set; }
        public string AttendeeEmail { get; set; }

        public decimal Rating { get; set; }

        public string Hash { get; set; }
    }
}
