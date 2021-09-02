using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace midi_task_Csharp
{
	class FactoryConfigurator
	{
		///this method return a FactoryImpl or PercussionFactoryImpl based on the channel.
		public static IAbstractFactory GetFactory(int channel)
		{
			return channel == 10 ? (IAbstractFactory)PercussionFactory.GetInstance() : Factory.GetInstance();
		}
	}
}
