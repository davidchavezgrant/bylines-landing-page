using System;
using System.Linq;
using FluentValidation;
namespace Bylines.LandingPage.Data;

sealed class WaitlistDataValidator : AbstractValidator<WaitlistSubmissionData>
{
	public WaitlistDataValidator()
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
		   .Must(BeAValidPhoneNumber).WithMessage("Phone Number is invalid");
	}

	protected bool BeAValidName(string name)
	{
		name = name.Replace(" ", "");
		name = name.Replace("-", "");
		return name.All(Char.IsLetter);
	}

	protected bool BeAValidEmail(string email)
	{
		email = email.Replace("@", "");
		email = email.Replace(".", "");
		return email.All(Char.IsLetterOrDigit);
	}

	protected bool BeAValidPhoneNumber(string phoneNumber)
	{
		phoneNumber = phoneNumber.Replace(" ", "");
		phoneNumber = phoneNumber.Replace("-", "");
		phoneNumber = phoneNumber.Replace("(", "");
		phoneNumber = phoneNumber.Replace(")", "");
		phoneNumber = phoneNumber.Replace("+", "");
		return phoneNumber.All(Char.IsDigit);
	}

	//TODO: Check for valid domain extensions: https://data.iana.org/TLD/tlds-alpha-by-domain.txt
	protected bool BeAValidDomain(string email)
	{
		return email.Contains('.');
	}

}