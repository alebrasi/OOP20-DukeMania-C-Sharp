namespace midi_task_Csharp
{
	public class FactoryConfigurator
	{
		private FactoryConfigurator() { }
		///this method return a FactoryImpl or PercussionFactoryImpl based on the channel.
		public static IAbstractFactory GetFactory(int channel)
		{
			return channel == 10 ? (IAbstractFactory)PercussionFactory.GetInstance() : Factory.GetInstance();
		}
	}
}
