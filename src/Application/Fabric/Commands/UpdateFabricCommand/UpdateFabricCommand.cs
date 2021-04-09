using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TailorStore.Application.Common.Interfaces;

namespace TailorStore.Application.Fabric.Commands.UpdateFabricCommand
{
    public class UpdateFabricCommand : IRequest<bool>
    {
        public Guid Fabricid { get; set; }

#nullable enable
        public string? FabricName { get; set; }
        public IFormFile? Picture { get; set; }
#nullable disable
    }

    public class UpdateFabricCommandHandler : IRequestHandler<UpdateFabricCommand, bool> {
        private readonly IApplicationDbContext _context;

        public UpdateFabricCommandHandler(IApplicationDbContext context) {
            _context = context;
        }

        public async Task<bool> Handle(UpdateFabricCommand request, CancellationToken cancellationToken) {
            var entity = await _context.Fabrics
                .FirstOrDefaultAsync(f => f.Id == request.Fabricid, cancellationToken)
                .ConfigureAwait(false);

            if(!string.IsNullOrEmpty(request.FabricName)) {
                entity.Name = request.FabricName;
            }

            if(request.Picture.Length > 0) {
                // implement picture
            }

            return await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false) > 0;
        }
    }
}
