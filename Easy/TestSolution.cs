using NUnit.Framework;

namespace Easy;

[TestFixture]
public class TestSolution
{
    [TestCase(new[] {2, 7, 11, 15}, 9)]
    [TestCase(new[] {3, 2, 4}, 6)]
    [TestCase(new[] {3, 3}, 6)]
    [TestCase(new[] {0, 4, 3, 0}, 0)]
    [TestCase(new[] {-3, 4, 3, 90}, 0)]
    [TestCase(new[] {-1, -2, -3, -4, -5}, -8)]
    public void TestTwoSum(int[] nums, int target)
    {
        var indexies = Solution.TwoSum(nums, target);
        foreach (var i in indexies)
        {
            Console.WriteLine(i);
        }
    }

    [TestCase(121, true)]
    [TestCase(-121, false)]
    [TestCase(10, false)]
    public void TestIsPalindrome(int x, bool r)
    {
        Assert.AreEqual(r, Solution.IsPalindrome(x));
    }

    [TestCase("hello", "ll")]
    [TestCase("aaaaa", "bba")]
    [TestCase("a", "a")]
    [TestCase("abc", "c")]
    [TestCase("mississippi", "issip")]
    [TestCase("mississippi", "pi")]
    public void TestStrStr(string haystack, string needle)
    {
        Console.WriteLine(Solution.StrStr(haystack, needle));
    }

    [TestCase("11", "1", "100")]
    [TestCase("1010", "1011", "10101")]
    [TestCase("0", "0", "0")]
    [TestCase("10100000100100110110010000010101111011011001101110111111111101000000101111001110001111100001101",
        "110101001011101110001111100110001010100001101011101010000011011011001011101111001100000011011110011",
        "110111101100010011000101110110100000011101000101011001000011011000001100011110011010010011000000000")]
    [TestCase("1", "111", "1000")]
    public void TestAddBinary(string a, string b, string r)
    {
        Assert.AreEqual(r, Solution.AddBinary(a, b));
    }

    [TestCase("11111222223", 3)]
    [TestCase("233", 3)]
    public void TestDigitSum(string s, int k)
    {
        var r = Solution.DigitSum(s, k);
        Console.WriteLine(r);
    }

    [TestCase("MCMXCIV", 1994)]
    [TestCase("III", 3)]
    public void TestRomanToInt(string s, int e)
    {
        Assert.AreEqual(e, Solution.RomanToInt(s));
    }

    [TestCase("()", true)]
    [TestCase("()[]{}", true)]
    [TestCase("(]", false)]
    [TestCase("([)]", false)]
    public void TestIsValid(string s, bool result)
    {
        Assert.AreEqual(result, Solution.IsValid(s));
    }

    [TestCase(2)]
    [TestCase(3)]
    [TestCase(4)]
    [TestCase(5)]
    public void TestClimbStairs(int n)
    {
        Console.WriteLine(Solution.ClimbStairs(n));
    }

    [TestCase(new[] {-2, 1, -3, 4, -1, 2, 1, -5, 4})]
    public void TestMaxSubArray(int[] array)
    {
        Console.WriteLine(Solution.MaxSubArray(array));
    }

    [TestCase(1)]
    [TestCase(2)]
    [TestCase(5)]
    public void TestGenerate(int n)
    {
        var r = Solution.Generate(n);
        foreach (var subArr in r)
        {
            foreach (var num in subArr)
            {
                Console.Write($"{num} ");
            }

            Console.Write(";");
        }
    }

    [TestCase(new[] {7, 1, 5, 3, 6, 4})]
    [TestCase(new[] {7, 6, 4, 3, 1})]
    public void TestMaxProfit(int[] prices)
    {
        Console.WriteLine(Solution.MaxProfit(prices));
    }

    [Test]
    public void TestIslandPerimeter()
    {
        var grid = new[] {new[] {1, 0}};
        Console.WriteLine(Solution.IslandPerimeter(grid));
    }
}