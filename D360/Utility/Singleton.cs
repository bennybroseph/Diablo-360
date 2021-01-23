
namespace D360.Utility
{
    using System;

    [Serializable]
    public abstract class Singleton<T> where T : class, new()
    {
        protected static T s_Self;

        public static T self => s_Self ?? (s_Self = new T());

        protected Singleton()
        {

        }
    }
}
