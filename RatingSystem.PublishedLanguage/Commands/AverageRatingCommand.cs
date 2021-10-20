using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatingSystem.PublishedLanguage.Commands
{
    public class AverageRatingCommand : IRequest
    {
        public int ConferenceId { get; set; }
        public decimal AverageRating { get; set; }
    }
}
