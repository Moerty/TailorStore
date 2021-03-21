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

namespace TailorStore.Application.ClothesFabric.Queries.GetClothesFabricsQuery {
    public class GetClothesFabricsQuery : IRequest<IList<GetClothesFabricsQueryDto>> {
        public Guid? ClothesId { get; set; }
        public Guid? FabricId { get; set; }
    }

    public class GetClothesFabricsQueryHandler : IRequestHandler<GetClothesFabricsQuery, IList<GetClothesFabricsQueryDto>> {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetClothesFabricsQueryHandler(
            IApplicationDbContext context,
            IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IList<GetClothesFabricsQueryDto>> Handle(GetClothesFabricsQuery request, CancellationToken cancellationToken) {
            if (request.ClothesId.HasValue) {
                return await _context.ClothesFabrics
                    .Where(c => c.ClothesId == request.ClothesId.Value)
                    .ProjectTo<GetClothesFabricsQueryDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken)
                    .ConfigureAwait(false);
            }

            if (request.FabricId.HasValue) {
                return await _context.ClothesFabrics
                    .Where(c => c.FabricId == request.FabricId.Value)
                    .ProjectTo<GetClothesFabricsQueryDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken)
                    .ConfigureAwait(false);
            }

            return await _context.ClothesFabrics
                    .ProjectTo<GetClothesFabricsQueryDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken)
                    .ConfigureAwait(false);
        }
    }
}
