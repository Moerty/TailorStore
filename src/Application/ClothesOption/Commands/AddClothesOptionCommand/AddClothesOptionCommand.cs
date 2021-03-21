using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TailorStore.Application.Common.Interfaces;

namespace TailorStore.Application.ClothesOption.Commands.AddClothesOptionCommand
{
    public class AddClothesOptionCommand : IRequest<bool> {
        public Guid ClothesId { get; set; }
        public Guid OptionId { get; set; }
        public string SKU { get; set; }
    }

    public class AddClothesFabricCommandHandler : IRequestHandler<AddClothesOptionCommand, bool> {
        private readonly IApplicationDbContext _context;

        public AddClothesFabricCommandHandler(IApplicationDbContext context) {
            _context = context;
        }

        public async Task<bool> Handle(AddClothesOptionCommand request, CancellationToken cancellationToken) {
            var entity = new Domain.Entities.ClothesOption {
                OptionId = request.OptionId,
                ClothesId = request.ClothesId,
                SKU = request.SKU
            };

            await _context.ClothesOptions
                .AddAsync(entity, cancellationToken)
                .ConfigureAwait(false);

            return await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false) > 0;
        }
    }
}
