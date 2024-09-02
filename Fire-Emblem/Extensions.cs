
public static class Extensions
{
    public static IEnumerable<Tuple<int, T>> Enumerate<T>(this IEnumerable<T> list)
    {
        int id = 0;
        foreach (var elem in list)
        {
            yield return new Tuple<int, T>(id, elem);
            id++;
        }
    }
}