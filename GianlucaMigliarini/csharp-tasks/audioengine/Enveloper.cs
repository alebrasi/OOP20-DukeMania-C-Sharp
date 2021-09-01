using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace taskcsharp
{
    public class Enveloper
    {
        private readonly long _atk;
        private readonly long _rel;
        private readonly float _atkVol;
        private readonly float _step1;

        public Enveloper(long atk, float atkVol, long rel)
        {
            _atkVol = atkVol;
            _rel = rel;
            _atk = atk;
            _step1 = (atkVol / atk) / Settings.SAMPLESPERMILLI;
        }

        public long GetTime()
        {
            return (long) ((_atk + _rel) * Settings.SAMPLESPERMILLI);
        }

        private class BufferManager : IBufferManager
        {
            private int _processedSamples;
            private int _reset = -1;
            private float _actual;
            private float _totalSamples;
            private float _resetStep;
            private float _step2;
            private readonly Enveloper _parent;
            private readonly double[] _buffer;

            public BufferManager(double[] buffer, Enveloper parent)
            {
                _buffer = buffer;
                _parent = parent;
            }

            public bool HasNext()
            {
                return _reset >= 0 || _processedSamples < _totalSamples || _actual > 0;
            }

            public float Next()
            {
                if (_reset > 0)
                {
                    _actual -= _resetStep;
                }
                else
                {
                    if (_reset == 0)
                    {
                        _processedSamples = 0;
                        _actual = 0;
                    }
                    if (_processedSamples >= _totalSamples)
                    {
                        if (_step2 == 0)
                        {
                            _step2 = (_actual / (_parent._rel * Settings.SAMPLESPERMILLI)) * -1;
                        }
                        if (_actual <= 0)
                        {
                            _processedSamples++;
                            return 0F;
                        }
                        _actual += _step2;
                    }
                    else
                    {
                        if (_actual >= _parent._atkVol)
                        {
                            return _parent._atkVol * (float) _buffer[_processedSamples++];
                        }
                        _actual += _parent._step1;
                    }
                }

                _reset--;
                return (float) _buffer[_processedSamples++] * _actual;
            }

            public void Refresh(long ttl)
            {
                _totalSamples = ttl * Settings.SAMPLESPERMILLI + Settings.ATTENUATION;
                _resetStep = _actual / Settings.ATTENUATION;
                _reset = Settings.ATTENUATION;
                _step2 = 0;
            }
        }

        public IBufferManager CreateBufferManager(double [] buffer)
        {
            return new BufferManager(buffer, this);
        }
    }
}
