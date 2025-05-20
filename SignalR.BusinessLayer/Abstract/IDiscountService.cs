using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Abstract
{
    public interface IDiscountService:IGenericService<Discount>
    {
        void TChangeStatusToFalse(int id);
        void TChangeStatusToTrue(int id);
        List<Discount> TGetListByStatusTrue();
    }
}
