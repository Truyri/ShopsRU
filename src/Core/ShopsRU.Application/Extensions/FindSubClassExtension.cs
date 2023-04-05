namespace ShopsRU.Application.Extensions;

public static class FindSubClassExtension
{
    public static IEnumerable<Type> FindSubClasses(this Type s)
    {
        var baseType = s;
        var assembly = baseType.Assembly;

        return assembly.GetTypes().Where(t => t.IsSubclassOf(baseType));
    }
}