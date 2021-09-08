using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace taskcsharp
{
    public class Settings
    {

        private static readonly float DEFAULT_SAMPLE_RATE = 22100;
        private static readonly int DEFAULT_BUFFER_SIZE = 512;

        /// <summary>
        /// The available sample rates.
        /// </summary>
        public static readonly int[] AVAILABLE_SAMPLE_RATES = { 11000, 22100, 44100, 128000, 192000 };
        /// <summary>
        /// The available buffer sizes.
        /// </summary>
        public static readonly int[] AVAILABLE_BUFFER_SIZES = { 128, 256, 512, 1024, 2048, 4096, 8192 };

        /// <summary>
        /// How many samples are played every seconds.
        /// </summary>
        public static float SAMPLE_RATE = DEFAULT_SAMPLE_RATE;
        /// <summary>
        /// The maxium default volume.
        /// </summary>
        public static readonly double MAX_VOLUME = 1;
        /// <summary>
        /// How many samples copmpose a buffer.
        /// </summary>
        public static int BUFFER_LENGHT = DEFAULT_BUFFER_SIZE;
        /// <summary>
        /// How many samples are played every millisecond.
        /// </summary>
        public static readonly float SAMPLESPERMILLI = Settings.SAMPLE_RATE / 1000f;
        /// <summary>
        /// The number of samples that compose a wavetable.
        /// </summary>
        public static readonly float WAVETABLE_SIZE = 8192;
        /// <summary>
        /// The number of attenuations samples, to restart the note.
        /// </summary>
        public static readonly int ATTENUATION = 300;


        private Settings()
        {

        }

        static void Main(string[] args)
        {
            
        }
    }
}
