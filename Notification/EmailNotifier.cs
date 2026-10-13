class EmailNotifier : NotificationService
{
    public override void Sent(string message)
    {
        if (!string.IsNullOrEmpty(message))
            ConsoleManager.SendNotification(NotificationService.NotifType.Email,message);
        else throw new Exception("Message can not be null of empty !");
    }
}
