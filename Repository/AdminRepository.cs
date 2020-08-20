using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Truyum.Models;

namespace Truyum.Repository
{
    public class AdminRepository:IAdminRepository
    {

        string connectionString = "Data Source=DESKTOP-JC6IUA3\\SQLEXPRESS;Initial Catalog=TruyumDB;Persist Security Info=True;User ID=sa;Password=12345";
        public void AddItem(MenuItems item)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("INSERT INTO MenuItems(ItemName, Price,Category,Date,FreeDelivery,Active) VALUES(@ItemName, @Price,@Category,@Date,@FreeDelivery,@Active)", con);
                command.Parameters.AddWithValue("@ItemName", item.ItemName);
                command.Parameters.AddWithValue("@Price", item.Price);
                command.Parameters.AddWithValue("@Category", item.Category);
                command.Parameters.AddWithValue("@Date", item.Date);
                command.Parameters.AddWithValue("@FreeDelivery", item.FreeDelivery);
                command.Parameters.AddWithValue("@Active", item.Active);

                con.Open();
                command.ExecuteNonQuery();
                con.Close();
            }
        }

        public void DeleteItem(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM MenuItems WHERE ItemId=@ItemId", con);


                cmd.Parameters.AddWithValue("@ItemId", id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public List<MenuItems> GetAllItems()
        {
            List<MenuItems> listItem = new List<MenuItems>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("select * from MenuItems", con);
                con.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    MenuItems item = new MenuItems();
                    item.ItemId = Convert.ToInt32(reader["ItemId"]);
                    item.ItemName = reader["ItemName"].ToString();
                    item.Price = reader["Price"].ToString();
                    item.Category = reader["Category"].ToString();
                    item.Date = reader["Date"].ToString();
                    item.FreeDelivery = reader["FreeDelivery"].ToString();
                    item.Active = reader["Active"].ToString();

                    listItem.Add(item);
                }
                con.Close();
            }
            return listItem;
        }

        public MenuItems GetItemById(int? id)
        {

            MenuItems item = new MenuItems();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM MenuItems WHERE ItemId= " + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    item.ItemId = Convert.ToInt32(rdr["ItemId"]);
                    item.ItemName = rdr["ItemName"].ToString();
                    item.Price = rdr["Price"].ToString();
                    item.Category = rdr["Category"].ToString();
                    item.Date = rdr["Date"].ToString();
                    item.FreeDelivery = rdr["FreeDelivery"].ToString();
                    item.Active = rdr["Active"].ToString();
                }
            }
            return item;

        }

        public void UpdateItem(MenuItems item)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("UPDATE MenuItems SET ItemName=@ItemName, Price=@Price,Category=@Category,Date=@Date, FreeDelivery=@FreeDelivery, Active=@Active Where ItemId=@ItemId", con);
                command.Parameters.AddWithValue("@ItemId", item.ItemId);
                command.Parameters.AddWithValue("@ItemName", item.ItemName);
                command.Parameters.AddWithValue("@Price", item.Price);
                command.Parameters.AddWithValue("@Category", item.Category);
                command.Parameters.AddWithValue("@Date", item.Date);
                command.Parameters.AddWithValue("@FreeDelivery", item.FreeDelivery);
                command.Parameters.AddWithValue("@Active", item.Active);

                con.Open();
                command.ExecuteNonQuery();
                con.Close();
            }
        }

    }
}


