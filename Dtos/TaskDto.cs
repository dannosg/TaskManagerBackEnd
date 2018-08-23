using System;

namespace TaskProject.Dtos
{
    public class TaskDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public bool IsDone { get; set; }
        public DateTime DeadLine { get; set; }
    }
}