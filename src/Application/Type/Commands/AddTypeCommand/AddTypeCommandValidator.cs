using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TailorStore.Application.Common.Interfaces;

namespace TailorStore.Application.Type.Commands.AddTypeCommand
{
    public class AddTypeCommandValidator : AbstractValidator<AddTypeCommand>
    {
        private readonly IApplicationDbContext _context;

        public AddTypeCommandValidator(IApplicationDbContext context) {
            _context = context;

            RuleFor(v => v.Name)
                .NotNull()
                .NotEmpty()
                .MustAsync(NameMustNotExists);
        }

        private async Task<bool> NameMustNotExists(string name, CancellationToken cancellationToken) {
            return ! await _context.Types
                .AnyAsync(t => t.Name == name, cancellationToken)
                .ConfigureAwait(false);
        }
    }
}
