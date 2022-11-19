using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Shared.Models;
using TodoAssessment.Helpers;
using TaskStatus = Shared.Models.TaskStatus;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoAssessment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : Controller
    {
        private readonly RepositoryHelper repositoryHelper;

        public TodoController(ITodoAssessmentRepository todoAssessmentRepository)
        {
            repositoryHelper = new RepositoryHelper(todoAssessmentRepository);
        }

        [HttpGet]
        [Route("all")]
        public List<TodoEntry> GetAllTodoEntries()
        {
            return repositoryHelper.GetAllTodoEntries();
        }

        [HttpGet]
        [Route("status")]
        public List<TodoEntry> GetTodoEntriesByStatus([FromQuery] int status)
        {
            return repositoryHelper.GetTodoEntriesByStatus(status);
        }

        [HttpPost]
        [Route("add")]
        public IActionResult AddTodoEntry([FromBody] TodoEntry entry)
        {
            if (repositoryHelper.AddTodoEntry(entry))
                return Ok();
            else
                return StatusCode(500);
        }

        [HttpPatch]
        [Route("update")]
        public IActionResult UpdateTodoEntry([FromBody] TodoEntry entry)
        {
            if (repositoryHelper.UpdateTodoEntry(entry))
                return Ok();
            else
                return StatusCode(500);
        }
    }
}

