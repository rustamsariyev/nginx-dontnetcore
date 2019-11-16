using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Library.Core;
using Library.Core.ControllerHelperClasses;
using Library.Core.Postgresql;
using Library.Models.Inputs;
using Library.Models.Outputs;
using Library.PostgresRepository;
using Library.PostgresRepository.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Npgsql;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : LibraryControllerBase
    {
        public readonly IPgBook pgBook;
        private readonly DbSettings dbSettings;
        private readonly ILogger logger;

        public BookController(IPgBook _pgBook, DbSettings _dbSettings, ILogger<BookController> _logger) : base(_dbSettings)
        {
            pgBook = _pgBook;
            dbSettings = _dbSettings;
            logger = _logger;
        }

        /// <summary>
        /// Get all books.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Book
        ///     {
        ///        
        ///     }
        ///
        /// </remarks>
        /// <param></param>
        /// <returns>
        /// {
        ///   "childResult": [
        ///       {
        ///           "id": 6,
        ///           "name": "putted_book",
        ///           "auhorId": 1,
        ///           "languageId": 1,
        ///            "publishingHouseId": 1,
        ///           "categoryId": 3,
        ///           "locationId": 1,
        ///           "updatedBy": null,
        ///           "deletedBy": null,
        ///          "updatedOn": null,
        ///           "deletedOn": null,
        ///           "isDeleted": false,
        ///           "rating": 5
        ///      },
        ///      {
        ///          "id": 5,
        ///          "name": "book2",
        ///           "auhorId": 1,
        ///           "languageId": 1,
        ///           "publishingHouseId": 1,
        ///           "categoryId": 3,
        ///           "locationId": 1,
        ///            "updatedBy": null,
        ///            "deletedBy": null,
        ///            "updatedOn": null,
        ///            "deletedOn": null,
        ///            "isDeleted": true,
        ///           "rating": 5
        ///      }
        ///      ],
        ///   "code": null,
        ///   "message": null
        /// }
        /// </returns>
        /// <response code="200">Returns all books</response>
        /// <response code="404">If the books don't exist</response> 
        // GET: api/Book 
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ItemResult Get()
        {            
            return pgBook.GetAll();
        }

        /// <summary>
        /// Get a book.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Book
        ///     {
        ///     
        ///     }
        ///
        /// </remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">Returns the book with given id</response>
        /// <response code="404">If the book don't exist</response> 
        // GET: api/Book/5
        [HttpGet("{id}", Name = "Get")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ItemResult Get(int id)
        {            
            return pgBook.Get(id);
        }

        /// <summary>
        /// Creates a book.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Book
        ///     {
        ///        {
        ///             "name": "book_new_created",
        ///             "auhorId": 1,
        ///             "languageId": 1,
        ///             "publishingHouseId": 1,
        ///             "categoryId": 3,
        ///             "locationId": 1,
        ///             "updatedBy": null,
        ///             "deletedBy": null,
        ///             "updatedOn": null,
        ///             "deletedOn": null,
        ///             "isDeleted": false,
        ///             "rating": 5
        ///         }
        ///     }
        ///
        /// </remarks>
        /// <param name="newBook"></param>
        /// <returns></returns>
        /// <response code="201">Returns the newly created book</response>
        /// <response code="400">The request body's Book object is invalid.</response> 
        // POST: api/Book
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ItemResult Post(IBook newBook)
        {
            return pgBook.Add(newBook);
        }

        /// <summary>
        /// Updates the book.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Book
        ///     {
        ///        {
        ///             "name": "putted_book",
        ///             "auhorId": 1,
        ///             "languageId": 1,
        ///             "publishingHouseId": 1,
        ///             "categoryId": 3,
        ///             "locationId": 1,
        ///             "updatedBy": null,
        ///             "deletedBy": null,
        ///             "updatedOn": null,
        ///             "deletedOn": null,
        ///             "isDeleted": false,
        ///             "rating": 5
        ///         }
        ///     }
        ///
        /// </remarks>
        /// <param name="id"></param>
        /// <param name="updatedBook"></param>
        /// <returns></returns>
        /// <response code="200">Returns the newly updated book</response>
        /// <response code="400">The request body's Id value doesn't match the route's id value.</response> 
        /// <response code="400">The request body's Book object is invalid.</response> 
        // PUT: api/Book/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ItemResult Put(int id, IBook updatedBook)
        {
            ItemResult pr = new ItemResult();
            updatedBook.Id = id;

            logger.LogInformation("Book updated occured: book_id: " + updatedBook.Id);
            return pgBook.Edit(updatedBook);
        }

        /// <summary>
        /// Deletes a book.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Book
        ///     {   
        ///         "id": 4  
        ///     }
        ///
        /// </remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="204">Returns the newly deleted book</response>
        /// <response code="404">A book matching the provided id parameter doesn't exist in the database.</response> 
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ItemResult Delete(int id)
        {
            logger.LogInformation("Book deleted occured: book_id: " + id);
            return pgBook.Delete(id);
        }
    }
}
