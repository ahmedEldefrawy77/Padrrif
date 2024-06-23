namespace Padrrif.Dto
{
    public class UserLoginDto
    {
        public string Value { get; set; } = null!;
        public DateTime ExpireAt { get; set; }
        public string Name { get; set; } = null!;
        public int IdentityNumber { get; set; }
        public Guid GovernorateId { get; set; }
        public string? City { get; set; }
        public SexEnum Sex { get; set; }
        public string MobilePhoneNumber { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public string ImagePath { get; set; } = null!;
        public List<string> DocumentsPaths { get; set; } = null!;
        public virtual Governorate Governorate { get; set; } = null!;
        public virtual Comitee? Comittee { get; set; }
    }
}
