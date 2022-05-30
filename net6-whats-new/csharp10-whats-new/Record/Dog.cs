namespace csharp10_whats_new.Record
{
    public record Dog
    {
        public string? Category { get; set; }

        // C#10 Record class improvement
        public override sealed string ToString()
        {
            Console.WriteLine("ToString Sealed for Animal record");
            return "Sealed Object";
        }
    }
}
