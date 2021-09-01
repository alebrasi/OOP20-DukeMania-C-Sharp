using System;
using System.Collections.Generic;
using System.Linq;

namespace midi_task_Csharp
{
	public class Instrument
	{
		public InstrumentType InstrumentName { get; }
		public string Name { get; }
		public List<InstrumentType> AssociatedInstrumentType { get; }


		public Instrument(InstrumentType instrument)
		{
			InstrumentName = instrument;
			Name = CalcName();
			AssociatedInstrumentType = CalcAssociatedInstrumentType();
		}

		private List<InstrumentType> CalcAssociatedInstrumentType()
		{
			return Enum.GetValues(typeof(InstrumentType))
						.Cast<Instrument>()
						.Where(x => x.CalcName().Equals(Name))
						.Cast<InstrumentType>()
						.ToList();
		}

		private string CalcName()
		{
			switch ((int)InstrumentName / 9)
			{
				case 0:
					return "Piano";
				case 1:
					return "Chromatic Percussion";
				case 2:
					return "Organ";
				case 3:
					return "Guitar";
				case 4:
					return "Bass";
				case 5:
					return "Strings";
				case 6:
					return "Ensemble";
				case 7:
					return "Brass";
				case 8:
					return "Reed";
				case 9:
					return "Pipe";
				case 10:
					return "Synth Lead";
				case 11:
					return "Synth Pad";
				case 12:
					return "Synth Effects";
				case 13:
					return "Ethnic";
				case 14:
					return "Percussive";
				case 15:
					return "Sound Effects";
				default:
					return "Default";
					
			};
		}
	}
}