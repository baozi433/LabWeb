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

        public PersonModelDto(PersonModel p)
        {
            Id = p.Id;
            Title = p.Title;
            FirstName = p.FirstName;
            LastName = p.LastName;
            ResearchArea= p.ResearchArea;
            EmailAddress = p.EmailAddress;
            Biography = p.Biography;
            ImageURL= p.ImageURL;
            WebLink= p.WebLink;

            //p.PersonCategory = new();      
            CategoryId = p.CategoryId;

            //This solution is hardcoded part and needed to be refined. 
            switch (CategoryId)
            {
                case 1:
                    CategoryName = "Staff";
                    break;
                case 2:
                    CategoryName = "Affiliated Staff";
                    break;
                case 3:
                    CategoryName = "Students";
                    break;
                case 4:
                    CategoryName = "Alumni";
                    break;
                default:
                    CategoryName = "None";
                    break;
            }
        }
    }
}
