using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;

namespace ToDoApp.UnitTests
{
    [TestClass]
    public class ToDoListTests
    {
        [TestMethod]
        public void addToToDoList_InputInCorrectFormat_ReturnTrue()
        {
            ToDoList toDoList = new ToDoList();

            var result = toDoList.addToToDoList("\"Buy a fish at the store\"");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void AddToToDoList_InputNotInCorrectFormat_ReturnFalse()
        {
            ToDoList toDoList = new ToDoList();

            var result = toDoList.addToToDoList("\"Buy a fish at the store");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void completeToDo_IndexIsValid_ReturnTrue()
        {
            ToDoList toDoList = new ToDoList();
            toDoList.addToToDoList("\"Buy a fish at saturday!\"");

            var result = toDoList.completeToDo("1");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void completeToDo_IndexIsInvalid_ReturnFalse()
        {
            ToDoList toDoList = new ToDoList();
            toDoList.addToToDoList("\"Buy a fish at saturday!\"");

            var result = toDoList.completeToDo("a");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void readListFromFile_LocationIsCorrect_ReturnListWithElements()
        {
            ToDoList toDoList = new ToDoList();
            toDoList.addToToDoList("\"Buy a fish at saturday!\"");
            toDoList.writeListToFile();

            var result = toDoList.readListFromFile("../../SavedList.txt");
            Assert.IsTrue(result.Count > 0);

            deleteFile("../../SavedList.txt"); 
        }

        [TestMethod]
        public void readListFromFile_LocationIsCorrect_ReturnListWithoutElements()
        {
            ToDoList toDoList = new ToDoList();
            toDoList.addToToDoList("\"Buy a fish at saturday!\"");
            toDoList.writeListToFile();

            var result = toDoList.readListFromFile("wrongFileName.txt");
            Assert.IsTrue(result.Count == 0);

            deleteFile("../../SavedList.txt");
        }

        [TestMethod]
        public void writeListToFile_CheckIfWritingIsSuccessful()
        {
            ToDoList toDoList = new ToDoList();
            string insert = "\"Buy a fish at saturday!\"";
            toDoList.addToToDoList(insert);

            var result = toDoList.writeListToFile();
            Assert.IsTrue(result);

            deleteFile("../../SavedList.txt");
        }

        public void deleteFile(string location)
        {
            if (File.Exists(location))
            {
                File.Delete(location);
            }
        }
    }
}
