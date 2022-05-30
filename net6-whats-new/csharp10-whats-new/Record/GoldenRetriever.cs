namespace csharp10_whats_new.Record
{
    public record GoldenRetriever : Dog
    {
        public string? Name { get; set; }

        // This can't be overriden because Dog class has it sealed
        /*
        public override string ToString()
        {
            return this.ToString();
        }
        */
    }
}
