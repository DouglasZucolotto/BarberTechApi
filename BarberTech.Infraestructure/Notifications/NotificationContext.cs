using BarberTech.Domain.Notifications;

namespace BarberTech.Infraestructure.Notifications
{
    public class NotificationContext : INotificationContext
    {
        private readonly List<Notification> _notifications = new List<Notification>();

        public IReadOnlyCollection<Notification> Notifications => _notifications;

        public bool HasNotifications => _notifications.Any();     

        public int ErrorCode { get; private set; }

        public void AddNotFound(string message)
        {
            AddNotification("NotFound", message);
            UpdateErrorCodeToNotFound();
        }

        public void AddUnauthorized(string message)
        {
            AddNotification("Unauthorized", message);
            UpdateErrorCodeToUnauthorized();
        }

        public void AddBadRequest(string message)
        {
            AddNotification("BadRequest", message);
            UpdateErrorCodeToBadRequest();
        }

        private void AddNotification(string rule, string message)
        {
            _notifications.Add(Notification.Create(rule, message));
        }

        private void UpdateErrorCodeToBadRequest() => ErrorCode = 400;

        private void UpdateErrorCodeToNotFound() => ErrorCode = 404;

        private void UpdateErrorCodeToUnauthorized() => ErrorCode = 401;
    }
}
