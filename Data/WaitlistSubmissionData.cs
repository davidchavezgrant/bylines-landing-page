using System.Linq;
using FluentValidation;
using FluentValidation.Results;

namespace Bylines.LandingPage.Data;

public record WaitlistSubmissionData
{
	WaitlistDataValidator _validator = new();
	public int            Id          { get; set; }
	public string         Name        { get; set; }
	public string         Email       { get; set; }
	public string         PhoneNumber { get; set; }
	public bool           IsGroup     { get; set; }
	public bool           IsValid     => this._validator.Validate(this).IsValid;
	public string? Error      => this._validator.Validate(this).Errors.FirstOrDefault()?.ErrorMessage;
}