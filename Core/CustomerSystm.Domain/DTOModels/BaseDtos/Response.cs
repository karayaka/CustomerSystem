using System;
namespace CustomerSystm.Domain.DTOModels.BaseDtos
{
	public class Response<T>
	{
		public Response(
            T _Data,
            string _Message = null
            )
		{
            Data = _Data;
            ResultDate = DateTime.Now;
            Message = _Message;

        }
        public DateTime ResultDate { get; set; }

        public T Data { get; set; }

        public string Message { get; set; }
    }
}

