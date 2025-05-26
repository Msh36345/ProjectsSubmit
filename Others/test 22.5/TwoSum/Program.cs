using System;
using System.Collections.Generic;

internal class Program
{
    // Task: Two Sum
    /*
     Given an array of integers and a target sum, return the indices of the two numbers such that they add up to the target.

     ✍️ Signature:
        public static int[] TwoSum(int[] nums, int target)

     🔍 Example:
        Input: nums = [2, 7, 11, 15], target = 9
        Output: [0, 1]

        Input: nums = [3, 2, 4], target = 6
        Output: [1, 2]

        If no 2 matching numbers were found - return an empty int array.

     🧪 Your code will be tested automatically when you run the program.

        Add comments and explenations your your code!

        When you are done - screenshot the results and send it to your instructor, alongside the Program.cs file.

        No GPT or Copilot are allowed.
    */

    public static int[] TwoSum(int[] nums, int target)
    {
        for (int i = 0; i < nums.Length; i++) // מתחיל לרוץ על המערך מהמיקום הראשון
        {
            for (int j = i+1; j < nums.Length; j++)// מתחיל לרוץ על המערך מהמיקום הבא(בשביל לא לרוץ על אותו מספר פעמיים)
            {
                if (nums[i]+nums[j]==target)// בודק האם שווה למערך
                {
                    nums = new[] { i, j };// במידה וכן מאתחל את הרשימה ומחזיר אותה
                    return nums;
                }

            }
            
        }

        nums = new int[0];// במידה ולא מצא מאפס את הרשימה ומחזיר אותה ריקה
        return nums;
    }

    static void Main(string[] args)
    {
        AppRunner.Run(TwoSum);
    }
}
