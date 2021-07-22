using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace NinjaRazorPages.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }

    public class RegisterUserService
    {
        private readonly INotificationAgent _notificationAgent;

        public RegisterUserService(INotificationAgent notificationAgent)
        {
            _notificationAgent = notificationAgent;
        }

        public void Register(string user)
        {
            _notificationAgent.SendEmail(user);
        }
    }


    public interface INotificationAgent
    {
        void SendEmail(string username);
    }

    public class NotificationAgent : INotificationAgent
    {
        public void SendEmail(string username)
        {
            // send email
        }
    }

}