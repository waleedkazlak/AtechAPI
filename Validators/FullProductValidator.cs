using AtechAPI.Models.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtechAPI.Validators
{
    public class FullProductValidator : AbstractValidator<ProductDTOv2>
    {
        public FullProductValidator()
        {
           
            RuleFor(x => x.Name).NotEmpty().WithMessage($"{nameof(ProductDTOv1.Name)} is required.");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage($"{nameof(ProductDTOv1.Price)} is must be greater than zero.");
        }
        
    }
}
