using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LabWeb.CoreBusiness
{
    public class PersonModel
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        public string ResearchArea { get; set; } = string.Empty;
        [Required, EmailAddress]
        public string EmailAddress { get; set; } = string.Empty;
        public string Biography { get; set; } = string.Empty;
        [Required]
        public string ImageURL { get; set; } = string.Empty;
        public string WebLink { get; set; } = string.Empty;
        
        public int CategoryID { get; set; }

        [ForeignKey("CategoryID")]
        public PersonCategory PersonCategory { get; set; }
    }
}