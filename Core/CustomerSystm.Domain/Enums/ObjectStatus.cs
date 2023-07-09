using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CustomerSystm.Domain.Enums
{
	public enum ObjectStatus
	{
        [Display(Name = "Silindi")]
        Deleted = 0,
        [Display(Name = "Silinmedi")]
        NonDeleted = 1
    }
}

