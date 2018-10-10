using System;
using System.Collections.Generic;
using System.IO;

namespace ToDoApp
{
    public class ToDoList
    {
        private List<string> toDoList;

        public ToDoList()
        {
            toDoList = new List<string>();
        }

        /**
        * Used to add a to-do item to the to-do list. 
        * Takes a string as input that needs to have quotation marks at the start and end.
        * Returns true if succsessful and false if not.
        */
        public bool addToToDoList(string newItem)
        {

            if (newItem.Substring(0, 1) == "\"" && newItem.Substring(newItem.Length - 1, 1) == "\"")
            {
                if (newItem.Length <= 2)
                {
                    Console.WriteLine("A new to-do item cannot be empty. Please try again.\n");
                    return false;
                }
                toDoList.Add(newItem.Substring(1, newItem.Length - 2));
                return true;
            }

            Console.WriteLine("To-do item need to be in quotation marks, like \"Buy a fish at the store for dinner\". Please try again.\n");
            return false;
        }

        /**
         * Used to complete a to-do item on the to do list.
         * Takes the index of the item in the list + 1.
         * Returns true if succsessful and false if not.
         */
        public bool completeToDo(string itemIndex)
        {
            int toDoNumber = 0;
            if (Int32.TryParse(itemIndex, out toDoNumber) && toDoNumber >= 1 && toDoNumber <= toDoList.Count)
            {
                Console.WriteLine("Completed " + toDoList[toDoNumber - 1]);
                toDoList.RemoveAt(toDoNumber - 1);
                return true;
            }
            Console.WriteLine("That to-do item does not exists, please try again\n");
            return false;
        }

        /**
         * Prints out a list of the current items on the to-do list. Prints out "List empty" if the list is empty.
         */
        public void printToDoList()
        {
            Console.WriteLine("\nYour to-do list:");
            if (toDoList.Count == 0)
            {
                Console.WriteLine("List empty\n");
            }
            else
            {
                for (int i = 0; i < toDoList.Count; i++)
                {
                    Console.WriteLine("#" + (i + 1) + " " + toDoList[i]);
                }
                Console.WriteLine("");
            }

        }

        /**
         * Saves the current toDoList to a .txt file.
         * Returns true if successful, and false if not.
         */
        public bool writeListToFile()
        {
            TextWriter tw = new StreamWriter("../../SavedList.txt");

            try
            {
                foreach (String s in toDoList)
                {
                    Console.WriteLine(s);
                    tw.WriteLine(s);
                }

                tw.Close();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong when saving to file: " + e);
            }
      
            return false;
        }

        /**
         * Reads a list from file and then returns it as a List.
         * Input is a string location that is the location of the file.
         * Returns a list with items if a List exists in the chosen location, and 
         * returns an empty List if there is no such List.
         */
        public List<string> readListFromFile(string location)
        {

            try
            {
                var logFile = File.ReadAllLines(location);
                toDoList = new List<string>(logFile);
                return toDoList;
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("The file was not found: " + e);
            } catch (Exception e)
            {
                Console.WriteLine("Something when wrong while reading from file: " + e);
            }
            return new List<string>();
        }

    }
}
