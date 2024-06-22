using Padrrif.Entities;

namespace Padrrif.Authorization
{
    public class PrivilegeRequirement : IAuthorizationRequirement
    {
        public IEnumerable<string> Priviliege { get; set; }

        public PrivilegeRequirement(IEnumerable<string> priviliege)
        {
            Priviliege = priviliege;
        }
    }
}
