using System.Text.Json.Serialization;

namespace ToDoApps.Core.Models.DTOs
{
    public class UpdateTaskDTO
    {
        [JsonIgnore]
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsActive { get; set; }
    }
}
