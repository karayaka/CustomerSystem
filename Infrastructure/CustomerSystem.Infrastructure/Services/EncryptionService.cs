using System;
using CustomerSystem.Application.Services;
using CustomerSystm.Domain.DTOModels.CustomerDtos;
using CustomerSystm.Domain.EntitiyModels.CustomerModels;
using CustomerSystm.Domain.Enums;
using CustomerSystm.Domain.Exceptions;

namespace CustomerSystem.Infrastructure.Services
{
	public class EncryptionService: IEncryptionService
    {
		public EncryptionService()
		{
		}

        public string BirthDateEncryption(DateTime birthDate)
        {
            try
            {
                return "**/**/" + birthDate.Year;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string EmailEncryption(string email)
        {
            try
            {
                if (!email.Contains("@"))
                    throw new EncryptionException("Lütfen Geçerli Bir Email Girin");
                var partsOfEmail = email.Split("@");
                var nameOfEmail = NameSurnameEncryption(partsOfEmail[0]);
                return nameOfEmail +"***@"+ partsOfEmail[1];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CustomerListDto EncryptionCustomerInfo(Customer model)
        {
            try
            {
                return new CustomerListDto()
                {
                    ID=model.ID,
                    TCKN=TCKNEncryption(model.TCKN),
                    Name=NameSurnameEncryption(model.Name),
                    Surname=NameSurnameEncryption(model.Surname),
                    Email=EmailEncryption(model.Email),
                    BirthDate=BirthDateEncryption(model.BirthDate),
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string NameSurnameEncryption(string str)
        {
            try
            {
                var sstr = "";
                if (string.IsNullOrWhiteSpace(str))
                    throw new EncryptionException("Şifrelenecek string boş olamaz");
                if (str.Length == 1)
                    sstr = str;
                else
                    sstr = str.Substring(0, 2);
                return sstr+"*****";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string TCKNEncryption(string TCKN)
        {
            try
            {
                var ctckn = TCKN.Substring(6, 4);
                return "*******" + ctckn;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

