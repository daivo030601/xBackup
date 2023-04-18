using back_end.Data;
using back_end.Models;

namespace back_end.Repository
{
    public interface IGeneral
    {
        public Task<General> GetGeneralById(int id);
        public Task AddGeneral(GeneralModel general, int idServer);
        public Task UpdateGeneral(GeneralModel general, int id);
        public Task DeleteGeneral(int id);
    }
}
