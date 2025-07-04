﻿namespace BabyCareProject.DataAccess.Settings
{
    public interface IDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string InstructorCollectionName { get; set; }
        public string ProductCollectionName { get; set; }
        public string NavbarCollectionName { get; }
        public string AboutCollectionName { get; }
    }
}
