namespace Padrrif;

public class EmployeeRegDto 
{
    public string Name { get; set; } = null!;
    public string FatherName { get; set; } = null!;
    public string GrandFather { get; set; } = null!;
    public string FamilyFather { get; set; } = null!;
    public string NameInEnglish { get; set; } = null!;
    public int IdentityNumber { get; set; }
    public Guid GovernorateId { get; set; }
    public string? City { get; set; }
    public SexEnum Sex { get; set; }
    public string MobilePhoneNumber { get; set; } = null!;
    public DateTime? WorkStartedIn { get; set; }
    public string PhoneNumber { get; set; } = null!;
    public string Email { get; set; } = null!;
    public DateTime BirthDate { get; set; }
    public string Password { get; set; } = null!;
    public IFormFile Image { get; set; } = null!;
    public List<IFormFile> Documents { get; set; } = null!;
    public Guid? CommiteeId { get; set; }
    public string? Section { get; set; }
    public string? PublicGovernment { get; set; }
    public string? Unit { get; set; }
    public string? JobTitle { get; set; }
    public string? JobNo { get; set; }
    public string? Salary { get; set; }
    public string? BankName { get; set; }
    public string? IBAN { get; set; }
    public string? EmployeeNumberOnHoursDevice { get; set; }
    public IFormFile SignatureImage { get; set; } = null!;
}