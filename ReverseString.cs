// LeetCode 344 - Reverse String
// Approach: Two Pointers, in-place, no built-in reverse methods.
// Time Complexity:  O(n) - each element is visited once
// Space Complexity: O(1) - only two index variables used, no extra array

public class Solution
{
    public void ReverseString(char[] s)
    {
        int left = 0;
        int right = s.Length - 1;

        while (left < right)
        {
            // swap
            char temp = s[left];
            s[left] = s[right];
            s[right] = temp;

            left++;
            right--;
        }
    }
}

/*
Explanation:
We place one pointer at the start (left) and one at the end (right) of the
array. We swap the characters at these two positions, then move left forward
and right backward. We repeat until the pointers meet in the middle. Since
we only swap values using a temp variable and two index counters, this
modifies the array in place with constant extra space.
*/
