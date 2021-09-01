using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace midi_task_Csharp
{
	public interface IParser
	{
		Song Parse(File file);
	}
}
