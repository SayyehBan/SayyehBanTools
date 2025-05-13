using Microsoft.AspNetCore.Http;

/// <summary>
/// این کلاس برای مدیریت فایل ها استفاده میشود
/// </summary>
public class ManageFiles
{
    /// <summary>
    /// کلاس مدیریت حذف فایل
    /// </summary>
    /// <param name="baseFilePath"></param>
    /// <returns></returns>
    public static void DeleteFileServer(string baseFilePath)
    {
        // بررسی وجود فایل قبلی و حذف آن
        if (File.Exists(baseFilePath))
        {
            File.Delete(baseFilePath);
        }
    }
    /// <summary>
    /// کلاس مدیریت آپلود فایل به صورت async
    /// </summary>
    /// <param name="basePath"></param>
    /// <param name="file"></param>
    /// <returns></returns>
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