using Microsoft.VisualStudio.TestTools.UnitTesting;
using taskcsharp;
using System.Collections.Generic;
using System.Linq;
using System;

namespace automate_testing
{
    [TestClass]
    public class UnitTest1
    {
        private bool CheckTolerance(double actual, double exact)
        {
            double tolerance = 1e-4;
            return System.Math.Abs(actual - exact) < tolerance;
        }

        [TestMethod]
        public void TestKeyboardSynth()
        {
            float atkVol = 1.5f;
            SynthBuilder builder = new SynthBuilder();
            Enveloper env = new Enveloper(100, atkVol, 100);
            builder.GetEnveloper(env);
            builder.GetWavetables(new WaveTable[]{WaveTable.SAW});
            builder.GetOffsets(new double[] { 1 });
            List<KeyValuePair<int, long>> notes = new List<KeyValuePair<int, long>>();
            notes.Add(new KeyValuePair<int, long>(100, 10000));
            notes.Add(new KeyValuePair<int, long>(200, 100000));

            KeyboardSynth ks = builder.Build(notes);

            Assert.AreEqual(0, ks.CheckKeys());
            ks.PlayTimedNote(100, 1000000);
            Assert.AreEqual(1, ks.CheckKeys());

            Assert.IsTrue(ks.SetSample() != 0);

            List<float> allValues = Enumerable.Range(0, 300000).ToList().Select(x => ks.SetSample()).ToList();

            float max = allValues.Max();
            float min = allValues.Min();
            Assert.IsTrue(max <= atkVol && min >= -atkVol);

            Enumerable.Range(0, 10000).ToList().ForEach(x => ks.SetSample());
            Assert.AreEqual(0, ks.CheckKeys());
        }

        [TestMethod]
        public void TestBuilder() {
            SynthBuilder builder = new SynthBuilder();
            builder.GetWavetables(new WaveTable[]{WaveTable.SAW});
            builder.GetOffsets(new double[]{1.0, 2.0});
            
            try
            {
                builder.Build(new List<KeyValuePair<int, long>>());
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "offsets, enveloper or wavetables are null");
            }

            builder.GetEnveloper(new Enveloper(100, 1f, 100));

            try
            {
                builder.Build(new List<KeyValuePair<int, long>>());
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "wavetables and offsets do not match");
            }

            builder.GetWavetables(new WaveTable[]{WaveTable.SAW, WaveTable.SQUARE});
            builder.Build(new List<KeyValuePair<int, long>>());
        }

        [TestMethod]
        public void TestStraightLFO()
        {
            float targetMult = 1.5f;
            Func<long, float> lfo = LFOFactory.StraightLineLFO(targetMult, 500);
            int totalSamples = (int) (500 * Settings.SAMPLESPERMILLI);
            float[] arrStraight = Enumerable.Range(0, totalSamples).Select(x => lfo.Invoke(x)).ToArray();
            Assert.IsTrue(!Enumerable.Range(0, arrStraight.Length - 1).Any(i => arrStraight[i] > arrStraight[i + 1]));
            Assert.AreEqual(1.0, lfo.Invoke(totalSamples), 0.0);
            Assert.IsTrue(CheckTolerance(lfo.Invoke(totalSamples - 1), targetMult));
        }

        [TestMethod]
        public void TestSineLFO()
        {
            float multMax = 2f, multMin = 1.5f;
            Func<long, float> lfo = LFOFactory.SineLFO(multMax, multMin, 2000);
            int totalSamples = (int)(2000 * Settings.SAMPLESPERMILLI);
            List<float> arrSine = Enumerable.Range(0, totalSamples).Select(x => lfo.Invoke(x)).ToList();
            Assert.AreEqual(multMax, arrSine[0]);
            Assert.AreEqual(multMin, arrSine[(int)(totalSamples / 2)]);
            Assert.AreEqual(multMax, arrSine[(int)(totalSamples - 1)]);
            Assert.IsTrue(arrSine[(int)(totalSamples / 4)] > multMin || arrSine[(int)(totalSamples / 4)] < multMax);
            Assert.IsTrue(arrSine[(int)(totalSamples / multMin)] < -multMin || arrSine[(int)(totalSamples / multMin)] > -multMax);
        }

        [TestMethod]
        public void TestSquareLFO()
        {
            float multMax = 1.5f, multmin = 0.8f;
            Func<long, float> lfo = LFOFactory.SquareLFO(multMax, multmin, 1000);
            int totalSamples = (int)(1000 * Settings.SAMPLESPERMILLI);
            List<float> arrSquare = Enumerable.Range(0, totalSamples).Select(x => lfo.Invoke(x)).ToList();
            var frequencyCounter = from sample in arrSquare
                                   group sample by sample into grp
                                   select new { key = grp.Key, cnt = grp.Count() };
            Assert.IsTrue(frequencyCounter.All(x => x.cnt == totalSamples / 2));
        }

        [TestMethod]
        public void TestIntervalLFO()
        {
            float int1 = 1f, int2 = 0.3f, int3 = 1f, int4 = 1.5f;
            Func<long, float> lfo = LFOFactory.BuildIntervals(new float[] { int1, int2, int3, int4 }, 1000);
            int totalSamples = (int)Settings.SAMPLE_RATE;
            List<float> arrIntervals = Enumerable.Range(0, totalSamples).Select(x => lfo.Invoke(x)).ToList();
            Assert.AreEqual(int1, arrIntervals[0]);
            Assert.AreEqual(int2, arrIntervals[(int)(totalSamples / 4)]);
            Assert.AreEqual(int3, arrIntervals[(int)(totalSamples / 2)]);
            Assert.AreEqual(int4, arrIntervals[(int)(totalSamples - 1)]);
        }
    }
}
