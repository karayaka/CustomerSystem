using System;
namespace CustomerSystm.Domain.Exceptions
{
	public class NotFoundException:Exception
	{
		public NotFoundException():base("Öğe Buunamadı")
		{
		}
		public NotFoundException(string message):base(message)
		{

		}
	}
}

