using System;
using CustomerSystm.Domain.DTOModels.CustomerDtos;
using CustomerSystm.Domain.EntitiyModels.CustomerModels;
using CustomerSystm.Domain.Enums;

namespace CustomerSystem.Application.Services
{
	public interface IEncryptionService
	{
        /// <summary>
        /// Customer model Encryption
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
		CustomerListDto EncryptionCustomerInfo(Customer model);
        /// <summary>
        /// Name surname Encryption metods
        /// </summary>
        /// <param name="str">str</param>
        /// <param name="encryptionType">Encryption way</param>
        /// <returns></returns>
        string NameSurnameEncryption(string str);
        /// <summary>
        /// Customer birth date encryption metod
        /// </summary>
        /// <param name="birthDate"></param>
        /// <returns></returns>
        string BirthDateEncryption(DateTime birthDate);
        /// <summary>
        /// TCKN Encryption
        /// </summary>
        /// <param name="TCKN"></param>
        /// <returns></returns>
        string TCKNEncryption(string TCKN);
        /// <summary>
        /// Emil Encryption
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        string EmailEncryption(string email);
    }
}

