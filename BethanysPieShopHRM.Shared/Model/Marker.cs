﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BethanysPieShopHRM.Shared.Model
{
    public class Marker
    {
        public string Description { get; set; } = string.Empty;
        public double X { get; set; }
        public double Y { get; set; }
        public bool? ShowPopUp { get; set; }
    }
}
