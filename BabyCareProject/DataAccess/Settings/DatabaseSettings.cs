namespace BabyCareProject.DataAccess.Settings
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string InstructorCollectionName { get; set; }
        public string ProductCollectionName { get; set; }

        public string NavbarCollectionName { get; set; }

        public string AboutCollectionName { get; set; }
        public string HeroCollectionName { get; set; }
        public string EventCollectionName { get; set; }
        public string ServiceCollectionName { get; set; }
        public string TestimonialCollectionName { get; set; }
        public string SocialMediaCollectionName { get; set; }
        public string TeamCollectionName { get; set; }
        public string FooterCollectionName { get; set; }
    }
}
