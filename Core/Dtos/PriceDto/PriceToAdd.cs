﻿using Core.Enums;

namespace Core.Dtos.PriceDto
{
    public class PriceToAdd
    {
        public Currency Currency { get; set; }
        public decimal UnitPrice { get; set; }
        public int Igv { get; set; }
        public int ProfitMargin { get; set; }
        public decimal SellPrice { get; set; }
    }
}
