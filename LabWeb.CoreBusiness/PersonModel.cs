namespace LabWeb.CoreBusiness
{
    public class PersonModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string ResearchArea { get; set; } = string.Empty;
        public string EmailAddress { get; set; } = string.Empty;
        public string Biography { get; set; } = string.Empty;
        public string ImageURL { get; set; } = string.Empty;
    }
}