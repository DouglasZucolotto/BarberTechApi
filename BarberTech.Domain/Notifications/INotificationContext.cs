﻿namespace BarberTech.Domain.Notifications
{
    public interface INotificationContext
    {
        int ErrorCode { get; }

        bool HasNotifications { get; }

        IReadOnlyCollection<string> Notifications { get; }

        void AddNotFound(string message);

        void AddUnauthorized(string message);

        void AddBadRequest(string message);
    }
}
