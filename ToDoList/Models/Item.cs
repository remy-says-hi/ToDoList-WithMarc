using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace ToDoList.Models
{

    public class Item
    {
        private string _description;
        private DateTime _dueDate;
        private int _id;
        private int _categoryId;


      public Item (string description, DateTime dueDate, int categoryId,  int id = 0)
      {
          _description = description;
          _dueDate = dueDate;
          _categoryId = categoryId;
          _id = id;
      }

      public string GetDescription()
      {
          return _description;
      }

      public void SetDescription(string newDescription)
      {
          _description = newDescription;
      }

      public string GetDueDate()
      {
          var dueDateToString = _dueDate.ToString("D");
          return dueDateToString;
      }

      public void SetDueDate(DateTime dueDate)
      {
          _dueDate = dueDate;
      }

      public int GetId()
      {
          return _id;
      }

      public int GetCategoryId()
      {
          return _categoryId;
      }

      public static List<Item> GetAll()
      {
          List<Item> allItems = new List<Item> {};
          MySqlConnection conn = DB.Connection();
          conn.Open();
          var cmd = conn.CreateCommand() as MySqlCommand;
          cmd.CommandText = @"SELECT * FROM items;";
          var rdr = cmd.ExecuteReader() as MySqlDataReader;
          while(rdr.Read())
          {
              int itemId = rdr.GetInt32(0);
              string itemDescription = rdr.GetString(1);
              DateTime itemDueDate = rdr.GetDateTime(2);
              int itemCategoryId = rdr.GetInt32(3);
              Item newItem = new Item(itemDescription, itemDueDate, itemCategoryId, itemId);
              allItems.Add(newItem);
          }
          conn.Close();
          if (conn != null)
          {
              conn.Dispose();
          }
          return allItems;
      }

      public static void ClearAll()
      {
          MySqlConnection conn = DB.Connection();
          conn.Open();
          var cmd = conn.CreateCommand() as MySqlCommand;
          cmd.CommandText = @"DELETE FROM items;";
          cmd.ExecuteNonQuery();
          conn.Close();
          if (conn != null)
          {
              conn.Dispose();
          }
      }

      public static Item Find(int id)
      {
          MySqlConnection conn = DB.Connection();
          conn.Open();
          var cmd = conn.CreateCommand() as MySqlCommand;
          cmd.CommandText = @"SELECT * FROM items WHERE id = (@searchId);";
          MySqlParameter searchId = new MySqlParameter();
          searchId.ParameterName = "@searchId";
          searchId.Value = id;
          cmd.Parameters.Add(searchId);
          var rdr = cmd.ExecuteReader() as MySqlDataReader;
          int itemId = 0;
          string itemName = "";
          int itemCategoryId = 0;
          DateTime itemDueDate =  new DateTime(1999, 12, 24);
          while(rdr.Read())
          {
              itemId = rdr.GetInt32(0);
              itemName = rdr.GetString(1);
              itemDueDate = rdr.GetDateTime(2);
              itemCategoryId = rdr.GetInt32(3);
          }
          Item newItem = new Item(itemName, itemDueDate, itemCategoryId, itemId);
          conn.Close();
          if (conn != null)
          {
              conn.Dispose();
          }
          return newItem;
      }

      public override bool Equals(System.Object otherItem)
      {
          if (!(otherItem is Item))
          {
              return false;
          }
          else
          {
              Item newItem = (Item) otherItem;
              bool idEquality = this.GetId() == newItem.GetId();
              bool descriptionEquality = this.GetDescription() == newItem.GetDescription();
              bool dueDateEquality = (this.GetDueDate() == newItem.GetDueDate());
              bool categoryEquality = this.GetCategoryId() == newItem.GetCategoryId();
              return (idEquality && descriptionEquality && dueDateEquality && categoryEquality);
           }
      }

      public void Save()
      {
          MySqlConnection conn = DB.Connection();
          conn.Open();
          var cmd = conn.CreateCommand() as MySqlCommand;
          cmd.CommandText = @"INSERT INTO items (description, dueDate, category_id) VALUES (@description, @dueDate, @category_id);";
          MySqlParameter description = new MySqlParameter();
          description.ParameterName = "@description";
          description.Value = this._description;
          cmd.Parameters.Add(description);
          MySqlParameter categoryId = new MySqlParameter();
          categoryId.ParameterName = "@category_id";
          categoryId.Value = this._categoryId;
          cmd.Parameters.Add(categoryId);
          MySqlParameter dueDate = new MySqlParameter();
          dueDate.ParameterName = "@dueDate";
          dueDate.Value = this._dueDate;
          cmd.Parameters.Add(dueDate);
          cmd.ExecuteNonQuery();
          _id = (int) cmd.LastInsertedId;
          conn.Close();
          if (conn != null)
          {
              conn.Dispose();
          }
      }

      public void Edit(string newDescription)
      {
          MySqlConnection conn = DB.Connection();
          conn.Open();
          var cmd = conn.CreateCommand() as MySqlCommand;
          cmd.CommandText = @"UPDATE items SET description = @newDescription WHERE id = @searchId;";
          MySqlParameter searchId = new MySqlParameter();
          searchId.ParameterName = "@searchId";
          searchId.Value = _id;
          cmd.Parameters.Add(searchId);
          MySqlParameter description = new MySqlParameter();
          description.ParameterName = "@newDescription";
          description.Value = newDescription;
          cmd.Parameters.Add(description);
          cmd.ExecuteNonQuery();
          _description = newDescription;
          conn.Close();
          if (conn != null)
          {
              conn.Dispose();
          }
      }

      public void Delete()
      {
        MySqlConnection conn = DB.Connection();
        conn.Open();
        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"DELETE FROM items WHERE id = @searchId;";
        MySqlParameter searchId = new MySqlParameter();
        searchId.ParameterName = "@searchId";
        searchId.Value = _id;
        cmd.Parameters.Add(searchId);
        cmd.ExecuteNonQuery();
        conn.Close();
        if (conn != null)
        {
            conn.Dispose();
        }
      }

    }

}
