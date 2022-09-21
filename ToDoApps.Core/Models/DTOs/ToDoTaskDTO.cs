﻿namespace ToDoApps.Core.Models.DTOs
{
    public class ToDoTaskDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
