namespace Padrrif.Entities
{
    public class Priviliege : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public virtual ICollection<EmployeePrivilieges>? EmployeePrivilieges { get; set; }
        
    }
}
