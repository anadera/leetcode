using System.Collections;
using System.Text;

namespace Easy;

public static class Solution
{
    public static int[] TwoSum(int[] nums, int target)
    {
        var sorted = nums.OrderBy(x => x).ToArray();
        if (target > 0 && sorted[0] >= 0)
            sorted = sorted.Where(x => x < target).ToArray();
        foreach (var t in sorted)
        {
            foreach (var s in sorted)
            {
                if (t + s > target) break;
                if (t + s != target) continue;
                var a = Array.IndexOf(nums, t);
                var b = t == s ? Array.IndexOf(nums, s, a + 1) : Array.IndexOf(nums, s);
                return new[] {a, b};
            }
        }

        return new[] {0, 0};
    }

    public static bool IsPalindrome(int x)
    {
        if (x < 0) return false;
        if (x <= 9) return true;
        var s = Convert.ToString(x);
        if (s.Distinct().Count() == 1) return true;
        var ch = s.ToCharArray();
        for (var i = 0; i < ch.Length; i++)
        {
            if (ch[ch.Length - 1 - i] != ch[i]) return false;
        }

        return true;
    }

    public static int StrStr(string haystack, string needle)
    {
        if (needle.Length == 0) return 0;
        if (haystack.Equals(needle)) return 0;
        var h = haystack.ToCharArray();
        var n = needle.ToCharArray();
        int needleCursor = 0, haystackCursor = 0;
        bool isFound = false;
        for (int i = 0; i < h.Length; i++)
        {
            if (h[i] == n[needleCursor])
            {
                if (!isFound)
                {
                    haystackCursor = i;
                    isFound = true;
                }

                needleCursor++;
                if (needleCursor == n.Length)
                    return (i + 1) - needleCursor;
                continue;
            }

            if (h[i] != n[needleCursor])
            {
                if (needleCursor != 0 && needleCursor < n.Length)
                {
                    needleCursor = 0;
                    i = haystackCursor++;
                    isFound = false;
                }
            }
        }

        return -1;
    }


    public static string AddBinary(string a, string b)
    {
        var lenA = a.Length;
        var lenB = b.Length;
        var maxLen = lenA > lenB ? lenA : lenB;
        b = b.PadLeft(maxLen, '0');
        a = a.PadLeft(maxLen, '0');

        StringBuilder result = new();
        var carret = false;
        const char zero = '0';
        const char one = '1';
        for (var i = maxLen - 1; i > -1; i--)
        {
            if (a[i] is '1' && b[i] is '1')
            {
                result.Insert(0, carret ? one : zero);
                carret = true;
                continue;
            }

            if (a[i] is '0' && b[i] is '0')
            {
                result.Insert(0, carret ? one : zero);

                carret = false;
                continue;
            }

            if (a[i] is '0' && b[i] is '1' || a[i] is '1' && b[i] is '0')
            {
                if (carret)
                {
                    result.Insert(0, zero);
                    carret = true;
                }
                else
                {
                    result.Insert(0, one);
                    carret = false;
                }
            }
        }

        if (carret)
            result.Insert(0, one);

        return result.ToString();
    }

    public static string DigitSum(string s, int k)
    {
        string result = s;

        while (result.Length > k)
        {
            result = DoJob(k, result.Length, result);
        }

        return result;

        string DoJob(int desirableSize, int inputLen, string input)
        {
            var array = input.ToCharArray();
            var groupNum = inputLen / desirableSize;
            if (inputLen % desirableSize != 0)
                groupNum++;
            int[] parts = new int[groupNum];
            var partsIndex = 0;
            var current = 1;
            for (int i = 0; i < inputLen; i++)
            {
                parts[partsIndex] += Convert.ToInt16(array[i].ToString());
                if (current < desirableSize)
                {
                    current++;
                    continue;
                }

                if (current == desirableSize)
                {
                    current = 1;
                    partsIndex++;
                }
            }

            return string.Join(string.Empty, parts.Select(x => x.ToString()));
        }
    }

    public static int RomanToInt(string s)
    {
        var len = s.Length;
        var array = s.ToCharArray();
        var result = 0;
        for (int i = 0; i < len; i++)
        {
            int n = 0;
            var next = i + 1;
            switch (array[i])
            {
                case 'I':
                    if (next < len)
                    {
                        if (array[next] == 'V')
                        {
                            n = 4;
                            i++;
                            break;
                        }

                        if (array[next] == 'X')
                        {
                            n = 9;
                            i++;
                            break;
                        }
                    }

                    n = 1;
                    break;
                case 'V':
                    n = 5;
                    break;
                case 'X':
                    if (next < len)
                    {
                        if (array[next] == 'L')
                        {
                            n = 40;
                            i++;
                            break;
                        }

                        if (array[next] == 'C')
                        {
                            n = 90;
                            i++;
                            break;
                        }
                    }

                    n = 10;
                    break;
                case 'L':
                    n = 50;
                    break;
                case 'C':
                    if (next < len)
                    {
                        if (array[next] == 'D')
                        {
                            n = 400;
                            i++;
                            break;
                        }

                        if (array[next] == 'M')
                        {
                            n = 900;
                            i++;
                            break;
                        }
                    }

                    n = 100;
                    break;
                case 'D':
                    n = 500;
                    break;
                case 'M':
                    n = 1000;
                    break;
            }

            result += n;
        }

        return result;
    }

    public static bool IsValid(string s)
    {
        var stack = new Stack();
        const char c1Left = '(', c1Right = ')', c2Left = '[', c2Right = ']', c3Left = '{', c3Right = '}';

        for (var i = 0; i < s.Length; i++)
        {
            var c = s[i];
            if (c.Equals(c1Left) || c.Equals(c2Left) || c.Equals(c3Left))
            {
                stack.Push(c);
                continue;
            }

            if (c.Equals(c1Right) && stack.Count != 0 && stack.Pop().Equals(c1Left))
                continue;
            if (c.Equals(c2Right) && stack.Count != 0 && stack.Pop().Equals(c2Left))
                continue;
            if (c.Equals(c3Right) && stack.Count != 0 && stack.Pop().Equals(c3Left))
                continue;
            return false;
        }

        return stack.Count == 0;
    }

    public static int ClimbStairs(int n)
    {
        int one = 1, two = 1;
        for (int i = 1; i < n; i++)
        {
            var temp = one;
            one = one + two;
            two = temp;
        }

        return one;
    }

    public static int MaxSubArray(int[] nums)
    {
        int totalSumBuffer = nums[0];
        int currentSumBuffer = nums[0];
        for (var i = 1; i < nums.Length; i++)
        {
            var temp = Math.Max(nums[i], currentSumBuffer + nums[i]);
            currentSumBuffer = temp;
            if (currentSumBuffer > totalSumBuffer)
                totalSumBuffer = currentSumBuffer;
        }

        return totalSumBuffer;
    }

    public static IList<IList<int>> Generate(int numRows)
    {
        var current = new[] {1};
        var total = new int[numRows][];
        total[0] = current;
        if (numRows == 1)
            return total;
        for (int i = 2; i <= numRows; i++)
        {
            current = new int[i];
            for (var j = 0; j < i; j++)
            {
                if (j == 0)
                    current[j] = 1;
                else if (j == i - 1)
                    current[j] = 1;
                else
                {
                    current[j] = total[i - 2][j - 1] + total[i - 2][j];
                }
            }

            total[i - 1] = current;
        }

        return total;
    }

    public static int MaxProfit(int[] prices)
    {
        var max = 0;
        var current = prices[0];
        for (int i = 1; i < prices.Length; i++)
        {
            current = Math.Min(current, prices[i - 1]);
            max = Math.Max(max, prices[i] - current);
        }

        return max;
    }

    public static int IslandPerimeter(int[][] grid)
    {
        var rowCount = grid.Length;
        var colCount = grid[0].Length;

        var perim = 0;
        for (int i = 0; i < rowCount; i++)
        {
            for (int j = 0; j < colCount; j++)
            {
                if (grid[i][j] == 0)
                    continue;

                var leftCell = ((j - 1) < 0 || (j - 1) >= colCount) ? 1 : grid[i][j - 1] == 1 ? 0 : 1;
                var rightCell = ((j + 1) < 0 || (j + 1) >= colCount) ? 1 : grid[i][j + 1] == 1 ? 0 : 1;
                var topCell = ((i - 1) < 0 || (i - 1) >= rowCount) ? 1 : grid[i - 1][j] == 1 ? 0 : 1;
                var bottomCell = ((i + 1) < 0 || (i + 1) >= rowCount) ? 1 : grid[i + 1][j] == 1 ? 0 : 1;

                perim = perim + leftCell + rightCell + topCell + bottomCell;
            }
        }

        return perim;
    }
}