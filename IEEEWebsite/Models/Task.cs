namespace IEEEWebsite.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CategoryName { get; set; }

        public int? CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
