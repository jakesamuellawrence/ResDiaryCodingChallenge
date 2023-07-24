using System.Net;
using System.Numerics;

namespace Utils;

/// <summary>
/// Utility functions for operating on Enumerables such as Lists.
/// </summary>
public static class ListUtils
{
    /// <summary>
    /// Splits an enumerable into a number of equally-sized sub-lists. Where sub-lists cannot be equally
    /// sized, the final list is smaller, having size equal to the remainder after dividing by the subarraySize
    /// </summary>
    /// <param name="items">The enumerable to be split</param>
    /// <param name="subarraySize">The desired size of each sub-list</param>
    /// <typeparam name="T">The type of items held by the list to be split</typeparam>
    /// <returns>A list of lists that represents <code>items</code> divided into sub-lists. If the subarray size
    /// is not a positive integer, returns null.</returns>
    public static List<List<T>>? Subdivide<T>(IEnumerable<T> items, int subarraySize)
    {
        if (subarraySize <= 0) return null;

        return items
            .Select((value, index) => new { Value = value, Index = index })
            .GroupBy(item => item.Index / subarraySize)
            .Select(group => group.Select(item => item.Value).ToList())
            .ToList();
    }

    /// <summary>
    /// Utility function for displaying the contents of a 2D enumerables, for example a list of lists.
    /// Can be used for manual inspection or testing
    /// </summary>
    /// <param name="list">The Enumerable to be printed</param>
    /// <typeparam name="T">The type of the contents of <code>list</code></typeparam>
    public static void Print2DEnumerable<T>(IEnumerable<IEnumerable<T>>? list)
    {
        if (list is null)
        {
            Console.WriteLine("null");
            return;
        }

        var subarrayStrings = list.Select(sublist => $"[{string.Join(",", sublist)}]");
        Console.WriteLine($"[ {string.Join(", ", subarrayStrings)} ]");
    }
}