using System;
using System.Collections.Generic;

namespace ToDoApp
{
    public class Program
    {
        public static List<string> toDoList = new List<string>();

        static void Main(string[] args)
        {
            ToDoList toDoList = new ToDoList();

            string fileLocation = "../../SavedList.txt";
            toDoList.readListFromFile(fileLocation);

            Console.WriteLine("Welcome to your to-do list app! Write:\n" +
                    "Add \"new item\" like Add \"Buy birthday gift to mom\" to add a new task to the to-do list\n" +
                    "Do # + number of task you want to do, like Do #3, to complete a task on the to-do list, and delete it\n" +
                    "Print to print to-do list\n" +
                    "Exit to exit program (remember to exit program properly with Exit command to save your to-do list)\n");


            while (true)
            {

                string input = Console.ReadLine();

                if (input.Length > 6 && input.Substring(0, 5) == "Add \"")
                {
                    toDoList.addToToDoList(input.Substring(4, input.Length - 4));
                }
                else if (input.Length > 4 && input.Substring(0, 4) == "Do #")
                {
                    toDoList.completeToDo(input.Substring(4));
                    toDoList.printToDoList();
                }
                else if (input == "Print")
                {
                    toDoList.printToDoList();
                }
                else if (input == "Exit")
                {
                    toDoList.writeListToFile();
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input, please try again.\n");
                }
            }
        }
    }  
}
