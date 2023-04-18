using AutoMapper;
using back_end.Data;
using back_end.Models;
using back_end.Repository;
using Microsoft.EntityFrameworkCore;

namespace back_end.Repository.Implement
{

    public class AuthenticationRepository : IAuthentication
    {
        private ApplicationDBContext _dbContext;
        private readonly IMapper _mapper;

        public AuthenticationRepository(ApplicationDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task AddAuthentication(AuthenticationModel auth, bool isUsed, int idServer)
        {
            if (isUsed)
            {
                var newAuth = _mapper.Map<Authentication>(auth);
                newAuth.ServerId = idServer;
                _dbContext.authentications.Add(newAuth);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                var newAuth = new Authentication(idServer);
                _dbContext.authentications.Add(newAuth);
                await _dbContext.SaveChangesAsync();
            }
        }

        public Task DeleteAuthentication(int id)
        {
            throw new NotImplementedException();
        }

        public Task<AuthenticationRepository> GetAuthenticationById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAuthentication(AuthenticationModel auth, Boolean isUsed, int idServer)
        {
            var dbTable = await _dbContext.authentications.Where(p => p.ServerId.Equals(idServer)).FirstOrDefaultAsync();
            var id = 0;
            if (dbTable != null)
            {
                id = dbTable.Id;
                if (isUsed)
                {
                    dbTable.IsDefault = auth.IsDefault;
                    dbTable.IsSHA1 = auth.IsSHA1;
                    dbTable.IsSHA256 = auth.IsSHA256;
                    dbTable.Password = String.IsNullOrEmpty(auth.Password) ? dbTable.Password : auth.Password;
                    dbTable.Username = String.IsNullOrEmpty(auth.Username) ? dbTable.Username : auth.Username;
                    await _dbContext.SaveChangesAsync();
                }
                else
                {
                    dbTable.IsDefault = false;
                    dbTable.IsSHA1 = false;
                    dbTable.IsSHA256 = false;
                    dbTable.Password = null;
                    dbTable.Username = null;
                    await _dbContext.SaveChangesAsync();
                }
            }
        }
    }
}
