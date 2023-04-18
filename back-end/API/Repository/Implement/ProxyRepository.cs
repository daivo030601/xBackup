using AutoMapper;
using back_end.Data;
using back_end.Models;
using Microsoft.EntityFrameworkCore;
using back_end.Repository;

namespace back_end.Repository.Implement
{
    public class ProxyRepository : IProxy
    {
        private ApplicationDBContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IFileService _uploadService;

        public ProxyRepository(ApplicationDBContext context, IMapper mapper, IFileService fileService)
        {
            _dbContext = context;
            _mapper = mapper;
            _uploadService = fileService;
        }

        public async Task AddProxy(ProxyModel proxy, bool isUsed, int idServer)
        {
            if (isUsed)
            {
                var newProxy = _mapper.Map<Proxy>(proxy);
                newProxy.ServerId = idServer;
                _dbContext.proxys.Add(newProxy);
                await _dbContext.SaveChangesAsync();

            }
            else
            {
                var newProxy = new Proxy(idServer);
                _dbContext.proxys.Add(newProxy);
                await _dbContext.SaveChangesAsync();
            }
        }

        public Task DeleteProxy(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Proxy> GetProxyById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateProxy(ProxyModel proxy, Boolean isUsed, int idServer)
        {
            var dbTable = await _dbContext.proxys.Where(p => p.ServerId.Equals(idServer)).FirstOrDefaultAsync();
            var id = 0;
            if (dbTable != null)
            {
                id = dbTable.Id;
                if (isUsed)
                {
                    dbTable.Port = proxy.Port == null ? dbTable.Port : proxy.Port;
                    dbTable.HostName = String.IsNullOrEmpty(proxy.HostName) ? dbTable.HostName : proxy.HostName;
                    dbTable.IsSocks5 = proxy.IsSocks5;
                    dbTable.IsWithIdentityFile = proxy.IsWithIdentityFile;
                    dbTable.IsWithPass = proxy.IsWithPass;
                    dbTable.SshPassword = String.IsNullOrEmpty(proxy.SshPassword) ? dbTable.SshPassword : proxy.SshPassword;
                    dbTable.SshUserName = String.IsNullOrEmpty(proxy.SshUserName) ? dbTable.SshPassword : proxy.SshPassword;
                    await _dbContext.SaveChangesAsync();
                }
                else
                {
                    dbTable.Port = 0;
                    dbTable.HostName = null;
                    dbTable.IsSocks5 = false;
                    dbTable.IsWithIdentityFile = false;
                    dbTable.IsWithPass = false;
                    dbTable.SshPassword = null;
                    dbTable.SshUserName = null;
                    await _dbContext.SaveChangesAsync();
                }
            }
            
        }
    }
}
