using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace taskcsharp
{
    public interface IBufferManager
    {
        /// <summary>
        /// tells if another sample can be played
        /// </summary>
        bool HasNext();

        /// <summary>
        /// returns the next sample that has to be played
        /// </summary>
        float Next();

        /// <summary>
        /// restart the iterator
        /// </summary>
        void Refresh(long ttl);
    }
}
