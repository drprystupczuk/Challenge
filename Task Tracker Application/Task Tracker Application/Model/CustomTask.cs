using System.ComponentModel.DataAnnotations;

namespace Task_Tracker_Application.Model
{
    public class CustomTask
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public CustomTask(string name, string description)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
        }
    }
}
