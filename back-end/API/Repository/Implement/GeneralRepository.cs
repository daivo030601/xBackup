using AutoMapper;
using back_end.Data;
using back_end.Models;
using back_end.Repository;
using Microsoft.EntityFrameworkCore;

namespace back_end.Repository.Implement
{
    public class GeneralRepository : IGeneral
    {
        private ApplicationDBContext _dbContext;
        private readonly IMapper _mapper;

        public GeneralRepository(ApplicationDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task AddGeneral(GeneralModel general, int idServer)
        {
            var newGeneral = _mapper.Map<General>(general);
            newGeneral.ServerId = idServer;
            _dbContext.generals.Add(newGeneral);
            await _dbContext.SaveChangesAsync();
        }

        public Task DeleteGeneral(int id)
        {
            throw new NotImplementedException();
        }

        public Task<General> GetGeneralById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateGeneral(GeneralModel general, int idServer)
        {
            var dbTable = await _dbContext.generals.Where(p => p.ServerId.Equals(idServer)).FirstOrDefaultAsync();
            if (dbTable != null)
            {
                dbTable.IsDirectConnection = general.IsDirectConnection;
                dbTable.IsIncludeSrv = general.IsIncludeSrv;
                dbTable.Host = String.IsNullOrEmpty(general.Host) ? dbTable.Host : general.Host;
            }
            await _dbContext.SaveChangesAsync();
        }
    }
}
