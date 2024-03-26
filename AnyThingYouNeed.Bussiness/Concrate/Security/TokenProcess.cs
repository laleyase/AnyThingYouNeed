using AnyThingYouNeed.Bussiness.Concrate.ResultModel;
using AnyThingYouNeed.Entities.Concrate;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AnyThingYouNeed.Bussiness.Concrate.Security
{
     public class TokenProcess
    {
        public static bool ValidateToken(string token)   //sadece program açılırken oluşturuyor
        {

            bool result = false;

            var claim = DecodeToken(token);
            if (claim != null)
            {
                if (claim.Success == true)
                {
                    if (claim.ValidityDatetime > DateTime.UtcNow)
                    {
                        result = true;
                    }
                }
                else
                {
                    result = false;
                }
            }
            else
            {
                result = false;
            }
            return result;
        }
        public static TokenPayload DecodeToken(string token)
        {
            string secretKey = "F6CB3A5B018C4CCD8E050B4E04E04FE9";
            var tokenPayload = new TokenPayload();
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var validationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };

                SecurityToken validatedToken;
                var claimsPrincipal = tokenHandler.ValidateToken(token, validationParameters, out validatedToken);

                tokenPayload.Id = Convert.ToInt32(claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier).Value);
                tokenPayload.EMail = claimsPrincipal.FindFirst(ClaimTypes.Email).Value;
                tokenPayload.PhoneNumber = claimsPrincipal.FindFirst(ClaimTypes.MobilePhone).Value;
                tokenPayload.UserName = claimsPrincipal.FindFirst(ClaimTypes.Name).Value;
                tokenPayload.ValidityDatetime = validatedToken.ValidTo;
                tokenPayload.Success = true;
            }
            catch
            {
                tokenPayload.Success = false;
            }
            return tokenPayload;
        }
        public static void GenerateToken(ref LoginResultModel generateTokenResult, User user, int ExpireMinute)
        {
            generateTokenResult.Token = null;
            generateTokenResult.User = null;
            generateTokenResult.Success = false;
            generateTokenResult.Message = "";
            try
            {
                if (user != null)
                {
                    var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserID.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
            };
                    string StrSecretKey = "F6CB3A5B018C4CCD8E050B4E04E04FE9";
                    var SecretKey = Encoding.UTF8.GetBytes(StrSecretKey);
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(claims),
                        Expires = DateTime.UtcNow.AddMinutes(ExpireMinute),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(SecretKey), SecurityAlgorithms.HmacSha256Signature)
                    };
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    generateTokenResult.Token = new Token();
                    generateTokenResult.Token.JWT = tokenHandler.WriteToken(token);
                    generateTokenResult.Token.ValidMinute = ExpireMinute;
                    generateTokenResult.Token.ValidityDatetime = DateTime.Now.AddMinutes(ExpireMinute);
                    generateTokenResult.Success = true;
                    generateTokenResult.Token.UserID = user.UserID;
                    generateTokenResult.Token.UserName = user.UserName;
                }
            }
            catch (Exception ex)
            {
                generateTokenResult.Message = "Sistem Yöneticisi ile görüşmeniz gerekmektedir.";
            }
        }
    }
}
