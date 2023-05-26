using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Ultities.Security.Encryption
{
    public class SecurityKeyHelper 
    {
        public static SecurityKey CreateSecurityKey(string securityKey) // securityKey appsettingsde olan key bende ona SecurityKey karşılığını vereyim
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));//SymmetricSecurityKey sınıfının yeni bir örneğini başlatır.simetrik security key kullanıcaz
        }
        // elimizde olan securityKey'imizi byte haline getirmeye yarıyor bu **** SINIF ******


    }
}
