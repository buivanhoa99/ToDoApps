namespace ToDoApps.Core.Entities
{
    public class ToDoTask : BaseEntity
    {
        public string Name { get; set; }

        public bool IsActive { get; set; }
    }
}
