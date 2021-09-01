using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace taskcsharp
{
    public sealed class WaveTable
    {
        private WaveTable()
        {

        }

        private static Random _rnd = new Random();
        public static readonly WaveTable SINE = new WaveTable((i, period) => (float) (Math.Sin(2.0 * Math.PI * i / period) * Settings.MAX_VOLUME));
        public static readonly WaveTable TRIANGLE = new WaveTable((i, period) => (float) (2 / Math.PI * Math.Asin(Math.Sin(2 * Math.PI * i / period)) * Settings.MAX_VOLUME));
        public static readonly WaveTable SQUARE = new WaveTable((i, period) => (float) (i < period / 2 ? 1 : -1 * Settings.MAX_VOLUME));
        public static readonly WaveTable SAW = new WaveTable((i, period) => (float) (-2 / Math.PI * Math.Atan(1 / Math.Tan(Math.PI * i / period)) * Settings.MAX_VOLUME));
        public static readonly WaveTable NOISE = new WaveTable((i, period) => (float) (_rnd.NextDouble()));

        public static IEnumerable<WaveTable> GetValues()
        {
            yield return SINE;
            yield return TRIANGLE;
            yield return SQUARE;
            yield return SAW;
            yield return NOISE;
        }

        private readonly float[] _wave = new float[(int) Settings.WAVETABLE_SIZE];

        public WaveTable(Func<float, float, float> mapper)
        {
            float initFreq = (float)(1d / (Settings.WAVETABLE_SIZE / Settings.SAMPLE_RATE));
            float period = Settings.SAMPLE_RATE / initFreq;

            for (float i = 0; i < Settings.WAVETABLE_SIZE; i++)
            {
                _wave[(int)i] = mapper.Invoke(i, period);
            }
        }

        public float[] GetWave()
        {
            return _wave;
        }

        public float GetAt(int pos)
        {
            return _wave[pos];
        }
    }
}