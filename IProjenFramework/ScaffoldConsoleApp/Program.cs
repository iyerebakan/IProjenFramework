using System;

namespace ScaffoldConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}



//dotnet ef dbcontext scaffold "Server=.;Database=Northwind;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -o Entities -f -c NotrwindContext --data-annotations