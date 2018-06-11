using System;

namespace Yanyitec.Accessor
{
    public interface IObjectAccessorFactory
    {
        IObjectAccessor Aquire(Type type);
        IObjectAccessor<T> Aquire<T>() where T : class;
    }
}