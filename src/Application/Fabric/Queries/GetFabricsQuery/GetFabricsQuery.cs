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

namespace TailorStore.Application.Fabric.Queries.GetFabricsQuery {
    public class GetFabricsQuery : IRequest<IList<GetFabricsQueryDto>> { }

    public class GetFabricsQueryHandler : IRequestHandler<GetFabricsQuery, IList<GetFabricsQueryDto>> {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetFabricsQueryHandler(
            IApplicationDbContext context,
            IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IList<GetFabricsQueryDto>> Handle(GetFabricsQuery request, CancellationToken cancellationToken) {
            return await _context.Fabrics
                .ProjectTo<GetFabricsQueryDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }
}
