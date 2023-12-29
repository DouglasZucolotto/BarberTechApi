namespace BarberTech.Infraestructure
{
    public class NotificationContext //: INotificationContext
    {
        //private readonly List<Notification> _notifications = new List<Notification>();

        public int ErrorCode { get; private set; }

        public void AddNotFound(string field, string message)
        {
            AddInternNotification(field, "NotFound", message);
            UpdateErrorCodeToNotFound();
        }

        public void AddUnauthorized(string field, string message)
        {
            AddInternNotification(field, "Unauthorized", message);
            UpdateErrorCodeToUnauthorized();
        }

        public void AddBadRequest(string field, string message)
        {
            AddInternNotification(field, "BadRequest", message);
            UpdateErrorCodeToBadRequest();
        }

        private void AddInternNotification(string field, string rule, string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                return;
            }

            //_notifications.Add(Notification.CreateWithStatusCode(field, rule, message));
        }

        private void UpdateErrorCodeToBadRequest() => ErrorCode = 400;

        private void UpdateErrorCodeToNotFound() => ErrorCode = 404;

        private void UpdateErrorCodeToUnauthorized() => ErrorCode = 401;
    }
}
