﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalRetailers.Models
{
    public class Payment
    {
        public int Amount { get; set; }
        public string Currency { get; set; }
        public string Description { get; set; }
    }
    public class ChangeViewModel
    {
        public string ChargeId { get; set; }
    }
}
