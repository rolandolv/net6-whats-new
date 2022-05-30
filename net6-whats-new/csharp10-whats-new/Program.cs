using csharp10_whats_new.HotReload;
using csharp10_whats_new.InterpolatedStringHandler;
using csharp10_whats_new.PropertyPatterns;
using csharp10_whats_new.RecordStruct;
using System.Linq.Expressions;


#region Record Struct

Console.WriteLine("----------------------------------------------");
Console.WriteLine("Record Struct Section");
Console.WriteLine("----------------------------------------------");
Console.WriteLine();

// Record Struct
var halo = new Game
{
    Name = "Halo",
    Year = new DateOnly(2001, 11, 15),
    Publisher = "Bungie"
};

// Regular Struct
var regularStruct = new RegularStruct 
{ 
    Price = 32.5
};

var parameterlessConstructorStruct = new ParameterlessConstructorStruct();
var fieldInitializerRecordStruct = new FieldInitializerRecordStruct();

Console.WriteLine("Record Struct");
Console.WriteLine(halo);
Console.WriteLine();
Console.WriteLine("Regular Struct");
Console.WriteLine(regularStruct);
Console.WriteLine();
Console.WriteLine("Parameterless Constructor Struct");
Console.WriteLine(parameterlessConstructorStruct);
Console.WriteLine(parameterlessConstructorStruct.Test);
Console.WriteLine();
Console.WriteLine("Field Initializer Record Struct");
Console.WriteLine(fieldInitializerRecordStruct);
Console.WriteLine();

//This causes a compilation error since the record struct property is immutable
//halo.Name = "Trying to change name";

//With-expressions Similar to a record class
Console.WriteLine("With-expression copying and comparing");
var halo2 = halo with { Name = "Halo 2", Year = new DateOnly(2004, 11, 9) };

//Comparison uses regular == and != operators unlike a regular struct
Console.WriteLine($"Are {halo.Name} and {halo2.Name} the same game? {halo == halo2}");
Console.WriteLine();

#endregion

#region InterpolatedStringHandler

Console.WriteLine("----------------------------------------------");
Console.WriteLine("InterpolatedStringHandler");
Console.WriteLine("----------------------------------------------");
Console.WriteLine();

var logger = new Logger() { EnabledLevel = LogLevel.Warning };
var time = DateTime.Now;

logger.LogMessage(LogLevel.Error, $"Error Level. CurrentTime: {time:t}. This is an error. It will be printed.");
Console.WriteLine();

//It does run through the InterpolatedStringHandler but the level es greater so it won't print it
logger.LogMessage(LogLevel.Trace, $"Trace Level. CurrentTime: {time:t}. This won't be printed.");
Console.WriteLine();

logger.LogMessage(LogLevel.Warning, "Warning Level. This warning is a string, not an interpolated string expression.");
Console.WriteLine();
#endregion

#region Extended Property Patterns

Console.WriteLine("----------------------------------------------");
Console.WriteLine("Extended Property Patterns Section");
Console.WriteLine("----------------------------------------------");
Console.WriteLine();

var salesCoordinator = new SalesCoordinator
{
    Name = "Arbiter",
    Age = 110,
    Department = "Games"
};

var salesPerson = new SalesPerson
{
    Name = "John",
    Age = 55,
    SalesCoordinator = salesCoordinator
};

if (salesPerson is SalesPerson { SalesCoordinator: { Name: "Arbiter" } } salesPersonWithArbyAsSalesCoordinator)
{
    Console.WriteLine($"C#9 Property Pattern {salesPersonWithArbyAsSalesCoordinator.Name}");
    Console.WriteLine();
}

if (salesPerson is SalesPerson { SalesCoordinator.Name: "Arbiter" } salesPersonWithArbyAsSalesCoordinatorC10)
{
    Console.WriteLine($"C#10 Property Pattern {salesPersonWithArbyAsSalesCoordinatorC10.Name}");
    Console.WriteLine();
}

#endregion

#region Lambda Improvements

Console.WriteLine("----------------------------------------------");
Console.WriteLine("Lambda Improvements Section");
Console.WriteLine("----------------------------------------------");
Console.WriteLine();

// C#9 and older declaration
Func<int, string> ageInMars = (int age) => $"Your age in Mars is: {age * 365 / 687}";
Console.WriteLine("Age In Mars C#9");
Console.WriteLine(ageInMars);
Console.WriteLine(ageInMars(35));
Console.WriteLine();

// C#10 
var naturalLambdaAgeInMars = (int age) => $"Your age in Mars is: {age * 365 / 687}";
Console.WriteLine("Age In Mars C#10");
Console.WriteLine(naturalLambdaAgeInMars);
Console.WriteLine(naturalLambdaAgeInMars(35));
Console.WriteLine();

object type1 = (string s) => int.Parse(s); // Func<string, int>
Console.WriteLine("object type");
Console.WriteLine(type1);
Console.WriteLine();

Delegate type2 = (string s) => int.Parse(s); // Func<string, int>
Console.WriteLine("Delegate type");
Console.WriteLine(type2);
Console.WriteLine();

var read = Console.Read; // Just one overload; Func<int> inferred
Console.WriteLine("Method group with exactly one overload");
Console.WriteLine(read);
Console.WriteLine();
//var write = Console.Write; // ERROR: Multiple overloads, can't choose

LambdaExpression lambdaExpression = (string s) => int.Parse(s); // Expression<Func<string, int>>
Console.WriteLine("LambdaExpression type");
Console.WriteLine(lambdaExpression);
Console.WriteLine();

Expression expression = (string s) => int.Parse(s); // Expression<Func<string, int>>
Console.WriteLine("Expression type");
Console.WriteLine(expression);
Console.WriteLine();

//var parse = s => int.Parse(s); // ERROR: Not enough type info in the lambda

// Explicit Return Type
//var choose = (bool b) => b ? 1 : "two"; // ERROR: Can't infer return type

var choose = object (bool b) => b ? 1 : "two"; // Func<bool, object>
Console.WriteLine("Explicit Return Type");
Console.WriteLine(choose);
Console.WriteLine();

#endregion

#region HotReload

Console.WriteLine("----------------------------------------------");
Console.WriteLine("Hot Reload Section");
Console.WriteLine("----------------------------------------------");
Console.WriteLine();

var hotReloadExample = new HotReloadExample() {};

while (Console.ReadKey(true).Key != ConsoleKey.Q)
{
    //HotReload changes values via assignment since it was already initialized and further changes to its original property won't make a change
    hotReloadExample.ChangingText = "Backend Code";
    Console.WriteLine(hotReloadExample.ChangingText);    
    
    await Task.Delay(1000);
}

#endregion