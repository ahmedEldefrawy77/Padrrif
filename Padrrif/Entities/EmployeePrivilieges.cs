using Padrrif.Entities;

namespace Padrrif;

public class EmployeePrivilieges : BaseEntity
{
    public Guid EmployeeId {  get; set; }
    public User? User { get; set; }
    public Guid PrivliegeId {  get; set; }
    public Priviliege? Priviliege { get; set; }

}
