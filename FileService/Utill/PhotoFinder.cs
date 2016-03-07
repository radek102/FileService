using FileService.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace FileService.Utill
{
    public class PhotoFinder
    {
        private FileFinder fileFinder;
        private String[] photoExtensions;

        public PhotoFinder(FileFinder fileFinder)
        {
            this.fileFinder = fileFinder;
            this.photoExtensions = new String[] { "jpg", "jpeg", "png", "bmp" };
        }

        public List<PhotoFile> findPhotosInDirectory(String directory)
        {
            FileInfo[] files = fileFinder.findFiles(directory);
            List<PhotoFile> photos = new List<PhotoFile>();

            foreach(FileInfo file in files)
            {
                if (hasPhotoExtension(file.Name))
                    photos.Add(new PhotoFile(file));
            }
            return photos;
        }

        private bool hasPhotoExtension(String filename)
        {
            String extension = getExtensionFromFileName(filename);
            foreach (String validExtension in photoExtensions)
            {
                if (validExtension.CompareTo(extension) == 0)
                    return true;
            }
            return false;
        }

        private String getExtensionFromFileName(String filename)
        {
            int indexOfDot = filename.IndexOf(".");
            return filename.Substring(1+indexOfDot);
        }
    }
}