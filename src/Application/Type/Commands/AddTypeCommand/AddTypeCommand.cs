using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TailorStore.Application.Common.Interfaces;

namespace TailorStore.Application.Type.Commands.AddTypeCommand {
    public class AddTypeCommand : IRequest<bool> {
        public string Name { get; set; }
    }

    public class AddTypeCommandHandler : IRequestHandler<AddTypeCommand, bool> {
        private readonly IApplicationDbContext _context;

        public AddTypeCommandHandler(IApplicationDbContext context) {
            _context = context;
        }

        public async Task<bool> Handle(AddTypeCommand request, CancellationToken cancellationToken) {
            var entity = new Domain.Entities.Type {
                Name = request.Name
            };

            await _context.Types
                .AddAsync(entity, cancellationToken)
                .ConfigureAwait(false);

            return await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false) >= 0;
        }
    }
}
