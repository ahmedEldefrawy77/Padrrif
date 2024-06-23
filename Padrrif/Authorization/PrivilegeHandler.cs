namespace Padrrif.Authorization
{
    public class PrivilegeHandler : AuthorizationHandler<PrivilegeRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PrivilegeRequirement requirement)
        {
            var userPrivileges = context.User.Claims
                .Where(c => c.Type == "Privilege")
                .Select(c => c.Value);

            if (requirement.Priviliege.All(p => userPrivileges.Contains(p)))
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
