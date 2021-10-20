﻿using MediatR;
using RatingSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RatingSystem.Application.Queries
{
    public class GetRating
    {
        public class Query : IRequest<List<Model>>
        {


        }
        public class QueryHandler : IRequestHandler<Query, List<Model>>
        {
            private readonly RatingDbContext _dbContext;

            public QueryHandler(RatingDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public Task<List<Model>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = _dbContext.ConferenceRatings.Select(x => new Model
                {
                    ConferenceId = x.ConferenceId,
                    AverageRating = x.AverageRating



                })
                    .ToList();



                return Task.FromResult(result);
            }
        }
        public class Model
        {
            public int ConferenceId { get; set; }
            public decimal AverageRating { get; set; }

        }
    }
}
