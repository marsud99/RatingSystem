using MediatR;
using RatingSystem.Application.CommandHandlers;
using RatingSystem.Data;
using RatingSystem.Models;
using RatingSystem.PublishedLanguage.Commands;
using RatingSystem.PublishedLanguage.Events;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RatingSystem.Application.WriteOperations
{
    public class AddRatingCommandHandler : IRequestHandler<AddRatingCommand>
    {
        private readonly IMediator _mediator;
        private readonly AddRatingCommand _accountOptions;
        private readonly RatingDbContext _dbContext;

        public AddRatingCommandHandler(IMediator mediator, RatingDbContext dbContext)
        {
            _mediator = mediator;
            _dbContext = dbContext;
        }

        public  async Task<Unit> Handle(AddRatingCommand request, CancellationToken cancellationToken)
        {
            var conferenceXAttendee = _dbContext.ConferenceXAttendees.FirstOrDefault(x => x.Hash == $"{request.AttendeeEmail}##{request.ConferenceId}");
            if (conferenceXAttendee == null)
            {
                conferenceXAttendee = new ConferenceXAttendee
                {
                    Hash = $"{request.AttendeeEmail}##{request.ConferenceId}",
                    AttendeeEmail = request.AttendeeEmail,
                    ConferenceId = request.ConferenceId,
                    Rating = request.Rating
                };
                _dbContext.ConferenceXAttendees.Add(conferenceXAttendee);
            } else
            {
                conferenceXAttendee.Rating = request.Rating;
            }

            _dbContext.SaveChanges();
            await _mediator.Publish(new AddRatingEvent() { Hash = conferenceXAttendee.Hash, AttendeeEmail = conferenceXAttendee.AttendeeEmail, ConferenceId = conferenceXAttendee.ConferenceId, Rating = conferenceXAttendee.Rating }, cancellationToken);
            await _mediator.Send(new AverageRatingCommand() { ConferenceId= request.ConferenceId, AverageRating = 0}, cancellationToken);
            return Unit.Value;
        }        
    }
}
