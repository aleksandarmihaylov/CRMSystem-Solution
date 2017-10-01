using CRMSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CRMSystem.DAL
{
    public class ContactRepository
    {
        public void SaveContact(Contact contact)
        {
            //save the contact to the database

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = Connection.ConnectionString;

            try
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO Contact(FirstName, LastName, Address, City, Zip, Phone) values('" + contact.FirstName + "','" + contact.LastName + "', '" + contact.Address + "', '" + contact.City + "', '" + contact.Zip + "', '" + contact.Phone + "' )";
                command.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                //logging
            }
            finally
            {
                connection.Close();
            }
        }
    }
}