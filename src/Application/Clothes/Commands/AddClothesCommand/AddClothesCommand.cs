using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TailorStore.Application.Common.Interfaces;

namespace TailorStore.Application.Clothes.Commands.AddClothesCommand {
    public class AddClothesCommand : IRequest<bool> {
        public string Name { get; set; }
        public string Picture { get; set; }
    }

    public class AddClothesCommandHandler : IRequestHandler<AddClothesCommand, bool> {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService;

        public AddClothesCommandHandler(
            IApplicationDbContext context,
            ICurrentUserService currentUserService) {
            _context = context;
            _currentUserService = currentUserService;
        }

        public async Task<bool> Handle(AddClothesCommand request, CancellationToken cancellationToken) {
            var entity = new Domain.Entities.Clothes {
                Name = request.Name,
                Picture = request.Picture,
                ApplicationUserId = Guid.Parse(_currentUserService.UserId)
            };

            await _context.Clothes
                .AddAsync(entity, cancellationToken)
                .ConfigureAwait(false);

            return await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false) > 0;
        }
    }
}
