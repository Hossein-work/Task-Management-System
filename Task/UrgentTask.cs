class UrgentTask : TaskItem
{
    public UrgentTask(string title, string description, DateTime dueDate) : base(title, description, dueDate)
    {
    }

    public override string GetDetails()
    {
        return base.GetDetails() + " -URGENT-";
    }
}
