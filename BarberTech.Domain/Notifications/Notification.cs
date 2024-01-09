namespace BarberTech.Domain.Notifications
{
    public class Notification
    {
        public string Key { get; }
        public string Message { get; }

        public Notification(string key, string message)
        {
            Key = key;
            Message = message;
        }

        public static Notification Create(string rule, string message)
            => new Notification(rule, message);
    }
}
