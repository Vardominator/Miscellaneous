using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public partial class Problems
    {
        
        public static int[] TwoSumBruteForce(int[] nums, int target)
        {
            for(int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < nums.Length; j++)
                {
                    if (nums[j] == target - nums[i])
                    {
                        return new int[] { i, j };
                    }
                }
            }

            throw new ArgumentException("Are you fucking with me?");
        }

        public static int[] TwoSumTwoPass(int[] nums, int target)
        {

            Dictionary<int, int> blah = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                blah.Add(nums[i], i);
            }

            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];
                if(blah.ContainsKey(complement) && blah[complement] != i)
                {
                    return new int[] { i, blah[complement] };
                }
            }

            throw new ArgumentException("Don't be such a fuck");
        }

        public static int[] TwoSumOnePass(int[] nums, int target)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {

                int complement = target - nums[i];

                if (map.ContainsKey(complement))
                {
                    return new int[] { map[complement], i };
                }

                map.Add(nums[i], i);
                
            }

            throw new ArgumentException("You gotta be fucking kidding me bro");
        }

    }
}
