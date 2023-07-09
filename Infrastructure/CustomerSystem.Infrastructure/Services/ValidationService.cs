using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;
using CustomerSystem.Application.Services;
using CustomerSystm.Domain.DTOModels.BaseDtos;
using CustomerSystm.Domain.DTOModels.CustomerDtos;
using Microsoft.Extensions.Configuration;

namespace CustomerSystem.Infrastructure.Services
{
	public class ValidationService: IValidationService
    {
        private readonly string KpsUrl = "";

        public ValidationService(IConfiguration _configuration)
		{
            KpsUrl = _configuration["KPSSetting:url"];
		}

        public string GetKpsServiceContent(string TCKN, string name, string surname, int birthYear)
        {
            try
            {
                var builder = new StringBuilder();

                //builder.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
                builder.Append("<soap:Envelope xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\">");
                builder.Append("<soap:Body>");
                builder.Append("<TCKimlikNoDogrula xmlns=\"http://tckimlik.nvi.gov.tr/WS\">");
                builder.Append("<TCKimlikNo>" + TCKN.Trim() + "</TCKimlikNo>");
                builder.Append("<Ad>" + name.Trim().ToUpper() + "</Ad>");
                builder.Append("<Soyad>" + surname.Trim().ToUpper() + "</Soyad>");
                builder.Append("<DogumYili>" + birthYear + "</DogumYili>");
                builder.Append(" </TCKimlikNoDogrula>");
                builder.Append("</soap:Body>");
                builder.Append("</soap:Envelope>");

                return builder.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //http srvice yazılacak

        public async Task<bool> ConfirmeCustomer(CustomerDto model)
        {
            try
            {
                return await ConfirmeKPS(model.TCKN,model.Name,model.Surname,model.BirthDate.Year);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> ConfirmeKPS(string TKN, string name, string surname,int birthYear)
        {
            try
            {
                if (string.IsNullOrEmpty(TKN)||string.IsNullOrEmpty(name)|| string.IsNullOrEmpty(surname))
                    throw new ValidationException("Kullanıcı Bilgilerini Kotrol Ediniz");
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(KpsUrl);
                var encoding = Encoding.UTF8;
                byte[] bytesToWrite = encoding.GetBytes(GetKpsServiceContent(TKN, name, surname, birthYear));
                request.Method = "POST";
                request.ContentLength = bytesToWrite.Length;
                request.ContentType = "text/xml; charset=utf-8";
                Stream newStream = request.GetRequestStream();
                newStream.Write(bytesToWrite, 0, bytesToWrite.Length);
                newStream.Close();
                HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync();

                using (Stream stream = response.GetResponseStream())
                {
                    StreamReader sreader = new StreamReader(stream, Encoding.UTF8);
                    String responseString = sreader.ReadToEnd();
                    XDocument doc = XDocument.Parse(responseString);
                    return Boolean.Parse(doc.Root!.Value);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
    }
}

