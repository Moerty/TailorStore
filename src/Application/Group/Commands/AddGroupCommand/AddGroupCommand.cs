using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TailorStore.Application.Common.Interfaces;

namespace TailorStore.Application.Group.Commands.AddGroupCommand {
    public class AddGroupCommand : IRequest<bool> {
        public string Name { get; set; }
    }

    public class AddGroupCommandHandler : IRequestHandler<AddGroupCommand, bool> {
        private readonly IApplicationDbContext _context;

        public AddGroupCommandHandler(IApplicationDbContext context) {
            _context = context;
        }

        public async Task<bool> Handle(AddGroupCommand request, CancellationToken cancellationToken) {
            var entity = new Domain.Entities.Group {
                Name = request.Name
            };

            await _context.Groups
                .AddAsync(entity, cancellationToken)
                .ConfigureAwait(false);

            return await _context
                .SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false) > 0;
        }
    }
}
