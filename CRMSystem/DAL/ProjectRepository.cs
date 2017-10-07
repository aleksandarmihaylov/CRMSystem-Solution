using CRMSystem.Models;
using CRMSystem.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CRMSystem.DAL
{
    /// <summary>
    /// Responsible for communicating with the database for basic CRUD
    /// </summary>
    public class ProjectRepository : BaseRepository
    {
        public void SaveProject(Project project)
        {
            SqlConnection connection = CreateConnection();

            try
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                //defending from SQL injection
                command.CommandText = "INSERT INTO Project(Name, Description) values(@name, @description)";
                command.Parameters.Add("@name",SqlDbType.NVarChar).Value = project.Name;
                command.Parameters.Add("@description", SqlDbType.NText).Value = project.Description;
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

        public List<Project> LoadAllProjects()
        {
            List<Project> result = new List<Project>();
            SqlConnection connection = CreateConnection();

            try
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT Id, Name, Description from Project";
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Project project = new Project();
                    project.Id = reader.GetInt32(0);
                    project.Name = reader.GetString(1);
                    project.Description = reader.GetString(2);

                    result.Add(project);
                }
            }
            catch(Exception ex)
            {
                Log.LogException(ex);
            }
            finally
            {
                connection.Close();
            }
            return result;
        }

        //Loading a project from the database - making the connection, creating and executing the command
        public Project LoadProject(int id)
        {
            Project result = new Project();
            SqlConnection connection = CreateConnection();

            try
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT Id, Name, Description from Project WHERE ID = " + id;
                SqlDataReader reader = command.ExecuteReader();
                // Do we need reader.Read() in order to start reading? 
                reader.Read();
                // is there a sence in doing that ? ask teacher ? 
                Project project = new Project();
                project.Id = reader.GetInt32(0);
                project.Name = reader.GetString(1);
                project.Description = reader.GetString(2);

                result = project;
            }
            catch (Exception ex)
            {
                Log.LogException(ex);
            }
            finally
            {
                connection.Close();
            }
            return result;
        }

        public void UpdateProject(Project project)
        {
            SqlConnection connection = CreateConnection();

            try
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                //defence against sql injection
                command.CommandText = "UPDATE Project set Name = @name , Description = @description WHERE ID = " + project.Id;
                command.Parameters.Add("@name", SqlDbType.NVarChar).Value = project.Name;
                command.Parameters.Add("@description", SqlDbType.NText).Value = project.Description;
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //Logging
                Log.LogException(ex);
            }
            finally
            {
                connection.Close();
            }
        }

        public void DeleteProject(int id)
        {
            SqlConnection connection = CreateConnection();

            try
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "DELETE FROM Project WHERE Id = " + id;
                command.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                Log.LogException(ex);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}