using Microsoft.AspNetCore.Identity;

namespace NotikaIdentityEmail.Models
{
	public class CustomIdentityValidator : IdentityErrorDescriber
	{
		public override IdentityError PasswordTooShort(int length)
		{
			return new IdentityError()
			{
				Code = "PasswordTooShort",
				Description = "Şifreniz en az " + length + " karakter içermelidir !"
			};
		}
		public override IdentityError PasswordRequiresLower()
		{
			return new IdentityError()
			{
				Code = "PasswordRequiresLower",
				Description = "Şifreniz en az 1 küçük harf içermelidir !"
			};
		}
		public override IdentityError PasswordRequiresUpper()
		{
			return new IdentityError()
			{
				Code = "PasswordRequiresUpper",
				Description = "Şifreniz en az 1 büyük harf içermelidir !"
			};
		}
		//public override IdentityError PasswordRequiresUniqueChars(int uniqueChars)
		//{
		//	return new IdentityError()
		//	{
		//		Code = "PasswordRequiresUniqueChars",
		//		Description = "Şifreniz en az " + uniqueChars + " tane özel karakter içermelidir"
		//	};
		//}
		public override IdentityError PasswordRequiresDigit()
		{
			return new IdentityError()
			{
				Code = "PasswordRequiresDigit",
				Description = "Şifreniz en az 1 tane rakam içermelidir !"
			};
		}
		public override IdentityError PasswordRequiresNonAlphanumeric()
		{

			return new IdentityError()
			{
				Code = "PasswordRequiresNonAlphanumeric",
				Description = "Şifreniz en az 1 tane özel karakter içermelidir"
			};
		}
		public override IdentityError DuplicateUserName(string userName)
		{
			return new IdentityError()
			{
				Code = "DuplicateUserName",
				Description = userName + " bu isimde bir kullanıcı zaten mevcut !"
			};
		}
	}
}
