namespace csharp10_whats_new.RecordStruct
{
    public record struct Game
    {
        //Immutability via init
        public string Name { get; init; }

        public DateOnly Year { get; init; }
        public string Publisher { get; init; }
    }

    public struct ParameterlessConstructorStruct
    {
        //C#10 parameterles struct constructor
        public ParameterlessConstructorStruct()
        {
            Id = 0;
            Test = "Test";
        }

        public int Id { get; set; }

        public string Test { get; set; }
    }

    public record struct FieldInitializerRecordStruct
    {
        public int Id { get; set; } = 2;

        public string Test { get; set; } = "Field Initialized Inline";
    }

    // Regular Struct for the sake of comparison
    public struct RegularStruct
    {
        public double Price { get; init; }
    }
}
