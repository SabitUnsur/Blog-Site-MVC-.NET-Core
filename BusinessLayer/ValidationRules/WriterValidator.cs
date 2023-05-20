using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
	public class WriterValidator:AbstractValidator<Writer>
	{
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("This part must not be empty! ");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("This part must not be empty! ");
			RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Şifre Boş Geçilemez")
				 .MinimumLength(8).WithMessage("Password must be higher than 8 characters.")
				 .MaximumLength(16).WithMessage("Password must be smaller than 16 characters.")
				 .Matches(@"[A-Z]+").WithMessage("Password must have at least 1 Upper-Case character.")
				 .Matches(@"[a-z]+").WithMessage("Password must have at least 1 Lower-Case character.")
				 .Matches(@"[0-9]+").WithMessage("Password must have min one number");

			RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Please entry min 2 characters");
			RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("Please entry max 50 characters");
            RuleFor(x => x.ConfirmWriterPassword).NotEmpty().WithMessage("Confirm Password is required.") // Şifre onaylama alanının boş olmaması gerektiği kuralları
            .Equal(x => x.WriterPassword).WithMessage("Passwords do not match."); // Şifre onaylama alanının, şifre alanı ile aynı olması gerektiği kuralları
        }

    }
    
}
