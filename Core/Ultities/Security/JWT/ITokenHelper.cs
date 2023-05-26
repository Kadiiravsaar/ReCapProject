using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Ultities.Security.JWT
{
    public interface ITokenHelper // Token üretecek mekanizmayı yazıyoruz
    {
        //Parametre olarak List<OperationClaim> operationClaims'i de göndermemin sebebi oluşturacağım token'a User'ımın claimlerininde içinde olması
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);

        // /Arayüzde kullanıcı ID ve Şifresini yazdı, girş yap dediğinde bizim API'mize geldi.
        // Giriş yap dediğinde bizim bu CreateToken operasyonumuz çalışacak.
        // Eğer giriş bilgileri doğru ise ilgili kullanıcı için veri tabanına gidecek,
        // veritabanından bu kullanıcının clamilerini bulucak(yetkilerini) orada bir tane JWT üretecek daha sonra onları client e vrecek
        
        
        // neden ihtiyaç var => ilgili kullanıcı için girilen veriler ile buraya düşüp token oluşturucak
    }
}
