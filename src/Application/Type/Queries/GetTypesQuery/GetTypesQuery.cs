using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TailorStore.Application.Common.Interfaces;

namespace TailorStore.Application.Type.Queries.GetTypesQuery {
    public class GetTypesQuery : IRequest<IList<KeyValuePair<Guid, string>>> { }

    public class GetTypesQueryHandler : IRequestHandler<GetTypesQuery, IList<KeyValuePair<Guid, string>>> {
        private readonly IApplicationDbContext _context;

        public GetTypesQueryHandler(
            IApplicationDbContext context) {
            _context = context;
        }

        public async Task<IList<KeyValuePair<Guid, string>>> Handle(GetTypesQuery request, CancellationToken cancellationToken) {
            return await _context.Types
                .Select(s => new KeyValuePair<Guid, string>(s.Id, s.Name))
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);
        }
    }
}
