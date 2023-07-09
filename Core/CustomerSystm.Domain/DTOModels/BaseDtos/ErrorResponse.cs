using System;
namespace CustomerSystm.Domain.DTOModels.BaseDtos
{
	public class ErrorResponse
	{
		public ErrorResponse(string _value)
		{
            Values = new List<string>();
            Values.Add(_value);
		}

		public ErrorResponse(List<string> _values)
		{
            Values = new List<string>();
            Values.AddRange(_values);
        }
		public ErrorResponse(string _key, List<string> _values)
		{
			Key = _key;
			Values = _values;
		}


		public DateTime Date { get; set; } = DateTime.Now;

		public string Key { get; set; } = "All";

		public List<string> Values { get; set; }
	}
}

