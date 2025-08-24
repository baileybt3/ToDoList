/* ToDoList App
** This program is a ToDoList organizer.
** Made By: Brandon Bailey
** 8/23/2025
*/
using System;
using System.Collections.Generic;
using System.Linq;

public class ToDoList
{

    // To-Do List
    static List<TaskItem> tasks = new List<TaskItem>();
    public static void Main(string[] args)
    {
        int choice = 0;

        while (choice != 5)
        {
            Console.WriteLine("\nPlease select and option: ");
            Console.WriteLine("1. View To-Do List");
            Console.WriteLine("2. Add Task");
            Console.WriteLine("3. Complete Task");
            Console.WriteLine("4. Delete Task");
            Console.WriteLine("5. Quit");

            string input = Console.ReadLine()!;

            if (int.TryParse(input, out choice))
            {
                switch (choice)
                {
                    case 1:
                        ViewList();
                        break;

                    case 2:
                        AddTask();
                        break;

                    case 3:
                        CompleteTask();
                        break;

                    case 4:
                        DeleteTask();
                        break;

                    case 5:
                        Console.WriteLine(" See ya! ");
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please select a valid option");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Please enter a number.");
            }
        }

    }

    // View To-Do List
    public static void ViewList()
    {
        int index = 1;
        Console.WriteLine(" --- To-Do List ---\n");

        if (tasks.Count == 0)
        {
            Console.WriteLine("Your To-Do list is empty");
            return;
        }

        foreach (TaskItem task in tasks.OrderBy(t => t.Priority))
        {
            string status = task.IsCompleted ? "[x]" : "[ ]";
            string priorityName = task.Priority == 1 ? "High" : task.Priority == 2 ? "Medium" : "Low";
            Console.WriteLine($"{index}: {status} {task.Description} (Priority: {priorityName})");
            index++;
        }

    }

    // Add Task
    public static void AddTask()
    {
        Console.WriteLine(" --- Add Task ---");
        Console.Write("Enter task description: ");
        string desc = Console.ReadLine()!;

        Console.Write("\nEnter priority  (1 = High, 2 = Medium, 3 = Low): ");
        int priority;

        while (!int.TryParse(Console.ReadLine(), out priority) || priority < 1 || priority > 3)
        {
            Console.Write("Invalid input. Please enter 1, 2, or 3: ");
        }

        tasks.Add(new TaskItem(desc, priority));
        Console.WriteLine($"Added: {desc} (Priority {priority})");
    }


    // Complete Task
    public static void CompleteTask()
    {

        Console.WriteLine(" --- Select Task to Complete ---");

        for (int i = 0; i < tasks.Count; i++)
        {
            Console.WriteLine($"{i + 1}: {tasks[i].Description}");
        }

        Console.Write("Enter the number of the task to mark complete: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= tasks.Count)
        {
            tasks[index - 1].IsCompleted = true;
            Console.WriteLine($"Task marked complete: {tasks[index - 1].Description}");
        }
        else
        {
            Console.WriteLine("Invalid selection.");
        }

    }

    // Delete Task
    public static void DeleteTask()
    {
        Console.WriteLine(" --- Delete Task  ---");

        if (tasks.Count == 0)
        {
            Console.WriteLine("Your To-Do List is empty");
            return;
        }

        Console.WriteLine("Enter the number of the task you want to delete: ");
        string input = Console.ReadLine()!;

        if (int.TryParse(input, out int index) && index > 0 && index <= tasks.Count)
        {
            Console.WriteLine($"Removed: {tasks[index - 1].Description}");
            tasks.RemoveAt(index - 1);
        }
        else
        {
            Console.WriteLine("Invalid selection.");
        }
    }


}

public class TaskItem
{
    public string Description { get; set; }
    public int Priority { get; set; }
    public bool IsCompleted { get; set; }

    public TaskItem(string description, int priority)
    {
        Description = description;
        Priority = priority;
        IsCompleted = false;
    }

    public override string ToString()
    {
        string status = IsCompleted ? "[x]" : "[ ]";
        string priorityName = Priority == 1 ? "High" : Priority == 2 ? "Medium" : "Low";
        return $"{status} {Description} (Priority: {priorityName})";
    }
}