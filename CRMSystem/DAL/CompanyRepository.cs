using CRMSystem.Models;
using CRMSystem.Utilities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CRMSystem.DAL
{
    /// <summary>
    /// Responsible for communicating with the database for basic CRUD
    /// </summary>
    public class CompanyRepository : BaseRepository
    {
        public void SaveCompany(Company company)
        {
            //save the company to the database

            SqlConnection connection = CreateConnection();

            try
            {
                connection.Open();
                //Create and configure the command
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO Company(Name, Address, City, Zip, Phone) values('" + company.Name + "', '" + company.Address + "', '" + company.City + "', '" + company.Zip + "', '" + company.Phone + "' )";
                //Execute the command
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

        public List<Company> LoadAllCompanies()
        {
            //Loading all the companies from the database - making the connection, creating and executing the command
            List<Company> result = new List<Company>();
            SqlConnection connection = CreateConnection();

            try
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT Id, Name, Address, City, Zip, Phone from Company";
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Company company = new Company();
                    company.Id = reader.GetInt32(0);
                    company.Name = reader.GetString(1);
                    company.Address = reader.GetString(2);
                    company.City = reader.GetString(3);
                    company.Zip = reader.GetString(4);
                    company.Phone = reader.GetString(5);

                    result.Add(company); 
                }

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


            return result;
        }

        public Company LoadCompany(int id)
        {
            //Loading a company from the database - making the connection, creating and executing the command
            Company result = new Company();
            SqlConnection connection = CreateConnection();

            try
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT Id, Name, Address, City, Zip, Phone from Company WHERE id = " + id;
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                    Company company = new Company();
                    company.Id = reader.GetInt32(0);
                    company.Name = reader.GetString(1);
                    company.Address = reader.GetString(2);
                    company.City = reader.GetString(3);
                    company.Zip = reader.GetString(4);
                    company.Phone = reader.GetString(5);

                    result = company;
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

        public void UpdateCompany(Company company)
        {
            SqlConnection connection = CreateConnection();

            try
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "UPDATE Company set Name ='" + company.Name + "', Address ='" + company.Address + "', City ='" + company.City + "', Zip ='" + company.Zip + "', Phone ='" + company.Phone + "' WHERE ID = " + company.Id;
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

        public void DeleteCompany(int id)
        {
            SqlConnection connection = CreateConnection();

            try
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "DELETE FROM Company WHERE ID = " + id;

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