using back_end.Data;
using back_end.Models;

namespace back_end.Repository
{
    public interface IServer
    {
        public Task AddServer(InputServerModel server, GeneralModel general, AuthenticationModel auth, ProxyModel proxy);
        public Task UpdateServer(InputServerModel server, GeneralModel general, AuthenticationModel auth, ProxyModel proxy);
        public Task<int> DeleteServer(int id);
        public Task<Server> GetServer(int id);
        public Task<List<InputServerModel>> GetServers();
    }
}
