using System;
using System.Collections.Generic;

namespace ToDoList.Models
{
  public class Program
  {

     public static void Main()
     {
       //List<Item> toDoList = new List<Item> {};
       Console.WriteLine("Welcome to the to do list");
       bool keepGoing = true;
       string userInput = "";
       while(keepGoing == true)
       {
         Console.WriteLine("Would you like to add an item or view your to do list? (A for Add/V for View/Q for Quit)");
         userInput = Console.ReadLine().ToUpper();
         if(userInput == "Q")
         {
           keepGoing = false;
         }else if(userInput == "A"){
           Console.WriteLine("Please enter a to do item: ");
           userInput = Console.ReadLine();
           Item toDoItem = new Item(userInput);
         }else if(userInput == "V" )
         {
           foreach (Item task in Item.GetAll())
           {
             Console.WriteLine(task.GetDescription());
           }
         }
       }



     }

  }
}
