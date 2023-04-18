using back_end.Data;
using back_end.Models;

namespace back_end.Repository
{
    public interface IProxy
    {
        public Task<Proxy> GetProxyById(int id);
        public Task AddProxy(ProxyModel proxy, Boolean isUsed , int idServer);
        public Task UpdateProxy(ProxyModel proxy, Boolean isUsed, int id);

        public Task DeleteProxy(int id);
    }
}
