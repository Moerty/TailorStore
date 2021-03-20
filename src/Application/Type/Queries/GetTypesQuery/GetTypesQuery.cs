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
    public class GetTypesQuery : IRequest<IList<GetTypesQueryDto>> { }

    public class GetTypesQueryHandler : IRequestHandler<GetTypesQuery, IList<GetTypesQueryDto>> {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetTypesQueryHandler(
            IApplicationDbContext context,
            IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IList<GetTypesQueryDto>> Handle(GetTypesQuery request, CancellationToken cancellationToken) {
            return await _context.Types
                .ProjectTo<GetTypesQueryDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);
        }
    }
}
