using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TailorStore.Application.Common.Interfaces;

namespace TailorStore.Application.Option.Commands.AddOptionCommand {
    public class AddOptionCommand : IRequest<bool> {
        public Guid TypeId { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
    }

    public class AddOptionCommandHandler : IRequestHandler<AddOptionCommand, bool> {
        private readonly IApplicationDbContext _context;

        public AddOptionCommandHandler(IApplicationDbContext context) {
            _context = context;
        }

        public async Task<bool> Handle(AddOptionCommand request, CancellationToken cancellationToken) {
            var entity = new Domain.Entities.Option {
                Name = request.Name,
                TypeId = request.TypeId,
                Picture = request.Picture
            };

            await _context.Options
                .AddAsync(entity, cancellationToken)
                .ConfigureAwait(false);

            return await _context
                .SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false) > 0;
        }
    }
}
