using System.Linq;
using FluentValidation;

namespace Bylines.LandingPage.Data;

public record WaitlistForm
{
	private readonly IValidator<WaitlistForm> _validator = new WaitlistFormValidator();

	public   int                   Id          { get; set; }
	public   string                Name        { get; set; } = "";
	public   string                Email       { get; set; } = "";
	public   string                PhoneNumber { get; set; } = "";
	public   bool                  IsGroup     { get; set; }
	public   bool                  IsValid     => _validator.Validate(this).IsValid;
	public   string?               Error       => _validator.Validate(this).Errors.FirstOrDefault()?.ErrorMessage;
}