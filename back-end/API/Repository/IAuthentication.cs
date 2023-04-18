using back_end.Data;
using back_end.Models;
using back_end.Repository.Implement;

namespace back_end.Repository
{
    public interface IAuthentication
    {
        public Task<AuthenticationRepository> GetAuthenticationById(int id);
        public Task AddAuthentication(AuthenticationModel auth, Boolean isUsed, int idServer);
        public Task UpdateAuthentication(AuthenticationModel auth, Boolean isUsed, int id);
        public Task DeleteAuthentication(int id);
    }
}
