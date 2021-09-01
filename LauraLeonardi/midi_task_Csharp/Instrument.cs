﻿using System;
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

		public enum InstrumentType
		{
			ACOUSTIC_GRAND_PIANO, BRIGHT_ACOUSTIC_PIANO, ELECTRIC_GRAND_PIANO, HONKY_TONK_PIANO, ELECTRIC_PIANO_1,
			ELECTRIC_PIANO_2, HARPSICHORD, CLAVINET,
			CELESTA, GLOCKENSPIEL, MUSIC_BOX, VIBRAPHONE, MARIMBA, XYLOPHONE, TUBULAR_BELLS, DULCIMER,
			DRAWBAR_ORGAN, PERCUSSIVE_ORGAN, ROCK_ORGAN, CHURCH_ORGAN, REED_ORGAN, ACCORDION, HARMONICA, TANGO_ACCORDION,
			ACOUSTIC_GUITAR_N, ACOUSTIC_GUITAR_S, ELECTRIC_GUITAR_J, ELECTRIC_GUITAR_C, ELECTRIC_GUITAR_M, OVERDRIVEN_GUITAR,
			DISTORTION_GUITAR, GUITAR_ARMONICS,
			ACOUSTIC_BASS, ELECTRIC_BASS_F, ELECTRIC_BASS_P, FRETLESS_BASS, SLAP_BASS_1, SLAP_BASS_2, SYNTH_BASS_1, SYNTH_BASS_2,
			VIOLIN, VIOLA, CELLO, CONTRABASS, TREMOLO_STRINGS, PIZZICATO_STRINGS, ORCHESTRAN_HARP, TIMPANI,
			STRING_ENSEMBLE_1, STRING_ENSEMBLE_2, SYNTH_STRINGS_1, SYNTH_STRINGS_2, CHOIR_AAHS, VOICE_OOHS, SYNTH_VOICE, ORCHESTRA_HIT,
			TRUMPET, TROMBONE, TUBA, MUTED_TRUMPET, FRENCH_HORN, BRASS_SECTION, SYNTH_BRASS_1, SYNTH_BRASS_2,
			SOPRANO_SAX, ALTO_SAX, TENOR_SAX, BARITONE_SAX, OBOE, ENGLISH_HORN, BASSOON, CLARINET,
			PICCOLO, FLUTE, RECORDER, PAN_FLUTE, BLOWN_BOTTLE, SHAKUHACHI, WHISTLE, OCARINA,
			LEAD_1, LEAD_2, LEAD_3, LEAD_4, LEAD_5, LEAD_6, LEAD_7, LEAD_8,
			PAD_1, PAD_2, PAD_3, PAD_4, PAD_5, PAD_6, PAD_7, PAD_8,
			FX_1, FX_2, FX_3, FX_4, FX_5, FX_6, FX_7, FX_8,
			SITAR, BANJO, SHAMISEN, KOTO, KALIMBA, BAG_PIPE, FIDDLE, SHANAI,
			TINKLE_BELL, AGOGO, STEEL_DRUMS, WOODBLOCK, TAIKOP_DRUM, MELODIC_TOM, SYNT_DRUM, REVERSE_CYMBAL,
			GUITAR_FRET_NOISE, BREATH_NOISE, SEASHORE, BIRD_TWEET, TELEPHONE_RING, HELICOPTER, APPLAUSE, GUNSHOT
		};
	}
}