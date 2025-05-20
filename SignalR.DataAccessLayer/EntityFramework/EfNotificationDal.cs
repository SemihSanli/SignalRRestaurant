using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfNotificationDal : GenericRepository<Notification>, INotificationDal
    {
        public EfNotificationDal(SignalRContext context) : base(context)
        {

        }

        public List<Notification> GetAllNotificationByFalse()
        {
            using var context = new SignalRContext();
            return context.Notifications.Where(x => x.NotificationStatus == false).ToList();
        }

        public int NotificationCountByStatusFalse()
        {
            using var context= new SignalRContext();
            return context.Notifications.Where(x => x.NotificationStatus == false).Count();
        }

        public void NotificationStatusChangeToFalse(int id)
        {
            using var context = new SignalRContext();
            var value = context.Notifications.Find(id);
            value.NotificationStatus = false;
            context.SaveChanges();
        }

        public void NotificationStatusChangeToTrue(int id)
        {
            using var context = new SignalRContext();
            var value = context.Notifications.Find(id);
            value.NotificationStatus = true;
            context.SaveChanges();
        }
    }
}
