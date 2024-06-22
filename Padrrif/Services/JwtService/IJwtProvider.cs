using Padrrif.Entities;

namespace Padrrif;

public interface IJwtProvider
{
    string GenrateAccessToken(User user, List<string> privs);

}
