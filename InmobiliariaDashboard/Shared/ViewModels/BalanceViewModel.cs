namespace InmobiliariaDashboard.Shared.ViewModels
{
    public class BalanceViewModel
    {
        public string EnterpriseName { get; set; }
        public double AssetValue { get; set; }
        public double CostValue { get; set; }
        public double GainValue { get; set; }
        public double LossValue { get; set; }
        public double TotalBalance => (AssetValue + GainValue) - (CostValue + LossValue);
    }
}