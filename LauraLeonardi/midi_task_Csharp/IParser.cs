using System.IO;

namespace midi_task_Csharp
{
	public interface IParser
	{
		Song Parse(File file);
	}
}
