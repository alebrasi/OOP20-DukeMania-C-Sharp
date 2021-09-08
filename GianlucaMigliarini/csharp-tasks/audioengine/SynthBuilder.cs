using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace taskcsharp
{
    public class SynthBuilder
    {
        private Enveloper _env;
        private WaveTable[] _waves;
        private double[] _offsets;
        private Func<long, float> _noteLFO = null;
        private Func<long, float> _volumeLFO = null;

        public Enveloper GetEnv()
        {
            return _env;
        }
        public WaveTable[] GetWaves()
        {
            return _waves;
        }
        public double[] GetOffsets()
        {
            return _offsets;
        }
        public void GetEnveloper(Enveloper env)
        {
            _env = env;
        }
        public void GetWavetables(WaveTable[] waves)
        {
            _waves = waves;
        }
        public void GetOffsets(double[] offsets)
        {
            _offsets = offsets;
        }
        public void SetNoteLFO(Func<long, float> lfo)
        {
            _noteLFO = lfo;
        }
        public void SetVolumeLFO(Func<long, float> lfo)
        {
            _volumeLFO = lfo;
        }

        /// <summary>
        /// build the synthesizer
        /// </summary>
        public KeyboardSynth Build(List<KeyValuePair<int, long>> freqs)
        {
            if (_env == null || _waves == null || _offsets == null) {
                throw new Exception("offsets, enveloper or wavetables are null");
            }
            if (_waves.Length != _offsets.Length) {
                throw new Exception("wavetables and offsets do not match");
            }
            return new KeyboardSynth(
                _env,
                _waves,
                _noteLFO == null ? x => 1f : _noteLFO,
                _volumeLFO == null ? x => 1f : _volumeLFO,
                _offsets,
                freqs
            );
        }
    }
}
