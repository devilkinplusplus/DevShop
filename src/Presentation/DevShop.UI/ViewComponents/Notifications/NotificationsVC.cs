using DevShop.Application.Abstractions.Services;
using Microsoft.AspNetCore.Mvc;

namespace DevShop.UI.ViewComponents.Notifications
{
    public class NotificationsVC:ViewComponent
    {
        private readonly IContactService _contactService;

        public NotificationsVC(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _contactService.GetLastMessages(5);
            return View(values);
        }
    }
}
