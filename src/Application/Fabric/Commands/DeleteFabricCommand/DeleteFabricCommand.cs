using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TailorStore.Application.Common.Interfaces;

namespace TailorStore.Application.Fabric.Commands.DeleteFabricCommand {
    public class DeleteFabricCommand : IRequest<bool> {
        public Guid FabricId { get; set; }
    }

    public class DeleteFabricCommandHandler : IRequestHandler<DeleteFabricCommand, bool> {
        private readonly IApplicationDbContext _context;

        public DeleteFabricCommandHandler(IApplicationDbContext context) {
            _context = context;
        }

        public async Task<bool> Handle(DeleteFabricCommand request, CancellationToken cancellationToken) {
            var entity = await _context.Fabrics
                .FirstOrDefaultAsync(f => f.Id == request.FabricId, cancellationToken)
                .ConfigureAwait(false);

            _context.Fabrics.Remove(entity);

            return await _context
                .SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false) > 0;
        }
    }
}
