using System;
 
namespace wavtest
{
   public class SineWave
   {
      private  double _frequency;
      private readonly UInt32 _sampleRate;
      private readonly UInt16 _seconds;
      private short[] _dataBuffer;
 
      public short[] Data { get{ return _dataBuffer; }}
 
      public SineWave(double f, UInt32 r, UInt16 s) {
         _frequency = f;
         _sampleRate = r;
         _seconds = s;
         GenerateData();
      }

      public void setFrequency(double f) {
            _frequency = f;
      }
      public double getFrequency() {return _frequency;}
 
      private void GenerateData() {
         uint bufferSize = _sampleRate * _seconds;
         _dataBuffer = new short[bufferSize];
 
         int amplitude = 32760;
 
         double duration = (Math.PI*2*_frequency)/_sampleRate;
 
         for (uint i = 0; i < bufferSize-1; i++) {
            _dataBuffer[i]=Convert.ToInt16(amplitude*Math.Sin(duration * i));
         }
      }
   }
}