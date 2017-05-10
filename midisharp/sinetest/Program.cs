using System;
using System.Collections.Generic;
using static System.Console;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Devices;
 
namespace wavtest
{
   class Program
   {
      static Audio wa = new Audio();
      private static byte[] wavdata;
 
      private const int FREQUENCY = 44100;
      private const int SECONDS = 1;
 
      static void Main()
      {
        List<Byte> tempBytes = new List<byte>();
 
        Wavheader wavhead = new Wavheader();
        FormatChunk format = new FormatChunk();
        DataChunk data = new DataChunk();
 
        SineWave dataLeft = new SineWave(400.0f, FREQUENCY, SECONDS);
         
        SineWave dataRight = new SineWave(900.0f, FREQUENCY, SECONDS);
 
        data.AddSampleData(dataLeft.Data, dataRight.Data);
 
        wavhead.FileLength += format.Length() + data.Length();
 
        tempBytes.AddRange(wavhead.GetBytes());
        tempBytes.AddRange(format.GetBytes());
        tempBytes.AddRange(data.GetBytes());
 
        wavdata = tempBytes.ToArray();
        WriteLine("Press ENTER to play sine wave. Enter 'q' to quit.");

        bool repeat = true;
        while (repeat) {
            wa.Play(wavdata, AudioPlayMode.WaitToComplete);
            for (int i=0;i<0xf;i++) { Write((char)wavdata[i]); }
            if ((string)(ReadLine()) == "q") {repeat = false;}
        }
 
      }
 
   }
}