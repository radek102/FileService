using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;


namespace FileService.Utill
{
    public class FileFinder
    {
        public FileInfo[] findFiles(String directory)
        {
            DirectoryInfo baseDirectoryInfo = new DirectoryInfo(buildPath(directory));
            return baseDirectoryInfo.GetFiles();
        }
        public DirectoryInfo[] findDirectoriesInBaseDirectory(String baseDirectory)
        {
            DirectoryInfo baseDirectoryInfo = new DirectoryInfo(buildPath(baseDirectory));
            return baseDirectoryInfo.GetDirectories();
        }
        public String buildPath(params String[] parameters)
        {
            StringBuilder builder = new StringBuilder();
            bool first = true;
            foreach(String param in parameters)
            {
                if (!first)
                    builder.Append("/");
                first = false;
                builder.Append(param);
                
            }
            String path = builder.ToString();
            return HttpContext.Current.Server.MapPath(path);
        }
    }
}