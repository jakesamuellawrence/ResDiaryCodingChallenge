using System.Runtime.CompilerServices;
using Utils;

namespace TestListUtils;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void DividesPerfectList()
    {
        var list = new List<int> { 1, 2, 3, 4, 5, 6 };
        var subarraySize = 2;

        var expected = new List<List<int>>
        {
            new() { 1, 2 },
            new() { 3, 4 },
            new() { 5, 6 },
        };

        var actual = ListUtils.Subdivide(list, subarraySize);

        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void DividesListWithRemainder()
    {
        var list = new List<string> { "a", "b", "c", "d", "e" };
        var subarraySize = 3;

        var expected = new List<List<string>>
        {
            new() { "a", "b", "c" },
            new() { "d", "e" }
        };

        var actual = ListUtils.Subdivide(list, subarraySize);

        Assert.NotNull(actual);
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void DoesntDivideForSubarraySizeLargerThanList()
    {
        var list = new List<bool> { true, true, false, false, true, true };
        var subarraySize = 10;

        var expected = new List<List<bool>>
        {
            new() { true, true, false, false, true, true }
        };

        var actual = ListUtils.Subdivide(list, subarraySize);

        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void DividesArray()
    {
        var array = new[] { 12, 42, 7, 10002, 0.1, Double.E, };
        var subarraySize = 2;

        var expected = new List<List<double>>
        {
            new() { 12, 42 },
            new() { 7, 10002 },
            new() { 0.1, Double.E }
        };

        var actual = ListUtils.Subdivide(array, subarraySize);
        
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void ReturnsNullForNonPositiveSubarraySize()
    {
        var list = new List<int> { 1, 2 };
        var subarraySize = 0;

        var result = ListUtils.Subdivide(list, subarraySize);

        Assert.IsNull(result);
    }
}