using Microsoft.AspNetCore.Razor.Language;

namespace BookStore.Utills
{
    public static class ImageHandling
    {
        public static string ImageReading(IFormFile ImageFile ) 
        {
            byte[] bytes = null;
            using (Stream fs = ImageFile.OpenReadStream())
            {
                using (BinaryReader br = new BinaryReader(fs))
                {
                    bytes = br.ReadBytes((int)fs.Length);
                }
            }
            return Convert.ToBase64String(bytes, 0, bytes.Length);
        }
        public static string UploadImage(IFormFile ImageFile, string Folder)
        {
            var FolderPath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Files", Folder); 

            var FileName = $"{Guid.NewGuid()}-{ImageFile.FileName}";

            var FilePath = Path.Combine(FolderPath, FileName);

            using(var stream = new FileStream(FilePath,FileMode.Create))
            {
                ImageFile.CopyTo(stream);
            }
            return FileName;
        }
    }
}
