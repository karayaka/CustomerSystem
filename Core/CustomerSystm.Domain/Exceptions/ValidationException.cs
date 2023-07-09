using System;
namespace CustomerSystm.Domain.Exceptions
{
	public class ValidationException:Exception
	{
		
        public ValidationException() : base("Doğrulama Hatası")
        {
        }

        public ValidationException(string message) : base(message)
        {

        }
    }
}

