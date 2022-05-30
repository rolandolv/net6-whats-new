namespace csharp10_whats_new.PropertyPatterns
{
    public class SalesPerson : Employee
    {
        public string? Area { get; set; }
        public SalesCoordinator? SalesCoordinator { get; set; }
    }
}
