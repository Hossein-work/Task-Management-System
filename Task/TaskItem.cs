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
    public Guid GetId() => Id;


    public virtual string GetDetails()
    {
        return description;
    }
}
