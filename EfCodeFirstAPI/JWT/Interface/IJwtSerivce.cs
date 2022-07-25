using EfCodeFirstAPI.JWT.Model;

namespace EfCodeFirstAPI.JWT.Interface
{
    public interface IJwtSerivce
    {
        Tokens Authenticate(JWTUsers jWTUsers);
    }
}
