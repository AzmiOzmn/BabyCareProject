﻿namespace BabyCareProject.Dtos.ProductDtos
{
    public class UpdateProductDto
    {
        public string ProductId { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string InstructorName { get; set; }

        public string InstructorImage { get; set; }
        public string InstructorTitle { get; set; }

    }
}
