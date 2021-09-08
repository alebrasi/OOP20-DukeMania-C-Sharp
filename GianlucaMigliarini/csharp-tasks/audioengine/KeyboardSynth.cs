using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace taskcsharp
{
    public class KeyboardSynth
    {
        private readonly Dictionary<int, IBufferManager> keys = new Dictionary<int, IBufferManager>();

        private static IBufferManager CreateNoteBuffer(Enveloper env, float freq, long time, WaveTable[] waves, Func<long, float> noteLFO, Func<long, float> volumeLFO, double[] offsets)
        {
            var steps = offsets.ToList().Select(x => (Settings.WAVETABLE_SIZE * (x * freq)) / Settings.SAMPLE_RATE).ToList();
            double[] positions = new double[steps.Count()];
            int total = (int) (time * Settings.SAMPLESPERMILLI + env.GetTime() + 1000);

            double[] buff = Enumerable.Range(0, total).ToList().Select(k =>
            {
                float noteLfoVal = noteLFO.Invoke(k);
                return Enumerable.Range(0, steps.Count()).ToList().Select(x =>
                {
                    positions[x] = positions[x] + steps[x] * noteLfoVal;
                    return (double) waves[x].GetAt((int)(positions[x] % Settings.WAVETABLE_SIZE));
                }).Sum() / steps.Count() * volumeLFO.Invoke(k) / waves.Length;
            }).ToArray();

            return env.CreateBufferManager(buff);
        }

        /// <summary>
        /// synth constructor, automatically creates all the note buffer
        /// </summary>
        public KeyboardSynth(Enveloper env, WaveTable[] waves, Func<long, float> nlfo, Func<long, float> vlfo, double[] offsets, List<KeyValuePair<int, long>> freqs)
        {
            int numA4 = 69;
            int numNote = 12;
            double freqA4 = 440;
            freqs.ForEach((kvp) => {
                float freq = (float)(Math.Pow(2, (double)(kvp.Key - numA4) / numNote) * freqA4);
                keys.Add(kvp.Key, CreateNoteBuffer(env, freq, kvp.Value, waves, nlfo, vlfo, offsets));
            });
        }

        /// <summary>
        /// tells how many notes are currently playing
        /// </summary>
        public int CheckKeys()
        {
            return keys.Values.Where(x => x.HasNext()).Count();
        }

        /// <summary>
        /// get a single sample from all the playing notes 
        /// </summary>
        public float SetSample()
        {
            return keys.Values.Where(x => x.HasNext()).Select(x => x.Next()).Count();
        }

        /// <summary>
        /// play a note for a specified time
        /// </summary>
        public void PlayTimedNote(int identifier, long microseconds)
        {
            keys[identifier].Refresh(microseconds / 1000);
        }
    }
}
