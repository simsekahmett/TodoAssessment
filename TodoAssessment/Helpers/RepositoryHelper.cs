using DataAccess.Contracts;
using Shared.Models;
using TaskStatus = Shared.Models.TaskStatus;

namespace TodoAssessment.Helpers
{
    public class RepositoryHelper
    {
        private readonly ITodoAssessmentRepository todoAssessmentRepository;

        public RepositoryHelper(ITodoAssessmentRepository _todoAssessmentRepository)
        {
            todoAssessmentRepository = _todoAssessmentRepository;
        }

        public List<TodoEntry> GetAllTodoEntries()
        {
            return todoAssessmentRepository.GetAllTodoEntries();
        }

        public List<TodoEntry> GetTodoEntriesByStatus(int status)
        {
            return todoAssessmentRepository.GetTodoEntriesByStatus(status);
        }

        public bool AddTodoEntry(TodoEntry entry)
        {
            return todoAssessmentRepository.AddTodoEntry(entry);
        }

        public bool UpdateTodoEntry(TodoEntry entry)
        {
            return todoAssessmentRepository.UpdateTodoEntry(entry);
        }
    }
}
