﻿using Library.Core;
using Library.Core.ControllerHelperClasses;
using Library.Models.Inputs;
using Library.Models.Outputs;
using Library.PostgresRepository.Abstract;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.PostgresRepository
{ 
    public class PgBook : MainPgRepository, IPgBook
    {      
        public PgBook(DbSettings _dbSettings) : base(_dbSettings) { }

        public ItemResult Get(int id)
        {
            ItemResult itemResult = new ItemResult();
            
            using (NpgsqlConnection connection = this.CreateConnection())
            {
                connection.Open();
                this.CreateFunctionCallQuery(this.LibraryFunctions.fn_book_get, connection);                
                this.Cmd.Parameters.AddWithValue("p_book_id", id);
                
                try
                {
                    using (var dataReader = this.Cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            itemResult.Item = Newtonsoft.Json.JsonConvert.DeserializeObject<Book>((string)dataReader[0]);
                        }
                    }
                    connection.Close();
                }
                catch (PostgresException e)
                {
                    itemResult.Code = e.ToString();
                }

            }

            return itemResult;
        }
        
        public ItemResult GetAll()
        {
            ItemResult itemResult = new ItemResult();

            using (NpgsqlConnection connection = this.CreateConnection())
            {
                connection.Open();
                this.CreateFunctionCallQuery(this.LibraryFunctions.fn_book_get_all, connection);

                try
                {
                    using (var dataReader = this.Cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            itemResult.Item = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Book>>((string)dataReader[0]);
                        }
                    }
                    connection.Close();
                }
                catch (PostgresException e)
                {
                    itemResult.Code = e.ToString();
                }
            }

            return itemResult;
        }
        
        public ItemResult Add(IBook newBook)
        {
            ItemResult itemResult = new ItemResult();

            using (NpgsqlConnection connection = this.CreateConnection())
            {
                connection.Open();
                this.CreateFunctionCallQuery(this.LibraryFunctions.fn_book_add, connection);
                this.Cmd.Parameters.AddWithValue("p_book_name", newBook.Name);
                this.Cmd.Parameters.AddWithValue("p_author_id", newBook.AuhorId);
                this.Cmd.Parameters.AddWithValue("p_language_id", newBook.LanguageId);
                this.Cmd.Parameters.AddWithValue("p_publishing_house_id", newBook.PublishingHouseId);
                this.Cmd.Parameters.AddWithValue("p_category_id", newBook.CategoryId);
                this.Cmd.Parameters.AddWithValue("p_book_location_id", newBook.LocationId);
                this.Cmd.Parameters.AddWithValue("p_rating", newBook.Rating);

                try
                {
                    using (var dataReader = this.Cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            itemResult.Item = Newtonsoft.Json.JsonConvert.DeserializeObject<Book>((string)dataReader[0]);
                        }
                    }
                    connection.Close();
                }
                catch (PostgresException e)
                {
                    itemResult.Code = e.ToString();
                }

            }

            return itemResult;
        }

        public ItemResult Edit(IBook editedBook)
        {
            ItemResult itemResult = new ItemResult();

            using (NpgsqlConnection connection = this.CreateConnection())
            {
                connection.Open();
                this.CreateFunctionCallQuery(this.LibraryFunctions.fn_book_edit, connection);
                this.Cmd.Parameters.AddWithValue("p_book_id", editedBook.Id);
                this.Cmd.Parameters.AddWithValue("p_book_name", editedBook.Name);
                this.Cmd.Parameters.AddWithValue("p_author_id", editedBook.AuhorId);
                this.Cmd.Parameters.AddWithValue("p_language_id", editedBook.LanguageId);
                this.Cmd.Parameters.AddWithValue("p_publishing_house_id", editedBook.PublishingHouseId);
                this.Cmd.Parameters.AddWithValue("p_category_id", editedBook.CategoryId);
                this.Cmd.Parameters.AddWithValue("p_book_location_id", editedBook.LocationId);
                this.Cmd.Parameters.AddWithValue("p_rating", editedBook.Rating);

                try
                {
                    using (var dataReader = this.Cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            itemResult.Item = Newtonsoft.Json.JsonConvert.DeserializeObject<Book>((string)dataReader[0]);
                        }
                    }
                    connection.Close();
                }
                catch (PostgresException e)
                {
                    itemResult.Item = e.ToString();
                }

            }

            return itemResult;
        }

        public ItemResult Delete(int id)
        {
            ItemResult itemResult = new ItemResult();

            using (NpgsqlConnection connection = this.CreateConnection())
            {
                connection.Open();
                this.CreateFunctionCallQuery(this.LibraryFunctions.fn_book_delete, connection);
                this.Cmd.Parameters.AddWithValue("p_book_id", id);

                try
                {
                    using (var dataReader = this.Cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            itemResult.Item = (int) dataReader[0];
                        }
                    }
                    connection.Close();
                }
                catch (PostgresException e)
                {
                    itemResult.Code = e.ToString();
                }

            }

            return itemResult;
        }       
    }
}
