﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class RentalDetailsDto : IDto
    {

        public int Id { get; set; }
        public string BrandName { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public int RentDate { get; set; }
        public string ReturnDate { get; set; }
    }
}
