using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TailorStore.Application.Common.Interfaces;

namespace TailorStore.Application.Fabric.Queries.GetFabricsQuery {
    public class GetFabricsQuery : IRequest<IList<KeyValuePair<Guid, string>>> { }

    public class GetFabricsQueryHandler : IRequestHandler<GetFabricsQuery, IList<KeyValuePair<Guid, string>>> {
        private readonly IApplicationDbContext _context;

        public GetFabricsQueryHandler(IApplicationDbContext context) {
            _context = context;
        }

        public async Task<IList<KeyValuePair<Guid, string>>> Handle(GetFabricsQuery request, CancellationToken cancellationToken) {
            return await _context.Fabrics
                .Select(s => new KeyValuePair<Guid, string>(s.Id, s.Name))
                .ToListAsync(cancellationToken);
        }
    }
}
