using System.Data.Common;

public class Task : Remind
{

    // Task Properties

    public int TaskID { get; set; }
    public string TaskName { get; set; }
    public string TaskSummary { get; set; }
    public string Priority { get; set; }
    public DateTime UntilDate { get; set; }
    public List<Tag> Tags { get; set; }

    private static int id = 1;

    // Task Constructor

    public Task()
    {
        TaskID = id++;
        TaskName = "Default";
        TaskSummary = "Default summary";
        Priority = "None";
        UntilDate = DateTime.Now.AddDays(1);
        Tags = [];

    }

    // Adds categories to a task.
    public void AddTag(Tag tag)
    {
        Tags.Add(tag);
    }

    // Announces a reminder when a task deadline is coming up within the week.

    public override bool RemindTask()
    {
        // Calculates the amount of time left: Task due date - the current time.
        TimeSpan timeLeft = UntilDate - DateTime.Now;

        if (timeLeft.TotalDays < 7)
        {
            Console.WriteLine($"REMINDER: This task needs to be completed soon. You have {timeLeft.Days} days left.");
            return true;
        }
        return false;
    }

}