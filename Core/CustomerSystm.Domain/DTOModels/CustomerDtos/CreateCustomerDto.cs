using System;
using CustomerSystm.Domain.DTOModels.BaseDtos;

namespace CustomerSystm.Domain.DTOModels.CustomerDtos
{
	public class CreateCustomerDto:BaseDto
	{
		public CreateCustomerDto()
		{
		}
        public string TCKN { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public DateTime BirthDate { get; set; }
    }
}

