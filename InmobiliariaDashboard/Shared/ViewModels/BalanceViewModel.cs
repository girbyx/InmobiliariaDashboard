﻿namespace InmobiliariaDashboard.Shared.ViewModels
{
    public class BalanceViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double AssetValue { get; set; }
        public double CostValue { get; set; }
        public double GainValue { get; set; }
        public double LossValue { get; set; }
        public double TotalBalance => (AssetValue + GainValue) - (CostValue + LossValue);
    }
}