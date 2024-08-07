using Microsoft.AspNetCore.Http;

namespace SayyehBanTools.ManageFile;

public class FileUploader
{
    public static async Task<string> UploadFileAsync(string basePath, IFormFile file)
    {
        string fileName = file.FileName;
        // ترکیب مسیر کامل فایل
        var fullPath = Path.Combine(basePath, fileName);

        // بررسی وجود فایل قبلی و حذف آن
        if (System.IO.File.Exists(fullPath))
        {
            System.IO.File.Delete(fullPath);
        }

        // ایجاد دایرکتوری مقصد در صورت عدم وجود
        Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

        // ایجاد نام فایل جدید با GUID
        var newFileName = Guid.NewGuid().ToString() + Path.GetExtension(fileName);
        var newFullPath = Path.Combine(basePath, newFileName);

        // کپی کردن فایل به مکان جدید
        using (var stream = new FileStream(newFullPath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        return newFullPath;
    }
}
