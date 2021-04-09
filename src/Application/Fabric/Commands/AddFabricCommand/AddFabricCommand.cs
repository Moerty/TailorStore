using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TailorStore.Application.Common.Interfaces;

namespace TailorStore.Application.Fabric.Commands.AddFabricCommand {
    public class AddFabricCommand : IRequest<bool> {
        public string Name { get; set; }
        public IFormFile Picture { get; set; }
    }

    public class AddFabricCommandHandler : IRequestHandler<AddFabricCommand, bool> {
        private readonly IApplicationDbContext _context;

        public AddFabricCommandHandler(IApplicationDbContext context) {
            _context = context;
        }

        public async Task<bool> Handle(AddFabricCommand request, CancellationToken cancellationToken) {
            var entity = new Domain.Entities.Fabric {
                Name = request.Name
            };

            await _context.Fabrics
                .AddAsync(entity, cancellationToken)
                .ConfigureAwait(false);

            return await _context
                .SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false) > 0;
        }
    }
}
