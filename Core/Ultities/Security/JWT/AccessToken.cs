using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Ultities.Security.JWT
{
    public class AccessToken
    {
        public string Token { get; set; } // Girş yapan kullanıcıya vereceğim token JWT'nin ta kendisi
        public DateTime Expiration { get; set; } // bitiş zamanı
    }
}
