using System;

namespace Yanyitec.Reflection
{
    public interface IClassFactory
    {
        IClass Aquire(Type type);
        IClass<T> Aquire<T>() where T : class;
    }
}