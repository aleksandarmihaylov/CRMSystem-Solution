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
    public class TaskRepository : BaseRepository
    {
        public void SaveTask(Task task)
        {
            SqlConnection connection = CreateConnection();

            try
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO Task(Name, Description, Hours, IsFinished, ContactId, ProjectId) values(@name, @description, @hours, @isfinished, @contactid, @projectid)";
                command.Parameters.Add("@name",SqlDbType.NVarChar).Value = task.Name;
                command.Parameters.Add("@description", SqlDbType.NText).Value = task.Description;
                command.Parameters.Add("@hours", SqlDbType.Int).Value = task.Hours;
                //when created the task is not finished so you dont need to set it it is set automatically 
                command.Parameters.Add("@isfinished", SqlDbType.Bit).Value = false;
                command.Parameters.Add("@contactid", SqlDbType.Int).Value = task.ContactId;
                command.Parameters.Add("@projectid", SqlDbType.Int).Value = task.ProjectId;

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Log.LogException(ex);
            }
            finally
            {
                connection.Close();
            }
        }

        public List<Task> LoadAllTasks()
        {
            List<Task> result = new List<Task>();

            SqlConnection connection = CreateConnection();

            try
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT Id, Name, Description, Hours, IsFinished, ContactId, ProjectId FROM Task";
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Task task = new Task();
                    task.Id = reader.GetInt32(0);
                    task.Name = reader.GetString(1);
                    task.Description = reader.GetString(2);
                    task.Hours = reader.GetInt32(3);
                    task.IsFinished = reader.GetBoolean(4);
                    task.ContactId = reader.GetInt32(5);
                    task.ProjectId = reader.GetInt32(6);

                    result.Add(task);
                }
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

        public Task LoadTask(int id)
        {
            Task result = new Task();
            SqlConnection connection = CreateConnection();

            try
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT Id, Name, Description, Hours, IsFinished, ContactId, ProjectId FROM Task WHERE ID = " + id;
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();

                Task task = new Task();
                task.Id = reader.GetInt32(0);
                task.Name = reader.GetString(1);
                task.Description = reader.GetString(2);
                task.Hours = reader.GetInt32(3);
                task.IsFinished = reader.GetBoolean(4);
                task.ContactId = reader.GetInt32(5);
                task.ProjectId = reader.GetInt32(6);

                result = task;
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

        public void UpdateTask(Task task)
        {
            SqlConnection connection = CreateConnection();

            try
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "UPDATE Task set Name = @name, Description = @description, Hours = @hours, IsFinished = @isfinished, ContactId = @contactid, ProjectId = @projectid WHERE ID = " + task.Id;
                command.Parameters.Add("@name", SqlDbType.NVarChar).Value = task.Name;
                command.Parameters.Add("@description", SqlDbType.NText).Value = task.Description;
                command.Parameters.Add("@hours", SqlDbType.Int).Value = task.Hours;
                //when update the task we can set if the task is finished or not
                command.Parameters.Add("@isfinished", SqlDbType.Bit).Value = task.IsFinished;
                command.Parameters.Add("@contactid", SqlDbType.Int).Value = task.ContactId;
                command.Parameters.Add("@projectid", SqlDbType.Int).Value = task.ProjectId;
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Log.LogException(ex);
            }
            finally
            {
                connection.Close();
            }
        }

        public void DeleteTask(int id)
        {
            SqlConnection connection = CreateConnection();

            try
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "DELETE FROM Task WHERE ID = " + id;
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
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