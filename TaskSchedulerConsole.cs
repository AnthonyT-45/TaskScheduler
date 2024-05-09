using System.Reflection.Metadata;

public class TaskSchedulerConsole
{

    // Creates a list of users.
    private static readonly List<User> users = [];
    // When program is launched, it's set to have no user logged in.
    private static User? consoleUser = null;
    private static bool login = false;
    
    // Allows a signed up user to log into the task scheduler.
    private static void Login()
    {
        Console.WriteLine("\nEnter username:");
        string? username = Console.ReadLine();
        Console.WriteLine("Enter password:");
        string? password = Console.ReadLine();

        foreach (var user in users)
        {
            if (user.Username == username && user.Password == password)
            {
                consoleUser = user;
                Console.WriteLine("Logging in...\n");
                login = true;
                return;
            }
            else
            {
                Console.WriteLine("Username or password was invalid.");
                return;
            }
        }
    }

    // Allows a new user to sign up and create an account.
    private static void SignUp()
    {
        Console.WriteLine("\nCreate a username:");
        string? username = Console.ReadLine();
        Console.WriteLine("Create a password:");
        string? password = Console.ReadLine();

        if (username == null || password == null)
        {
            return;
        }

        User registeredUser = new() { Username = username, Password = password };
        users.Add(registeredUser);
        Console.WriteLine("\nYou have now created a new user profile.");
    }

    // Exits the program.
    public static void Exit()
    {
        Environment.Exit(0);
    }

    // Prompts the user to create a task.
    public static void CreateTask()
    {
        Console.WriteLine("Task subject:");
        string? subject = Console.ReadLine();
        Console.WriteLine("Enter task summary:");
        string? summary = Console.ReadLine();
        Console.WriteLine("Enter a deadline:\nFormat: YYYY-MM-DD");
        string? strDeadline = Console.ReadLine();
        Console.WriteLine("Enter task priority:\nPriorites: Low, Medium, High");
        string? priority = Console.ReadLine();

        if (!DateTime.TryParse(strDeadline, out DateTime deadline))
        {
            return;
        }

        if (subject == null || summary == null || strDeadline == null || priority == null)
        {
            return;
        }

        // Task creation.
        Task task = new() { TaskName = subject, TaskSummary = summary, UntilDate = deadline, Priority = priority };

        Console.WriteLine("Would you like to add tag(s)?\nEnter yes to add tag(s).\nEnter no to skip.");
        string? answer = Console.ReadLine();
        while (answer == "yes")
        {
            Console.WriteLine("Enter tag category:");
            string? tagName = Console.ReadLine();

            if (tagName != null)
            {
                Tag newTag = new(tagName);
                task.AddTag(newTag);
                Console.WriteLine("Add another tag?\nEnter yes to continue.\nEnter no to skip.");
                answer = Console.ReadLine();
            }

        }


        consoleUser?.CreateTask(task);
        Console.WriteLine("Task created.\n");
    }

    // Prompts the user to give the task ID that the user wants to delete.

    public static void DeleteTask()
    {
        if (consoleUser != null)
        {
            Console.WriteLine("Enter ID of the task to delete:");
            int numTask = Convert.ToInt32(Console.ReadLine());
            consoleUser.DeleteTask(numTask);
            Console.WriteLine($"Task with Task ID #{numTask} has been deleted.\n");
        }
    }

    // Calls the ViewTasks() method in Users in order for the user to view their created tasks.
    public static void ViewTask()
    {
        consoleUser?.ViewTasks();
    }


    // Main method to execute the console app.

    public static void Main(string[] args)
    {
        while (true)
        {
            if (consoleUser == null)
            {
                Console.WriteLine("\nEnter 1 to Login\nEnter 2 to Sign Up\nEnter 3 to Exit\n");

                switch (Console.ReadLine())
                {
                    case "1":
                        Login();
                        break;
                    case "2":
                        SignUp();
                        break;
                    case "3":
                        Exit();
                        break;
                }
            }
            if (login == true)
            {
                Console.WriteLine("\nEnter 1 to Create a Task\nEnter 2 to Delete a Task\nEnter 3 to View your Tasks\nEnter 4 to Log Out\n");

                switch (Console.ReadLine())
                {
                    case "1":
                        CreateTask();
                        break;
                    case "2":
                        DeleteTask();
                        break;
                    case "3":
                        ViewTask();
                        break;
                    case "4":
                        consoleUser = null;
                        break;

                }
            }
        }
    }
}