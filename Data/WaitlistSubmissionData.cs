namespace Bylines.LandingPage.Data;

public record WaitlistSubmissionData
{
	public int    Id          { get; set; }
	public string Name        { get; set; }
	public string Email       { get; set; }
	public string PhoneNumber { get; set; }
	public bool   IsGroup     { get; set; }
}