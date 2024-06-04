using System;

class Program
{
    static void Main()
    {
        int n = 5;
        int m = 4;
        
        int[] nums = new int[n];
        
        for (int i = 0; i < n; i++)
        {
            nums[i] = i + 1;
        }
        
        
        int[] path = new int[n];
        for (int i = 0; i < n; i++)
        {
            path[i] = nums[(i % m)];
        }
        
        
        Console.WriteLine("Path:");
        for (int i = 0; i < n; i++)
{
    Console.Write(path[i] + " ");
}
    Console.WriteLine();
}
}


using System;

class Program
{
    static void Main()
    {
        int n = 4;
        int m = 3;
        
        int[] nums = new int[n];
        
        for (int i = 0; i < n; i++)
        {
            nums[i] = i + 1;
        }
        
        
        int[] path = new int[n];
        for (int i = 0; i < n; i++)
        {
            path[i] = nums[(i % m)];
        }
        
        
        Console.WriteLine("Path:");
        for (int i = 0; i < n; i++)
{
    Console.Write(path[i] + " ");
}
    Console.WriteLine();
}
}
