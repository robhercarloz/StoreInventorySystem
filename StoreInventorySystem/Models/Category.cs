﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreInventorySystem.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string ItemId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }

    }
}