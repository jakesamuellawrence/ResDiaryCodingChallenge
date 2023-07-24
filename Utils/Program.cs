namespace Utils;

public static class Program
{
    public static void Main()
    {
        var example = new[] { 1, 2, 3, 4, 5 };
        var result = ListUtils.Subdivide(example, 3);
        ListUtils.Print2DEnumerable(result);
    }
}