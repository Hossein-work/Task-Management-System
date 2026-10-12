class TaskManager
{
    public static void Main(string[] args)
    {

    }
}
static class ConsoleManager
{
    
}
class TaskItem
{
    public TaskItem(string title, string description, DateTime dueDate)
    {
        Id = new Guid();
        Title = title;
        Description = description;
        DueDate = dueDate;
    }
    private readonly Guid Id;
    private string title;
    private string description;
    private DateTime duedate;

    public string Title
    {
        get => title; private set => title = value;
    }
    public string Description
    {
        get => description; private set => description = value;
    }
    public DateTime DueDate
    {
        get => duedate; private set => duedate = value;
    }
    public virtual string GetDetails()
    {
        return "";
    }
}
class UrgentTask : TaskItem
{
    public UrgentTask(string title, string description, DateTime dueDate) : base(title, description, dueDate)
    {
    }

    public override string GetDetails()
    {
        return base.GetDetails() + "URGENT";
    }
}
abstract class NotificationService
{
    public abstract void Sent(string message);
}
class EmainNotifier : NotificationService
{
    public override void Sent(string message)
    {
        throw new NotImplementedException();
    }
}
class SmsNotifier : NotificationService
{
    public override void Sent(string message)
    {
        throw new NotImplementedException();
    }
}
interface IRepository<T>
{
    public void GetAll();
    public void GetById(Guid Id);
    public void RemoveById(Guid Id);

}
class InMemoryTaskRepository : IRepository<TaskItem>
{
    List<TaskItem> Tasks = new();
    public void GetAll()
    {
        throw new NotImplementedException();
    }

    public void GetById(Guid Id)
    {
        throw new NotImplementedException();
    }

    public void RemoveById(Guid Id)
    {
        throw new NotImplementedException();
    }
}
static class StringExtensions
{
    
}