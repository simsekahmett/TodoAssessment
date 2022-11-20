using Shared.Models;
using TaskStatus = Shared.Models.TaskStatus;

namespace TodoAssessment.Utils
{
    public static class OverdueCalculator
    {
        public static List<TodoEntry> CalculateTodoOverdueStatus(List<TodoEntry> entries)
        {
            foreach (TodoEntry entry in entries)
            {
                if (entry.DueDate < DateTime.Now && entry.Status != TaskStatus.Done)
                    entry.Status = TaskStatus.Overdue;
            }

            return entries;
        }
    }
}
