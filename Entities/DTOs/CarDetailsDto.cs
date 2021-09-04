﻿using Core.Entities;

namespace Entities.DTOs
{
    public class CarDetailsDto : IDto
    {
        public int Id { get; set; }
        public int ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public string Description { get; set; }
        public string CarName { get; set; }
        public string ColorName { get; set; }
        public string BrandName { get; set; }
    }
}