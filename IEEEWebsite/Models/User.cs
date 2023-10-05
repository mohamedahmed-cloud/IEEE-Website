namespace IEEEWebsite.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Role { get; set; }
        public string? CategoryName { get; set; }
        public DateTime SignInDate { get; set; }
        public int? TotalScore { get; set; }
        
        // User & Category
        public int? CategoryId { get; set; }
        public Category Category { get; set; }

        // User & Warning

        


    }
}
