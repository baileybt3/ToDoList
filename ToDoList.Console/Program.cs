/* ToDoList App
** This program is a ToDoList organizer.
** Made By: Brandon Bailey
** 8/23/2025
*/
using System;

public class ToDoList
{


    public static void Main(string[] args)
    {
        int choice = 0;

        while (choice != 5)
        {
            Console.WriteLine("\nPlease select and option: ");
            Console.WriteLine("1. View To-Do List");
            Console.WriteLine("2. Edit To-Do List");
            Console.WriteLine("3. Delete To-Do List");
            Console.WriteLine("4. Help");
            Console.WriteLine("5. Quit");

            string input = Console.ReadLine()!;

            if (int.TryParse(input, out choice))
            {
                switch (choice)
                {
                    case 1:
                        Console.WriteLine(" --- To-Do List ---");
                        break;
                    case 2:
                        Console.WriteLine(" --- Editing To-Do List ---");
                        break;
                    case 3:
                        Console.WriteLine(" --- Deleting To-Do List ---");
                        break;
                    case 4:
                        Console.WriteLine(" --- Help ---");
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
}