using System.Linq;
using FluentValidation;

namespace Bylines.LandingPage.Data;

internal sealed class WaitlistFormValidator : AbstractValidator<WaitlistForm>
{
	public WaitlistFormValidator()
	{
		RuleFor(d => d.Name)
		   .Cascade(CascadeMode.Stop)
		   .NotEmpty().WithMessage("Please enter your name")
		   .Must(BeAValidName).WithMessage("Invalid Name");
		RuleFor(d => d.Email)
		   .Cascade(CascadeMode.Stop)
		   .NotEmpty().WithMessage("Please enter your email")
		   .EmailAddress().WithMessage("Not a valid email")
		   .Must(BeAValidDomain).WithMessage("Not A Valid Email Domain")
		   .Must(BeAValidEmail).WithMessage("Email contains invalid characters");
		RuleFor(d => d.PhoneNumber)
		   .Cascade(CascadeMode.Stop)
		   .NotEmpty().WithMessage("Please enter your phone number")
		   .MinimumLength(10).WithMessage("Phone Number is too short")
		   .MaximumLength(25).WithMessage("Phone Number is too long")
		   .Must(BeAValidPhoneNumber).WithMessage("			Phone Number is invalid");
	}

	bool BeAValidName(string name)
	{
		name = name.Replace(" ", "");
		name = name.Replace("-", "");
		return name.All(char.IsLetter);
	}

	bool BeAValidEmail(string email)
	{
		email = email.Replace("@", "");
		email = email.Replace(".", "");
		return email.All(char.IsLetterOrDigit);
	}

	bool BeAValidPhoneNumber(string phoneNumber)
	{
		phoneNumber = phoneNumber.Replace(" ", "")
								 .Replace("-", "")
								 .Replace("(", "")
								 .Replace(")", "")
								 .Replace("+", "");

		return phoneNumber.All(char.IsDigit) && phoneNumber.Length <= 15;
	}

	//TODO: Check for valid domain extensions: https://data.iana.org/TLD/tlds-alpha-by-domain.txt
	bool BeAValidDomain(string email)
	{
		return email.Contains('.');
	}
}