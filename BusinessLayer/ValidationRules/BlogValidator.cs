using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class BlogValidator : AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("You must enter a title ");
            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("You must enter a content ");
            RuleFor(x => x.BlogImage).NotEmpty().WithMessage("You must upload an image ");
            RuleFor(x => x.BlogTitle).MaximumLength(150).WithMessage("Must be less than 150 character");
            RuleFor(x => x.BlogTitle).MinimumLength(5).WithMessage("Must be less than 5 character");
        }
    }
}
