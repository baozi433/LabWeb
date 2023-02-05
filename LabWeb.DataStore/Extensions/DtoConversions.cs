using LabWeb.CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWeb.DataStore.Extensions
{
    public static class DtoConversions
    {
        public static IEnumerable<PersonModelDto> ConvertToDto(this IEnumerable<PersonModel> people)
        {
            return (from person in people
                    select new PersonModelDto
                    {
                        Id = person.Id,
                        Title = person.Title,
                        FirstName = person.FirstName,
                        LastName = person.LastName,
                        ResearchArea = person.ResearchArea,
                        EmailAddress = person.EmailAddress,
                        Biography = person.Biography,
                        ImageURL = person.ImageURL,
                        WebLink = person.WebLink,
                        CategoryId = person.PersonCategory.Id,
                        CategoryName = person.PersonCategory.Name
                    }
                    ).ToList();
        }

        public static PersonModelDto ConvertToDto(this PersonModel person)
        {
            return new PersonModelDto
            {
                Title = person.Title,
                FirstName = person.FirstName,
                LastName = person.LastName,
                ResearchArea = person.ResearchArea,
                EmailAddress = person.EmailAddress,
                Biography = person.Biography,
                ImageURL = person.ImageURL,
                WebLink = person.WebLink,
                CategoryId = person.PersonCategory.Id,
                CategoryName = person.PersonCategory.Name
            };
        }
    }
}
