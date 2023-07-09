using System;
using System.ComponentModel.DataAnnotations.Schema;
using CustomerSystm.Domain.EntitiyModels.BaseModels;

namespace CustomerSystm.Domain.EntitiyModels.CustomerModels
{
	public class Customer: BaseEntityModel
    {
        public string TCKN { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        [Column("BirthDate", TypeName = "timestamp without time zone ")]
        public DateTime BirthDate { get; set; }

    }
}

