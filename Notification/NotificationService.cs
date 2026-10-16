abstract class NotificationService
{
    public enum NotifType
    {
        Sms, Email
    }
    public abstract void Send(string message);
}
