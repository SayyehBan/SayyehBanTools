using Microsoft.AspNetCore.Http;
using SayyehBanTools.Converter;
namespace SayyehBanTools.ManageFile;

public class ManageFiles
{
    public static async Task DeleteFileServer(string baseFilePath)
    {
        // بررسی وجود فایل قبلی و حذف آن
        if (File.Exists(baseFilePath))
        {
            File.Delete(baseFilePath);
        }
    }

    public static async Task<string> UploadFileAsync(string basePath, IFormFile file)
    {
        // ترکیب مسیر کامل فایل
        var fullPath = Path.Combine(basePath, file.FileName);
        // ایجاد دایرکتوری مقصد در صورت عدم وجود
        Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

        // ایجاد نام فایل جدید با GUID
        var newFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
        var newFullPath = Path.Combine(basePath, newFileName);

        // کپی کردن فایل به مکان جدید
        using (var stream = new FileStream(newFullPath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }
        var newdirect = StringExtensions.RemoveDirectWWWROOT(newFullPath);
        return newdirect;
    }
}
/*
 طریقه استفاده از دستور

            var basePath = "wwwroot/Uploads/Avatars/";
            await ManageFiles.DeleteFileServer(basePath + "2177d602-d277-46cc-87ef-ade959a2827f.jpg");
            var file = insertContacts.FileName;
            var newFilePath = await ManageFiles.UploadFileAsync(basePath, file);
            insertContacts.Photo = newFilePath;
 * */