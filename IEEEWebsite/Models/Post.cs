using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IEEEWebsite.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        /*NotRequired*/
        public string ImagePath { get; set; }
        [NotMapped]
        public IFormFile formFile { get; set; }

        [RegularExpression(@"^(http|https)://[a-zA-Z0-9\-\.]+\.[a-zA-Z]{2,}(?:/[\w\-]+)*(/\w+\.[a-zA-Z]{2,})?(\?([a-zA-Z0-9\-]+=[a-zA-Z0-9\-]*(&amp;)?)*[a-zA-Z0-9\-]+=[a-zA-Z0-9\-]*(?:&amp;[a-zA-Z0-9\-]+=[a-zA-Z0-9\-]*)*)?$", ErrorMessage = "Invalid URL format.")]
        public string FaceBookLink { get; set; }

        [RegularExpression(@"^(http|https)://[a-zA-Z0-9\-\.]+\.[a-zA-Z]{2,}(?:/[\w\-]+)*(/\w+\.[a-zA-Z]{2,})?(\?([a-zA-Z0-9\-]+=[a-zA-Z0-9\-]*(&amp;)?)*[a-zA-Z0-9\-]+=[a-zA-Z0-9\-]*(?:&amp;[a-zA-Z0-9\-]+=[a-zA-Z0-9\-]*)*)?$", ErrorMessage = "Invalid URL format.")]
        public string LinkedInLink { get; set; }

    }
}

/*
 
 blue #006699
 yellow #ffc000
 
 */