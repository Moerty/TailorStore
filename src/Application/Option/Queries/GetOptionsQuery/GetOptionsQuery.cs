using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TailorStore.Application.Common.Interfaces;

namespace TailorStore.Application.Option.Queries.GetOptionsQuery {
    public class GetOptionsQuery : IRequest<IList<KeyValuePair<Guid, string>>> {
        public Guid? TypeId { get; set; }
    }

    public class GetOptionsQueryHandler : IRequestHandler<GetOptionsQuery, IList<KeyValuePair<Guid, string>>> {
        private readonly IApplicationDbContext _context;

        public GetOptionsQueryHandler(IApplicationDbContext context) {
            _context = context;
        }

        public async Task<IList<KeyValuePair<Guid, string>>> Handle(GetOptionsQuery request, CancellationToken cancellationToken) {
            if(request.TypeId.HasValue) {
                return await _context.Options
                    .Where(x => x.TypeId == request.TypeId)
                    .Select(s => new KeyValuePair<Guid, string>(s.Id, s.Name))
                    .ToListAsync(cancellationToken)
                    .ConfigureAwait(false);
            }

            return await _context.Options
                    .Select(s => new KeyValuePair<Guid, string>(s.Id, s.Name))
                    .ToListAsync(cancellationToken)
                    .ConfigureAwait(false);
        }
    }
}
