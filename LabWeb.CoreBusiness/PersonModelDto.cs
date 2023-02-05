using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWeb.CoreBusiness
{
    public class PersonModelDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string ResearchArea { get; set; } = string.Empty;
        public string EmailAddress { get; set; } = string.Empty;
        public string Biography { get; set; } = string.Empty;
        public string ImageURL { get; set; } = string.Empty;
        public string WebLink { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
    }
}
