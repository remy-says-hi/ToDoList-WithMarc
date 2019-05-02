using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using System.Collections.Generic;

namespace ToDoList.Controllers
{
    public class ItemsController : Controller
    {

        [HttpGet("/items")]
        public ActionResult Index()
        {
            List<Item> allItems = Item.GetAll();
            return View(allItems);
        }

        [HttpGet("/categories/{categoryId}/items/new")]
        public ActionResult New(int categoryId)
        {
            Category category = Category.Find(categoryId);
            return View(category);
        }

// There seems to be a bug with this route when adding an item

        [HttpPost("/categories/{categoryId}/items")]
        public ActionResult Create(int categoryId, string itemDescription)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Category foundCategory = Category.Find(categoryId);
            Item newItem = new Item(itemDescription);
            foundCategory.AddItem(newItem);
            List<Item> categoryItems = foundCategory.GetItems();
            model.Add("items", categoryItems);
            model.Add("category", foundCategory);
            return View("Show", model);
        }

        [HttpPost("/items/delete")]
        public ActionResult DeleteAll()
        {
            Item.ClearAll();
            return View();
        }

        [HttpGet("/categories/{categoryId}/items/{itemId}")]
        public ActionResult Show(int categoryId, int itemId)
        {
            Item item = Item.Find(itemId);
            Dictionary<string, object> model = new Dictionary<string, object>();
            Category category = Category.Find(categoryId);
            model.Add("item", item);
            model.Add("category", category);
            return View(model);
        }

    }
}
