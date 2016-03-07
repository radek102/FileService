using FileService.Models;
using FileService.Utill;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Http;

namespace FileService.Controllers
{
    public class PhotosController : ApiController
    {
        private const string BASE_DIRECTORY = @"/Data/"; 
        private PhotoFinder photoFinder;
        private FileFinder fileFinder;
        private FileUploader uploader;

        public PhotosController()
        {
            this.fileFinder = new FileFinder();
            this.photoFinder = new PhotoFinder(fileFinder);
            this.uploader = new FileUploader(fileFinder);
        }

        [HttpGet]
        [ActionName("GetPhotos")]
        public ConfirmationWithList<String> getPhotos()
        {
            try
            {
                DirectoryInfo[] directories = fileFinder.findDirectoriesInBaseDirectory(BASE_DIRECTORY);
                List<String> namesList = new List<string>();
                foreach (DirectoryInfo info in directories)
                {
                    namesList.Add(info.Name);
                }
                return new ConfirmationWithList<string>(true, "Everything ok", namesList);
            }
            catch(DirectoryNotFoundException)
            {
                return new ConfirmationWithList<string>(false, "Directory not found", null);
            }
        }

        [HttpGet]
        [ActionName("GetPhotos")]
        public ConfirmationWithList<PhotoFile> getPhotos(String id)
        {
            try
            {
                List<PhotoFile> list = photoFinder.findPhotosInDirectory(BASE_DIRECTORY + id);
                return new ConfirmationWithList<PhotoFile>(true, "Everything ok", list);
            }
            catch (DirectoryNotFoundException)
            {
                return new ConfirmationWithList<PhotoFile>(false, "There is not such id", null);
            }
        }

        [HttpPost]
        [ActionName("Upload")]
        public Confirmation uploadPhoto(String id)
        {
            try
            {
                HttpRequest request = HttpContext.Current.Request;
                uploader.saveFileFromRequest(BASE_DIRECTORY, id, request);
                return new Confirmation(true, "File uploaded with success");
            }
            catch(ArgumentException ex)
            {
                return new Confirmation(false, ex.Message);
            }
            catch (DirectoryNotFoundException)
            {
                return new Confirmation(false, "Directory not found");
            }
        }

        [HttpGet]
        [ActionName("Delete")]
        public Confirmation deletePhoto(String id, String filename)
        {
            String filePath = fileFinder.buildPath(BASE_DIRECTORY, id, filename);
            if(File.Exists(filePath))
            {
                File.Delete(filePath);
                return new Confirmation(true, "File deleted succesfully");
            }
            else
            {
                return new Confirmation(false, "No file found");
            }
        }

    }
}