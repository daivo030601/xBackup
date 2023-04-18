using AutoMapper;
using back_end.Data;
using back_end.Models;
using Microsoft.AspNetCore.Hosting.Server;
using back_end.Repository;
using Microsoft.EntityFrameworkCore;

namespace back_end.Repository.Implement
{

    public class ServerRepository : IServer
    {
        private ApplicationDBContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IAuthentication _authentication;
        private readonly IGeneral _general;
        private readonly IProxy _proxy;

        public ServerRepository(ApplicationDBContext context, IMapper iMapper, IAuthentication auth, IGeneral general, IProxy proxy)
        {
            _dbContext = context;
            _mapper = iMapper;
            _authentication = auth;
            _general = general;
            _proxy = proxy;
        }

        public async Task<Server> GetServer(int id)
        {
            return await _dbContext.servers
                        .Include(p => p.General)
                        .Include(p => p.Proxy)
                        .Include(p => p.Authentication)
                        .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<InputServerModel>> GetServers()
        {
            var servers = await _dbContext.servers.ToListAsync();
            return _mapper.Map<List<InputServerModel>>(servers);
        }


        public async Task AddServer(InputServerModel server, GeneralModel general, AuthenticationModel auth, ProxyModel proxy)
        {
            var newServer = _mapper.Map<Server>(server);
            _dbContext.servers.Add(newServer);
            await _dbContext.SaveChangesAsync();

            await _general.AddGeneral(general, newServer.Id);
            await _authentication.AddAuthentication(auth, newServer.IsUseAuthentication, newServer.Id);
            await _proxy.AddProxy(proxy, newServer.IsUseProxy, newServer.Id);
        }

        public async Task UpdateServer(InputServerModel server, GeneralModel general, AuthenticationModel auth, ProxyModel proxy)
        {
            var dbTable = await _dbContext.servers.Where(p => p.Id.Equals(server.Id)).FirstOrDefaultAsync();
            if (dbTable != null)
            {
                dbTable = _mapper.Map<Server>(server);
                await _general.UpdateGeneral(general, server.Id);
                await _authentication.UpdateAuthentication(auth, server.IsUseAuthentication, server.Id);
                await _proxy.UpdateProxy(proxy, server.IsUseProxy, server.Id);
            }
            await _dbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteServer(int id)
        {
            try
            {
                var dbTable = await _dbContext.servers.Where(p => p.Id.Equals(id)).FirstOrDefaultAsync();
                if (dbTable != null)
                {
                    _dbContext.servers.Remove(dbTable);
                    await _dbContext.SaveChangesAsync();
                    return dbTable.Id;
                }
                return 0;
            } catch (Exception ex) 
            {
                throw ex;
            }
        }
    }
}
