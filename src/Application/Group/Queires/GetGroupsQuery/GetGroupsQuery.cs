using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TailorStore.Application.Common.Interfaces;

namespace TailorStore.Application.Group.Queires.GetGroupsQuery {
    public class GetGroupsQuery : IRequest<IList<KeyValuePair<Guid, string>>> { }

    public class GetGroupsQueryHandler : IRequestHandler<GetGroupsQuery, IList<KeyValuePair<Guid, string>>> {
        private readonly IApplicationDbContext _context;

        public GetGroupsQueryHandler(IApplicationDbContext context) {
            _context = context;
        }

        public async Task<IList<KeyValuePair<Guid, string>>> Handle(GetGroupsQuery request, CancellationToken cancellationToken) {
            return await _context.Groups
                .Select(s => new KeyValuePair<Guid, string>(s.Id, s.Name))
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);
        }
    }
}
