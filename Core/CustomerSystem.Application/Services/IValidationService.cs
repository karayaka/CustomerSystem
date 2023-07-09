using System;
using CustomerSystm.Domain.DTOModels.CustomerDtos;

namespace CustomerSystem.Application.Services
{
	public interface IValidationService
	{
		/// <summary>
		/// KPS ServiceContebtMethod
		/// </summary>
		/// <param name="TKN"></param>
		/// <param name="name"></param>
		/// <param name="surname"></param>
		/// <param name="birthYear"></param>
		/// <returns></returns>
		string GetKpsServiceContent(string TKN, string name, string surname, int birthYear);

		/// <summary>
		/// KPS Request model
		/// </summary>
		/// <param name="TKN"></param>
		/// <param name="name"></param>
		/// <param name="surname"></param>
		/// <param name="birthYear"></param>
		/// <returns></returns>
		Task<bool> ConfirmeKPS(string TKN, string name, string surname, int birthYear);
		/// <summary>
		/// confirme Customer Model
		/// </summary>
		/// <param name="model">CustomerDTO</param>
		/// <returns></returns>
		Task<bool> ConfirmeCustomer(CustomerDto model);

    }
}

