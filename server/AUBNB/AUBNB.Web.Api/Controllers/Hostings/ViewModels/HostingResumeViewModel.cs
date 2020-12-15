namespace AUBNB.Web.API.Controllers.Hostings.ViewModels
{
    public class HostingResumeViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public double Note { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string User { get; set; }
        public string TelephoneNumber { get; set; }
        public string HasDog { get; set; }
        public string PlaceDescription { get; set; }
        public string PatioSize { get; set; }
        public string HousingType { get; set; }
        public string AnimalSize { get; set; }
    }
}
