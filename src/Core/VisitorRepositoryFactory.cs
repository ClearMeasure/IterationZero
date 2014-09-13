using System;

namespace Core
{
    public class VisitorRepositoryFactory
    {
        public static Func<IVisitorRepository> Build = () => { throw new NullReferenceException(); };
    }
}