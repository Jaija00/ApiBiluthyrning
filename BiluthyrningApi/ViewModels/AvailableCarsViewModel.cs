﻿using BiluthyrningApi.Models;

namespace BiluthyrningApi.ViewModels
{
    public class AvailableCarsViewModel
    {
        public int Id { get; set; }
        public Booking Booking { get; set; }
        public Car Car { get; set; }

    }
}
