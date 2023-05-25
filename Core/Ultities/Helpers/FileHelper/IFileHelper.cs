using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Ultities.Helpers.FileHelper
{
    public interface IFileHelper
    {
        string Upload(IFormFile file, string root); // file => yüklenecek olan dosyanın kendisidir 
        void Delete(string filePath);
        string Update(IFormFile file, string filePath, string root); // Root => Oluşturulacak dosyanın yolu
    }
}
