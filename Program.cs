using System;

namespace ToDoList
{
    class Program
    {
        static List<Task> tasks = new List<Task>
        {
            new Task("Walking Dogs", "Fisby, Fodo, Lego"),
            new Task("Buy Groceries", "Fish, Milk, Pork, Chicken"),
            new Task("Playing with Kids", "Anya, Lorel"),
            new Task("Learn Programming", "C#, Python, JavaScripts"),
            new Task("Go for a walk", "From home to park"),
            new Task("Writing Diary", "List what have done, and plan tomorrow.")
        };

        static void Main(string[] args)
        {
            int choice;
            do
            {
                PrintMenu();

                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    HandleChoice(choice);
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a numeric value.\n");
                }

            } while (choice != 4);
        }

        static void PrintMenu()
        {
            Console.WriteLine("\nTo-Do List Application\n");
            Console.WriteLine("1. Add a new task");
            Console.WriteLine("2. View tasks");
            Console.WriteLine("3. Mark a task as completed");
            Console.WriteLine("4. Quit");
            Console.Write("\nEnter your choice: ");
        }

        static void HandleChoice(int choice)
        {
            switch (choice)
            {
                case 1:
                    AddNewTask();
                    break;
                case 2:
                    ViewTasks();
                    break;
                case 3:
                    MarkTaskCompleted();
                    break;
                case 4:
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("You did not select any choices we have.\nPlease select a choice 1 - 4.");
                    break;
            }
        }

        static void AddNewTask()
        {
            Console.Write("Enter task title: ");
            string? taskTitle = Console.ReadLine();

            if (string.IsNullOrEmpty(taskTitle) || string.IsNullOrWhiteSpace(taskTitle))
            {
                Console.WriteLine("Task title can't be null. Please provide a task title.\n");
                return;
            }

            Console.Write("Enter task description: ");
            string? taskDescription = Console.ReadLine();

            if (string.IsNullOrEmpty(taskDescription) || string.IsNullOrWhiteSpace(taskDescription))
            {
                taskDescription = "No description for this task.";
            }

            tasks.Add(new Task(taskTitle, taskDescription));
            Console.WriteLine($"\nTask \"{taskTitle}\" added.\n");
        }

        static void ViewTasks()
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("\nThere's no task assigned yet.\n");
                return;
            }

            Console.WriteLine("\nTasks:");
            foreach (Task task in tasks)
            {
                Console.WriteLine(task);
            }
        }

        static void MarkTaskCompleted()
        {
            ViewTasks();
            Console.Write("\nEnter the index of the task to mark as completed: ");
            if (int.TryParse(Console.ReadLine(), out int taskId))
            {
                Task? targetTask = tasks.Find(task => task.TaskId == taskId);
                if (targetTask != null)
                {
                    targetTask.TaskCompleted = true;
                    Console.WriteLine("Task marked as completed.\n");
                }
                else
                {
                    Console.WriteLine("No task with the specified ID was found.\n");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a numeric value.\n");
            }
        }
    }
}