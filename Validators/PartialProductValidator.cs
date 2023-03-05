using AtechAPI.Models.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtechAPI.Validators
{
    public class PartialProductValidator : AbstractValidator<ProductDTOPartialv2>
    {
        public PartialProductValidator()
        {
            RuleFor(x => x.Price).GreaterThan(0).WithMessage($"{nameof(ProductDTOv2.Price)} is must be greater than zero.");
        }
    }
}
