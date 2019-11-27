using System;
using System.Collections.Generic;
using Xunit;

namespace Test
{
    public class UnitTest1
    {
        [Fact]
        //Add 2 entries to the list
        public void Test1()
        {
            //Arrange
            Menu menu = new Menu(); 
            Task task1 = new TaskType1(1, "Task 1", Status.leftToDo, true);
            Task task2 = new TaskType2(2, "Task 2", Status.Done, DateTime.Today);
            menu.unfinishedList.Add(task1);
            menu.unfinishedList.Add(task2);

            //Act
            var expected = 2;
            var result = menu.unfinishedList.Count;
            
            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        //Mark a task as completed
        public void Test2()
        {
            //Arrange
            Menu menu = new Menu();
            Task task1 = new TaskType1(1, "Task 1", Status.leftToDo, true);
            menu.unfinishedList.Add(task1);

            //Act
            var expected = Status.Done;
            menu.markTaskComplete(1);
            
            //Assert
            Assert.Equal(expected, menu.unfinishedList[0].getStatus());
        }

        [Fact]
        //Archive all completed information
        public void Test3()
        {
            //Arrange
            Menu menu = new Menu();
            Task task1 = new TaskType1(1, "Task 1", Status.leftToDo, true);
            Task task2 = new TaskType1(2, "Task 2", Status.Done, true);
            Task task3 = new TaskType2(3, "Task 3", Status.leftToDo, DateTime.Today);
            Task task4 = new TaskType2(4, "Task 4", Status.Done, DateTime.Today);
            menu.unfinishedList.Add(task1);
            menu.unfinishedList.Add(task2);
            menu.unfinishedList.Add(task3);
            menu.unfinishedList.Add(task4);

            //Act
            List<Task> expected = new List<Task>(); 
            expected.Add(task2);
            expected.Add(task4);
            menu.archiveAllTasks();
            
            //Assert
            Assert.Equal(expected, menu.finishedList);
        }
    }
}
