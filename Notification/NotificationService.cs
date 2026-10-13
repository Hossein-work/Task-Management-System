abstract class NotificationService
{
    public enum NotifType
    {
        Sms, Email
    }
    public abstract void Sent(string message);
}
