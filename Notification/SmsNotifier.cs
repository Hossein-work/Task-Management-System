class SmsNotifier : NotificationService
{
    public override void Sent(string message)
    {
        if (!string.IsNullOrEmpty(message)) 
            ConsoleManager.SendNotification(NotificationService.NotifType.Sms,message);
        else throw new Exception("Message can not be null of empty !");
    }
}
