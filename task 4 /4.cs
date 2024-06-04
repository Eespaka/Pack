using System;
using System.Linq;

class Program
{
    static int MinStepsToUnify(int[]nums)
{
int target = nums.Min();
int steps = 0;
foreach (int num in nums)
{
    steps += Math.Abs(num - target);
}
return steps;
}

static void Main()
{
    int[] nums = new int[]{1,2,3};
    Console.WriteLine(MinStepsToUnify(nums));
} 
}
