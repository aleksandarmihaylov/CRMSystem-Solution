using CRMSystem.Models;
using CRMSystem.Utilities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CRMSystem.DAL
{
    public class ContactRepository : BaseRepository
    {
        public void SaveContact(Contact contact)
        {
            //save the contact to the database

            SqlConnection connection = CreateConnection();

            try
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO Contact(FirstName, LastName, Address, City, Zip, Phone) values('" + contact.FirstName + "','" + contact.LastName + "', '" + contact.Address + "', '" + contact.City + "', '" + contact.Zip + "', '" + contact.Phone + "' )";
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //logging
                Log.LogException(ex);
            }
            finally
            {
                connection.Close();
            }
        }

        public List<Contact> LoadAllContacts()
        {
            List<Contact> result = new List<Contact>();

            SqlConnection connection = CreateConnection();

            try
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT Id, FirstName, LastName, Address, City, Zip, Phone FROM Contact";
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Contact contact = new Contact();
                    contact.Id = reader.GetInt32(0);
                    contact.FirstName = reader.GetString(1);
                    contact.LastName = reader.GetString(2);
                    contact.Address = reader.GetString(3);
                    contact.City = reader.GetString(4);
                    contact.Zip = reader.GetString(5);
                    contact.Phone = reader.GetString(6);

                    result.Add(contact);

                }
            }
            catch (Exception ex)
            {
                //logging
                Log.LogException(ex);
            }
            finally
            {
                connection.Close();
            }
            return result;
        }

        public Contact LoadContact(int id)
        {
            Contact result = new Contact();

            SqlConnection connection = CreateConnection();

            try
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT Id, FirstName, LastName, Address, City, Zip, Phone FROM Contact WHERE ID = " + id;
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                Contact contact = new Contact();
                contact.Id = reader.GetInt32(0);
                contact.FirstName = reader.GetString(1);
                contact.LastName = reader.GetString(2);
                contact.Address = reader.GetString(3);
                contact.City = reader.GetString(4);
                contact.Zip = reader.GetString(5);
                contact.Phone = reader.GetString(6);

                result = contact;

            }
            catch (Exception ex)
            {
                //logging
                Log.LogException(ex);
            }
            finally
            {
                connection.Close();
            }
            return result;
        }

        public void UpdateContact(Contact contact)
        {
            SqlConnection connection = CreateConnection();

            try
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "UPDATE Contact set FirstName ='" + contact.FirstName + "', LastName ='" + contact.LastName + "', Address ='" + contact.Address + "', City ='" + contact.City + "', Zip ='" + contact.Zip + "', Phone ='" + contact.Phone + "' WHERE ID = " + contact.Id;
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //logging
                Log.LogException(ex);
            }
            finally
            {
                connection.Close();
            }
        }

        public void DeleteContact (int id)
        {
            SqlConnection connection = CreateConnection();

            try
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "DELETE FROM Contact WHERE ID = "+ id;
                command.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                //logging
                Log.LogException(ex);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}