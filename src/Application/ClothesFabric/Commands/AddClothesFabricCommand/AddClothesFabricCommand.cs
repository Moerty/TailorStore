using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TailorStore.Application.Common.Interfaces;

namespace TailorStore.Application.ClothesFabric.Commands.AddClothesFabricCommand {
    public class AddClothesFabricCommand : IRequest<bool> {
        public Guid ClothesId { get; set; }
        public Guid FabricId { get; set; }
    }

    public class AddClothesFabricCommandHandler : IRequestHandler<AddClothesFabricCommand, bool> {
        private readonly IApplicationDbContext _context;

        public AddClothesFabricCommandHandler(IApplicationDbContext context) {
            _context = context;
        }

        public async Task<bool> Handle(AddClothesFabricCommand request, CancellationToken cancellationToken) {
            var entity = new Domain.Entities.ClothesFabric {
                FabricId = request.FabricId,
                ClothesId = request.ClothesId
            };

            await _context.ClothesFabrics
                .AddAsync(entity, cancellationToken)
                .ConfigureAwait(false);

            return await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false) > 0;
        }
    }
}
