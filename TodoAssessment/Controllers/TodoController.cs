using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Shared.Models;
using TodoAssessment.Helpers;
using TodoAssessment.Utils;
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

        /// <summary>
        /// Get all todo entries
        /// </summary>
        /// <param></param>
        /// <returns>List of todo entries</returns>
        [HttpGet]
        [Route("all")]
        public List<TodoEntry> GetAllTodoEntries()
        {
            return OverdueCalculator.CalculateTodoOverdueStatus(repositoryHelper.GetAllTodoEntries());
        }

        /// <summary>
        /// Get all todo entries by status
        /// </summary>
        /// <param name="status">int 0,1,2 [Pending, Overdue, Done]</param>
        /// <returns>List of todo entries</returns>
        [HttpGet]
        [Route("status")]
        public List<TodoEntry> GetTodoEntriesByStatus([FromQuery] int status)
        {
            return OverdueCalculator.CalculateTodoOverdueStatus(repositoryHelper.GetTodoEntriesByStatus(status));
        }


        /// <summary>
        /// Add new todo entry
        /// </summary>
        /// <param name="entry"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("add")]
        public IActionResult AddTodoEntry([FromBody] TodoEntry entry)
        {
            if (repositoryHelper.AddTodoEntry(entry))
                return Ok();
            else
                return StatusCode(500);
        }

        /// <summary>
        /// Update a todo entry
        /// </summary>
        /// <param name="entry">Todo entry to be updated</param>
        /// <returns></returns>
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

