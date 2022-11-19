using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Contracts;
using Shared.Models;
using TodoAssessment.Controllers;
using TaskStatus = Shared.Models.TaskStatus;
using Microsoft.AspNetCore.Http;

namespace TodoAssessment.UnitTests
{
    public class TodoAssessmentControllerTest
    {
        private readonly TodoController _controller;
        private readonly ITodoAssessmentRepository _repository;
        public TodoAssessmentControllerTest()
        {
            _repository = new TodoAssessmentRepositoryFake();
            _controller = new TodoController(_repository);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            // Act
            var result = _controller.GetAllTodoEntries();
            // Assert
            var items = Assert.IsType<List<TodoEntry>>(result);
            Assert.Equal(3, items.Count);
        }

        [Fact]
        public void Post_WhenCalled_AddNewEntry()
        {
            var entryToBeAdded = new TodoEntry()
            {
                Id = new Guid("ab4bd817-98cd-4cf3-a80a-53ea0cd9c204"),
                Title = "Test Adding Todo Item Title 4 [done]",
                CreateDate = DateTime.Now,
                DueDate = DateTime.Now,
                Status = TaskStatus.Done
            };

            // Act
            var result = _controller.AddTodoEntry(entryToBeAdded) as OkResult;
            // Assert
            var response = Assert.IsType<OkResult>(result);

            var allEntries = _controller.GetAllTodoEntries();

            Assert.Contains(entryToBeAdded, allEntries);
        }

        [Fact]
        public void Patch_WhenCalled_UpdateEntry()
        {
            var entryToBeUpdated = _controller.GetAllTodoEntries()[0];

            entryToBeUpdated.Title = "Test Updating Todo Item Title 99 [done]";
            entryToBeUpdated.DueDate = entryToBeUpdated.DueDate.AddDays(10);
            entryToBeUpdated.Status = TaskStatus.Pending;

            // Act
            var result = _controller.UpdateTodoEntry(entryToBeUpdated) as OkResult;
            // Assert
            var response = Assert.IsType<OkResult>(result);

            var allEntries = _controller.GetAllTodoEntries();

            Assert.Equal(allEntries[0].Title, entryToBeUpdated.Title);
            Assert.Equal(allEntries[0].DueDate, entryToBeUpdated.DueDate);
            Assert.Equal(allEntries[0].Status, entryToBeUpdated.Status);
        }
    }
}
