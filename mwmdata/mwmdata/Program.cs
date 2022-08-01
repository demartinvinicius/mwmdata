// See https://aka.ms/new-console-template for more information
using mwmdata;

ModelContext context = new ModelContext();

var a = context.ManufacturingResults.Select(a => a.Id);
foreach(var record in a)
{
    Console.WriteLine(record);
}


Console.WriteLine("Hello, World!");
