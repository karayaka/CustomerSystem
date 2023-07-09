using System;
namespace CustomerSystm.Domain.Exceptions
{
	public class EncryptionException:Exception
	{
		public EncryptionException():base("Şifreleme hatası")
		{
		}
		public EncryptionException(string message):base(message)
		{

		}
	}
}

