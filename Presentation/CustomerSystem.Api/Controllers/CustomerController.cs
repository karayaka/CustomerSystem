using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CV = System.Convert; // 'Convert' Sınıfı için takma isim kullanıldı. CV olan yerler Convert kullanılmış
using CustomerSystem.Application.Repositorys;
using CustomerSystem.Application.Services;
using CustomerSystm.Domain.DTOModels.BaseDtos;
using CustomerSystm.Domain.DTOModels.CustomerDtos;
using CustomerSystm.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CustomerSystem.Api.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : BaseController
    {
        private readonly ICustomerRepository customerRepository;
        private readonly ICachingService cachingService;
        public CustomerController(ICustomerRepository _customerRepository, ICachingService _cachingService)
        {
            customerRepository = _customerRepository;
            cachingService = _cachingService;
        }
        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]string? q)
        {
            try
            {
                var customers = await customerRepository.GetCustomers(q).ToListAsync();
                return Ok(new Response<List<CustomerListDto>>(_Data:customers));
            }
            catch (Exception ex)
            {
                return ErrorHadler(ex);
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                CustomerDto customer = cachingService.GetData<CustomerDto>("cus" + id);
                if (customer == null)
                {
                    customer = await customerRepository.GetCustomer(id);
                    cachingService.SetDate<CustomerDto>("cus" + id, customer, DateTimeOffset.Now.AddMinutes(1));
                }
                
                return Ok(new Response<CustomerDto>(_Data: customer));
            }
            catch (Exception ex)
            {
                return ErrorHadler(ex);
            }
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateCustomerDto value)
        {
            try
            {
                await customerRepository.AddOrUpdateCustomer(value);
                await customerRepository.SaveChange();
                return Ok();
            }
            catch (Exception ex)
            {
                return ErrorHadler(ex);
            }
            
        }
            
        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await customerRepository.DeleteCustomer(id);
                await customerRepository.SaveChange();
                return Ok();
            }
            catch (Exception ex)
            {
                return ErrorHadler(ex);
            }
        }
        /*[HttpPost("test")]
        public IActionResult test([FromBody]TestModel model)
        {
            try
            {
                double number1 = 0;
                if (!Double.TryParse(model.Number1, out number1))

                    

            }
            catch (Exception ex)
            {
                return ErrorHadler(ex);
            }
        }*/
        public static string dinamikTopla(string sayi1, string sayi2)
        {
            byte elde = 0; // Toplamada oluşacak eldelleri tutmak için kullanılan değişken.
            uint buyunSayi = 0; // Sadece pozitif sayılarda işlem düşünüldüğü için uint türü kullanıldı.
            uint kucukSayi = 0; // Sadece pozitif sayılarda işlem düşünüldüğü için uint türü kullanıldı.
            string sonuc = "";

            // Bu if - else yapısında iki sayının toplamasının  yapılabilmesi için iki sayı da aynı uzunluğa '0'
            // eklenerek getiriliyor.    
            if (sayi1.Length >= sayi2.Length)
            {
                buyunSayi = (uint)sayi1.Length;
                kucukSayi = (uint)sayi2.Length;

                for (int i = 0; i < buyunSayi - kucukSayi; i++)
                {
                    sayi2 = "0" + sayi2;
                }
            }
            else
            {
                buyunSayi = (uint)sayi2.Length;
                kucukSayi = (uint)sayi1.Length;

                for (int i = 0; i < buyunSayi - kucukSayi; i++)
                {
                    sayi1 = "0" + sayi1;
                }
            }

            // Aynı uzunluktaki iki sayının toplaması yapılıyor.
            for (int i = sayi1.Length - 1; i >= 0; i--)
            {
                byte araToplam = (byte)(CV.ToByte(sayi1[i].ToString()) + CV.ToSByte(sayi2[i].ToString()) + elde);

                if (araToplam >= 10)
                {
                    sonuc = CV.ToString(araToplam % 10) + sonuc;
                    elde = 1;
                }
                else
                {
                    sonuc = CV.ToString(araToplam % 10) + sonuc;
                    elde = 0;
                }
            }
            // Elde kalıyorsa son basamakta biz o eldeyi for döngüsünün dışında ekliyoruz.
            if (elde != 0)
            {
                sonuc = elde.ToString() + sonuc;
            }

            return sonuc;
        }


    }
}

