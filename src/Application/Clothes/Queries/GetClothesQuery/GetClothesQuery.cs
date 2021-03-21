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

namespace TailorStore.Application.Clothes.Queries.GetClothesQuery {
    public class GetClothesQuery : IRequest<IList<GetClothesQueryDto>> { }

    public class GetClothesQueryHandler : IRequestHandler<GetClothesQuery, IList<GetClothesQueryDto>> {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetClothesQueryHandler(
            IApplicationDbContext context,
            IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IList<GetClothesQueryDto>> Handle(GetClothesQuery request, CancellationToken cancellationToken) {
            return await _context.Clothes
                .ProjectTo<GetClothesQueryDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);
        }
    }
}
