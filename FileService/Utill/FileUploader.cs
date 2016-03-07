using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace FileService.Utill
{
    public class FileUploader
    {
        private FileFinder fileFinder;
        public FileUploader(FileFinder fileFinder)
        {
            this.fileFinder = fileFinder;
        }
        public void saveFileFromRequest(String baseDirectory, String fileId, HttpRequest request)
        {
            if (isIdValid(fileId))
            {
                string filename = request.Headers["filename"];
                string filePath = fileFinder.buildPath(baseDirectory, fileId, filename);
                Directory.CreateDirectory(fileFinder.buildPath(baseDirectory, fileId));
                using (var fs = new FileStream(filePath, FileMode.Create))
                {
                    request.InputStream.CopyTo(fs);
                }
            }
            else
            {
                throw new ArgumentException("Id is not valid. Must be valid UUID.");
            }
        }
        private bool isIdValid(String id)
        {
            Guid guuid;
            return Guid.TryParse(id, out guuid);
        }
    }
}