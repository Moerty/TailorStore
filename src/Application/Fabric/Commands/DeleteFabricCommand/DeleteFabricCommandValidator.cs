using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TailorStore.Application.Common.Interfaces;

namespace TailorStore.Application.Fabric.Commands.DeleteFabricCommand
{
    public class DeleteFabricCommandValidator : AbstractValidator<DeleteFabricCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteFabricCommandValidator(IApplicationDbContext context) {
            _context = context;

            RuleFor(v => v.FabricId)
                .NotNull().WithMessage("fabric id is required")
                .NotEmpty().WithMessage("fabric id is required")
                .MustAsync(FabricMustExists).WithMessage("fabric id must exists");
        }

        private async Task<bool> FabricMustExists(Guid id, CancellationToken cancellationToken) {
            return await _context.Fabrics
                .AnyAsync(f => f.Id == id, cancellationToken)
                .ConfigureAwait(false);
        }
    }
}
