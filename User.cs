public class User
{

    // User properties.
    public int UserID { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public List<Task> Tasks { get; set; }

    private static int id = 1;

    // User constructor.
    public User()
    {
        UserID = id++;
        Username = "admin";
        Password = "12345";
        Tasks = [];
    }

    // Adds task to the user task list.

    public void CreateTask(Task task)
    {
        Tasks.Add(task);
    }

    // Removes a task from the task list.
    public void DeleteTask(int taskID)
    {
        // Looks through the tasks list for a task with the matching task ID. Removes it once a match is found.
        var task = Tasks.FirstOrDefault(t => t.TaskID == taskID);
        if (task != null)
        {
            Tasks.Remove(task);
        }
    }

    // An output of previously created tasks is displayed that the user can view.
    public void ViewTasks()
    {
        if (Tasks.Count == 0)
        {
            Console.WriteLine("No tasks were created.");
        }
        else
        {

            foreach (var task in Tasks)
            {
                Console.WriteLine($"\nTask ID: {task.TaskID}\nName: {task.TaskName}\nSummary: {task.TaskSummary}\nDeadline: {task.UntilDate.ToShortDateString()}\nPriority: {task.Priority}");
                task.RemindTask();
                if (task.Tags.Count != 0)
                {
                    Console.Write("Tags:");
                    foreach (var tag in task.Tags)
                    {
                        Console.WriteLine($" {tag.tagName}");
                    }
                }
                Console.WriteLine("\n------------------------------------\n");
            }

        }
    }
}