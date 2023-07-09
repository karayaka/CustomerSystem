using System;
using System.ComponentModel.DataAnnotations;

namespace CustomerSystm.Domain.Enums
{
	public enum Status
	{
        [Display(Name = "Aktif")]
        Active = 1,

        [Display(Name = "Pasif")]
        Pasive = 0,
	}
}

