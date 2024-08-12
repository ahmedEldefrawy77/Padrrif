namespace Padrrif;
public class User : BaseEntity
{
    public string Name { get; set; } = null!;
    public string? FatherName { get; set; }
    public string? GrandFather { get; set; }
    public string? FamilyFather { get; set; }
    public string? NameInEnglish { get; set; }
    public string? Section { get; set; }
    public string? PublicGovernment { get; set; }
    public string? Unit { get; set; }
    public string? JobTitle { get; set; }
    public string? JobNo { get; set; }
    public string? Salary { get; set; }
    public string? BankName { get; set; }
    public string? IBAN { get; set; }
    public DateTime? WorkStartedIn { get; set; }
    public string? EmployeeNumberOnHoursDevice { get; set; }
    public int IdentityNumber { get; set; }
    public Guid GovernorateId { get; set; }
    public string? City { get; set; }
    public SexEnum Sex { get; set; }
    public string MobilePhoneNumber { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string Email { get; set; } = null!;
    public DateTime BirthDate { get; set; }
   
    [JsonIgnore]
    public string Password { get; set; } = null!;
  
    public RoleEnum Role { get; set; } = RoleEnum.Farmer;
    public string ImagePath { get; set; } = null!;
    public string SignaturePath { get; set; } = null!;
    public List<string> DocumentsPaths { get; set; } = null!;
    
    [JsonIgnore]
    public bool IsConfirmed { get; set; } = false;
    public virtual Governorate Governorate { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<Notifaction>? Notifactions { get; set; }
    
    public virtual Comitee? Comittee { get; set; }
    public Guid? ComiteeId { get; set; }
    [JsonIgnore]
    public ICollection<Damage>? Damages { get; set; }

    public virtual ICollection<EmployeePrivilieges>? EmployeePrivilieges { get; set;}
}

