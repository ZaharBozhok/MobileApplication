using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace MobileApplication.VersionInfoAndroid
{
    public class InMemoryRepostiry<T>
    {
        protected static ConcurrentBag<T> Storage { get; } = new ConcurrentBag<T>();
    }
}
