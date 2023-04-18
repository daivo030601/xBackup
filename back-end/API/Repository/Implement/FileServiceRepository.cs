using back_end.Data;
using back_end.Repository;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;

namespace back_end.Repository.Implement
{
    public class FileServiceRepository : IFileService
    {
        private readonly ApplicationDBContext _context;

        public FileServiceRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task PostFileAsync(IFormFile fileData)
        {
            try
            {
                var fileDetails = new FileDetails()
                {
                    FileName = fileData.FileName,
                    ProxyId = 1
                };
                using (var stream = new MemoryStream())
                {
                    fileData.CopyTo(stream);
                    fileDetails.FileData = stream.ToArray();
                }

                var result = _context.fileDetails.Add(fileDetails);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DownloadFileById(int Id)
        {
            try
            {
                var file = await _context.fileDetails.Where(x => x.Id == Id).FirstOrDefaultAsync();

                var content = new MemoryStream(file.FileData);
                var path = Path.Combine(
                    Directory.GetCurrentDirectory(), "FileDownloaded",
                    file.FileName);

                await CopyStream(content, path);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task CopyStream(Stream stream, string downloadPath)
        {
            using (var fileStream = new FileStream(downloadPath, FileMode.Create, FileAccess.Write))
            {
                await stream.CopyToAsync(fileStream);
            }
        }
    }
}
