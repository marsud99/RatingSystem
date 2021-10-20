using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatingSystem.PublishedLanguage.Commands
{
    public class AddRatingCommand : IRequest
    {   public string Hash { get; set; }
        public string AttendeeEmail { get; set; }
        public int ConferenceId { get; set; }
        public decimal Rating { get; set; }
        
    }
}
