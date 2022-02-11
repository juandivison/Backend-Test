using Backend.WebApi.Data;
using Backend.WebApi.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.WebApi.Controllers
{
    [ApiController]
    [Route("[api/controller]")]
    public class BooksController : ControllerBase
    {
        
        private readonly IBookRepository bookRepository; 
        public BooksController(IBookRepository _bookRepository)
        {
            this.bookRepository = _bookRepository;            
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            return Ok(this.bookRepository.GetAll());
        }        
    }
}
