using Buisness.Abstract;
using Core.Entities.Concrete;
using Core.Ultities.Buisness;
using Core.Ultities.Results;
using Core.Ultities.Security.Hashing;
using Core.Ultities.Security.JWT;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims.Data);
            return new SuccessDataResult<AccessToken>(accessToken, "token oluşturuldu");
        }

        public IDataResult<User> Login(UserForLoginDto userForRegisterDto)
        {
            var userToCheck = _userService.GetByMail(userForRegisterDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>("Kullanıcı Bulunamadı.");
            }
            if (!HashingHelper.VerifyPasswordHash(userForRegisterDto.Password, userToCheck.Data.PasswordHash, userToCheck.Data.PasswordSalt))
            {
                return new ErrorDataResult<User>("Şifre Yanlış");
            }
            return new SuccessDataResult<User>(userToCheck.Data, "Giriş Başarılı");
        }

    

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User()
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true

            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user, "Kayıt Başarılı");
        }

        public IResult UserExists(string email)
        {
            IResult result = BuisnessRules.Run(CheckIfUserExist(email));
            if (result == null);
            {
                return new ErrorResult("kullanıcı mevcut"); // burası değişebilir
            }
            return new SuccessResult();
        }

        private IResult CheckIfUserExist(string email)
        {
            var result = _userService.GetByMail(email).Data;
            if (result == null)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
    }
}
