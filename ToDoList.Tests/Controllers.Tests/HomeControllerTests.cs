using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ToDoList.Controllers;
using ToDoList.Models;

namespace ToDoList.Tests
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index_ReturnsCorrectView_True()
        {
            //Arrange
            HomeController controller = new HomeController();

            //Act
            ActionResult indexView = controller.Index();

            //Assert
            Assert.IsInstanceOfType(indexView, typeof(ViewResult));
        }
        // 
        // [TestMethod]
        // public void Index_HasCorrectModelType_ItemList()
        // {
        //     //Arrange
        //      ViewResult indexView = new HomeController().Index() as ViewResult;
        //
        //     //Act
        //     var result = indexView.ViewData.Model;
        //
        //     //Assert
        //     Assert.IsInstanceOfType(result, typeof(List<Item>));
        // }

        // [TestMethod]
        // public void Create_ReturnsCorrectActionType_RedirectToActionResult()
        // {
        //     //Arrange
        //     HomeController controller = new HomeController();
        //
        //     //Act
        //     IActionResult view = controller.Create("Walk the dog");
        //
        //     //Assert
        //     Assert.IsInstanceOfType(view, typeof(RedirectToActionResult));
        // }
        //
        // [TestMethod]
        // public void Create_RedirectsToCorrectAction_Index()
        // {
        //     //Arrange
        //     HomeController controller = new HomeController();
        //     RedirectToActionResult actionResult = controller.Create("Walk the dog") as RedirectToActionResult;
        //
        //     //Act
        //     string result = actionResult.ActionName;
        //
        //     //Assert
        //     Assert.AreEqual(result, "Index");
        // }

    }
}
