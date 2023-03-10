using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace Project.MVCUI.Tools
{
    public static class ImageUploader
    {
        //Geriye string deger  donduren metodumuz resmin yolunu döndürecek veya resim yükleme ile ilgili bir sorun varsa onun kodunu döndürecek "1", "2" ,"3" , "C:/Images/..."

        //HttpPostedFileBase => MVC'de eger Post yönteminde bir dosya gleiyorsa bu dosya, HttpPostedFileBase tipinde tutulur



        public static string UploadImage(string serverPath,HttpPostedFileBase file,string name)
        {
            if(file != null)
            {
                Guid uniqueName = Guid.NewGuid();

                string[] fileArray =   file.FileName.Split('.'); //burada Split metodu sayesinde ilgili yapının uzantısının da icinde bulundugu bir string dizisi almıs olduk...Split metodu belirttiginiz char karakterinden metni bölerek size bir array sunar...

                string extension = fileArray[fileArray.Length - 1].ToLower(); //Dosya uzantısını yakalayarak kücük harflere cevirdik...

                string fileName = $"{uniqueName}.{name}.{extension}"; //normal şartlarda biz Guid kullandıgımız icin asla bir dosya ismi aynı olmayacaktır...Lakin siz Guid veya baska bir unique hash  kullanmazsanız (sadece kullanıcıdan dosya ismi alırsanız) böyle bir durumda aynı isimde dosya upload'u mümkün hale gelecektir...Dolayısıyla öyle bir durumda ek olarak bir kontrol yapmanız gerekir..Tabii ki böyle bir senaryo olsun veya olmasın önce extension kontrol edilmelidir...Ek kontrol daha sonra yapılmalıdır...

                if(extension=="jpg" || extension == "gif" || extension == "png" || extension =="jpeg")
                {
                    //Eger dosya ismi zaten varsa
                    if (File.Exists(HttpContext.Current.Server.MapPath(serverPath + fileName)))
                    {
                        return "1"; //Ancak Guid kullandıgımız icin bu acıdan zatne güvendeyiz (Dosya zaten var kodu)
                    }
                    else
                    {
                        string filePath = HttpContext.Current.Server.MapPath(serverPath + fileName);
                        file.SaveAs(filePath);
                        return serverPath + fileName;
                    }
                }

                else
                {
                    return "2";//Seclien dosya bir resim degildir kodu
                }

            }




            return "3"; //Dosya bos kodu
        }
    }
}