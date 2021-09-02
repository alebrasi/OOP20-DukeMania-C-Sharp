using System;
using System.Runtime.Serialization;

namespace midi_task_Csharp
{
	[Serializable]
	public class InvalidNoteException : Exception
	{
		public InvalidNoteException()
		{
		}

		public InvalidNoteException(string message) : base(message)
		{
		}

		public InvalidNoteException(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected InvalidNoteException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}