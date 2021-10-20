using MediatR;
using RatingSystem.Data;
using RatingSystem.Models;
using RatingSystem.PublishedLanguage.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RatingSystem.Application.CommandHandlers
{
    public class AverageRatingCommandHandler : IRequestHandler<AverageRatingCommand>
    {
        private readonly IMediator _mediator;
        private readonly RatingDbContext _dbContext;
        private readonly int Id;

        public AverageRatingCommandHandler(IMediator mediator ,RatingDbContext dbContext)
        {
            _mediator = mediator;

            _dbContext = dbContext;
        }

        public Task<Unit> Handle(AverageRatingCommand request, CancellationToken cancellationToken)
        {
            var db = _dbContext.ConferenceXAttendees;

            var conferenceRating = _dbContext.ConferenceRatings.FirstOrDefault(x => x.ConferenceId == request.ConferenceId);
            var average = db.Where(w => w.ConferenceId == request.ConferenceId)
                            .Average(a => a.Rating);
            if (conferenceRating == null)
            {

                conferenceRating = new ConferenceRating
                {
                    ConferenceId = request.ConferenceId,
                    AverageRating = average

                };

                _dbContext.ConferenceRatings.Add(conferenceRating);
            }
            else
            {
                conferenceRating.AverageRating = average;
            }
            _dbContext.SaveChanges();

            return Unit.Task;
        }
    }
    public class Model
    {
        public int ConferenceId { get; set; }
        public decimal AverageRating { get; set; }
    }
}
