using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;
using TaskStatus = Shared.Models.TaskStatus;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoAssessment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : Controller
    {
        [HttpGet]
        [Route("all")]
        public List<TodoEntry> GetAllTodoEntries()
        {
            List<TodoEntry> entryList   = new List<TodoEntry>();
            Random random = new Random();

            for (int i = 0; i < 10; i++)
            {
                var status = TaskStatus.Pending;
                switch (i % 3)
                {
                    case 0:
                        status = TaskStatus.Pending;
                        break;

                    case 1:
                        status = TaskStatus.Overdue;
                        break;

                    case 2:
                        status = TaskStatus.Done;
                        break;
                }

                entryList.Add(new TodoEntry()
                {
                    Id = Guid.NewGuid().ToString(),
                    CreateDate = DateTime.Now.AddDays(random.Next(0,10)),
                    DueDate = DateTime.Now.AddDays(random.Next(0,3)),
                    Status = status,
                    Title = "test title " + i
                });
            }

            return entryList;
        }

        [HttpGet]
        [Route("status")]
        public IActionResult GetTodoEntryByStatus(string status)
        {
            return Ok();
        }

        [HttpPost]
        [Route("add")]
        public IActionResult AddTodoEntry([FromBody]TodoEntry entry)
        {
            return Ok();
        }

        [HttpPatch]
        [Route("update")]
        public IActionResult UpdateTodoEntry([FromQuery] string entryId, [FromBody] TodoEntry entry)
        {
            return Ok();
        }
    }
}

