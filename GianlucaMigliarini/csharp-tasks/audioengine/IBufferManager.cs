using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace taskcsharp
{
    public interface IBufferManager
    {
        bool HasNext();
        float Next();
        void Refresh(long ttl);
    }
}
