using System;
using CustomerSystm.Domain.DTOModels.CustomerDtos;
using FluentValidation;

namespace CustomerSystm.Domain.Validators.Customer
{
	public class CreateCustomerValidator:AbstractValidator<CreateCustomerDto>
	{
		public CreateCustomerValidator()
		{
			RuleFor(c => c.TCKN)
				.NotNull().WithMessage("Zorunlu Alan")
				.NotEmpty().WithMessage("Kimlik No Boş Geçilemez")
				.Length(11, 11).WithMessage("Kimlik No 11 Rakamdan Oluşmalı");
			RuleFor(c => c.Name)
				.NotNull().WithMessage("Zorunlu Alan")
                .NotEmpty().WithMessage("Ad Boş Geçilemez");
            RuleFor(c => c.Surname)
                .NotNull().WithMessage("Zorunlu Alan")
                .NotEmpty().WithMessage("Soyad Boş Geçilemez");
			RuleFor(c => c.Email)
				.NotNull().WithMessage("Zorunlu Alan")
                .EmailAddress().WithMessage("Lütfen Geçerli Bir Mail Adresi Giriniz");
			//burda 18 yaş kotrolu de yapılabilir
			RuleFor(c => c.BirthDate)
				.Must(bd => bd > DateTime.MinValue).WithMessage("Lütfen Geçerli Bir Doğum Tarihi Giriniz");
        }

	}
}

