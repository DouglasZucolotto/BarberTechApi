using BarberTech.Domain.Notifications;

namespace BarberTech.Infraestructure.Notifications
{
    public class NotificationContext : INotificationContext
    {
        private readonly List<string> _notifications = new List<string>();

        public IReadOnlyCollection<string> Notifications => _notifications;

        public bool HasNotifications => _notifications.Any();     

        public int ErrorCode { get; private set; }

        public void AddNotFound(string message)
        {
            _notifications.Add(message);
            UpdateErrorCodeToNotFound();
        }

        public void AddUnauthorized(string message)
        {
            _notifications.Add(message);
            UpdateErrorCodeToUnauthorized();
        }

        public void AddBadRequest(string message)
        {
            _notifications.Add(message);
            UpdateErrorCodeToBadRequest();
        }

        private void UpdateErrorCodeToBadRequest() => ErrorCode = 400;

        private void UpdateErrorCodeToNotFound() => ErrorCode = 404;

        private void UpdateErrorCodeToUnauthorized() => ErrorCode = 401;
    }
}
