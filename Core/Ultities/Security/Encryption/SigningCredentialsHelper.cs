using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Ultities.Security.Encryption
{
    public class SigningCredentialsHelper // imzalama demek
    {//security key ve algoritmamı belirlediğim nesnem
        public static SigningCredentials CreateSigningCredentials(SecurityKey security) // jwtleri oluşturmak için sisteme girmek için elimizde olanlardır
        {

            return new SigningCredentials(security, SecurityAlgorithms.HmacSha512Signature);//Şifrelenmiş kimliği oluşturuyoruz.
            // anahtar olarak bu securty kullan ve  şifreleme olarak  güvenlik algr bunu kullan

            // Credentials => kimlik bilgileri,Giriş bilgileri
        }
    }
}
