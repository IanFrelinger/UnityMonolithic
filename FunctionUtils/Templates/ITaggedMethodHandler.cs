namespace FunctionUtils.Templates
{
    public interface ITaggedMethodHandler
    {
        void CacheTaggedMethods(object instance, string tag);
        void ExecuteCachedMethods();
    }
}