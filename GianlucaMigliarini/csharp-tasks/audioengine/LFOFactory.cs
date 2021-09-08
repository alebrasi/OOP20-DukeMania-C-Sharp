using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace taskcsharp
{
    public class LFOFactory
    {
        private LFOFactory()
        {

        }

        public enum Types
        {
            INTERVALS,
            STRAIGHT,
            SINE,
            SQUARE
        }

        /// <summary>
        /// create an lfo function from general arguments
        /// </summary>
        public static Func<long, float> General(Types type, float[] args, int duration)
        {
            switch (type)
            {
                case Types.INTERVALS: return null;
                case Types.STRAIGHT: return null;
                case Types.SINE: return null;
                case Types.SQUARE: return null;
                default: return x => 1f;
            }
        }

        /// <summary>
        /// create a traight line lfo
        /// </summary>
        public static Func<long, float> StraightLineLFO(float targetMult, int duration)
        {
            float sampleDuration = (float) duration * Settings.SAMPLESPERMILLI;
            float step = (targetMult - 1f) / sampleDuration;
            return x => 1 + (step * (x % sampleDuration));
        }

        /// <summary>
        /// create a square lfo, the frequency will shift from multMax to MultMin in duration ms
        /// </summary>
        public static Func<long, float> SquareLFO(float multMax, float multMin, int duration)
        {
            float sampleDuration = (float) duration * Settings.SAMPLESPERMILLI;
            return x => x % sampleDuration < sampleDuration / 2 ? multMax : multMin;
        }

        /// <summary>
        /// create an interval lfo, each array position will define a frequency / volume multiplier, the position is changed every duration ms
        /// </summary>
        public static Func<long, float> BuildIntervals(float[] multipliers, int duration)
        {
            int sampleDuration = (int) (duration * Settings.SAMPLESPERMILLI);
            int single = sampleDuration / multipliers.Length;
            return x => multipliers[(int) ((x % sampleDuration) / single)];
        }

        /// <summary>
        /// create an lfo with the shape of a sine wave
        /// </summary>
        public static Func<long, float> SineLFO(float multMax, float multMin, int duration)
        {
            float sampleDuration = (float) duration * Settings.SAMPLESPERMILLI;
            float initFreq = (float) (1d / (sampleDuration / Settings.SAMPLE_RATE));
            float period = Settings.SAMPLE_RATE / initFreq;
            float half = (multMax - multMin) / 2;
            float start = sampleDuration / 4;
            return x => (float) (multMin + half + Math.Sin(2.0 * Math.PI * (x + start) / period) * half);
        }
    }
}
