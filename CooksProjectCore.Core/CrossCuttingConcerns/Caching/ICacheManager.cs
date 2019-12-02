using System;
using System.Collections.Generic;
using System.Text;

namespace CooksProjectCore.Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {
        object Get(string key);
        void Add(string key, object data, int duration);
        bool IsAdd(string key);
        void Remove(string key);
        void RemoveByPattern(string pattern);
    }
}
