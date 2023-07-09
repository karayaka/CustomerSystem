using System;
using CustomerSystm.Domain.DTOModels.BaseDtos;

namespace CustomerSystm.Domain.DTOModels.CustomerDtos
{
	public class CustomerListDto:BaseDto
	{
		public CustomerListDto()
		{
		}
        public string TCKN { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string BirthDate { get; set; }
    }
}

