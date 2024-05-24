using Indigo.Business.Exceptions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indigo.Business.Exentions;

public static class Helper
{
    public static string SaveFile(string rootPath, string folder, IFormFile file)
    {
        if (!file.ContentType.Contains("image/"))
            throw new FileContentTypeException("Image type is not valid");
        if (file.Length > 2097152)
            throw new FileSizeNotException("Image size is not valid");

        string extension = Path.GetExtension(file.FileName);
        string fileName = $"events-{Guid.NewGuid().ToString().ToLower()}{extension}";
        string path = rootPath + @$"\{folder}\" + fileName;

        using (FileStream stream = new FileStream(path, FileMode.Create))
        {
            file.CopyTo(stream);
        }

        return fileName;
    }

    public static void DeleteFile(string rootPath, string folder, string fileName)
    {
        string path = rootPath + @$"\{folder}\" + fileName;

        if (!File.Exists(path))
            throw new EntityNotFoundException("File not found");
        File.Delete(path);


    }
}