namespace InmobiliariaDashboard.Shared.ViewModels
{
    public class MonetaryAgentBalanceViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double LossValue { get; set; }
        public double CostValue { get; set; }
        public double GainValue { get; set; }
        public double TotalBalance => (GainValue) - (LossValue + CostValue);
    }
}