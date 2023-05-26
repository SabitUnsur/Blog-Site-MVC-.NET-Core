using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator() 
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Category Name can't be empty!");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Category Description can't be empty!");
            RuleFor(x => x.CategoryName).MaximumLength(50).WithMessage("Category Name must be less than 50 characters!");

        
        }

    }
}
