using System;
using CustomerSystm.Domain.Enums;

namespace CustomerSystm.Domain.EntitiyModels.BaseModels
{
	public class BaseEntityModel
	{
		public BaseEntityModel()
		{
           
            CreadedDate = DateTime.Now;
            UpdatedDate = DateTime.Now;
            ObjectStatus = ObjectStatus.NonDeleted;
            Status = Status.Active;
        }
        public Guid ID { get; set; }


        public DateTime CreadedDate { get; set; }


        public DateTime UpdatedDate { get; set; }


        public ObjectStatus ObjectStatus { get; set; }


        public Status Status { get; set; }
    }
}

