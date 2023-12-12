namespace csharp_docker_postgree_api.Interfaces
{
    public interface IAuthRepository
    {
        string GerarTokenJwt(dynamic user, string userType);
    }
}
