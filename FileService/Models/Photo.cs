using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace FileService.Models
{
    [Serializable]
    public class PhotoFile
    {
        public String id;
        public string fileName;
        public string fullPath;

        public PhotoFile(FileInfo file)
        {
            this.id = file.Directory.Name;
            this.fileName = file.Name;
            this.fullPath = file.FullName;
        }
    }
}