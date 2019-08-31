using System;

namespace VesNing.EdutureCore.IRepositity
{
    /// <summary>
    /// 对外提供的接口
    /// </summary>
    public interface IBaseRepository<T>:IDisposable where T:class,new()
    {
        T Find(string id);
    }
}
