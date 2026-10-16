class EmailNotifier : NotificationService
{
    public override void Send(string message)
    {
        if (!string.IsNullOrEmpty(message))
            ConsoleManager.SendNotification(NotifType.Email,message);
        else throw new Exception("Message can not be null of empty !");
    }
}
