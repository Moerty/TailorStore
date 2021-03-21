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

namespace TailorStore.Application.ClothesOption.Queries.GetClothesOptionsQuery {
    public class GetClothesOptionsQuery : IRequest<IList<GetClothesOptionsQueryDto>> {
        public Guid? ClothesId { get; set; }
        public Guid? OptionID { get; set; }
    }

    public class GetClothesOptionsQueryHandler : IRequestHandler<GetClothesOptionsQuery, IList<GetClothesOptionsQueryDto>> {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetClothesOptionsQueryHandler(
            IApplicationDbContext context,
            IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IList<GetClothesOptionsQueryDto>> Handle(GetClothesOptionsQuery request, CancellationToken cancellationToken) {
            if(request.ClothesId.HasValue) {
                return await _context.ClothesOptions
                    .Where(c => c.ClothesId == request.ClothesId.Value)
                    .ProjectTo<GetClothesOptionsQueryDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken)
                    .ConfigureAwait(false);
            }

            if(request.OptionID.HasValue) {
                return await _context.ClothesOptions
                    .Where(c => c.OptionId == request.OptionID.Value)
                    .ProjectTo<GetClothesOptionsQueryDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken)
                    .ConfigureAwait(false);
            }

            return await _context.ClothesOptions
                    .ProjectTo<GetClothesOptionsQueryDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken)
                    .ConfigureAwait(false);
        }
    }
}
