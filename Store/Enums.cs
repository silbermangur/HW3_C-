namespace Store
{
    public class Enums
    {
        public enum IdType
        {
            GuidId, // GUID based ID
            IndexId, // Sequential Index ID
            RandomNumberAndIndex, // [Random number]_[index Id number)
            PrefixAndIndex // (Prefix)_findex Id number)
        }
    }
}
