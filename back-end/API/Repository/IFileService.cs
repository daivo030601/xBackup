using back_end.Data;
using Microsoft.VisualBasic.FileIO;

namespace back_end.Repository
{
    public interface IFileService
    {
        public Task PostFileAsync(IFormFile fileData);
        public Task DownloadFileById(int fileName);
    }
}
