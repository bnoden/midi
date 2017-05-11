using System;
using System.Collections.Generic;
using static System.Console;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Devices;
using System.Media;

namespace wavtest
{
   class Program
   {
      static Audio wa = new Audio();
      private static byte[] wavdata;
 
      private const int FREQUENCY = 5500;
      private const int SECONDS = 1;

      public static void NuWav(double left, double right) {
            List<Byte> tempBytes = new List<byte>();
 
            Wavheader wavhead = new Wavheader();
            FormatChunk format = new FormatChunk();
            DataChunk data = new DataChunk();
 
            SineWave dataLeft = new SineWave(left, FREQUENCY, SECONDS);
            SineWave dataRight = new SineWave(right, FREQUENCY, SECONDS);

            data.AddSampleData(dataLeft.Data, dataRight.Data);
 
            wavhead.FileLength += format.Length() + data.Length();
 
            tempBytes.AddRange(wavhead.GetBytes());
            tempBytes.AddRange(format.GetBytes());
            tempBytes.AddRange(data.GetBytes());
 
            wavdata = tempBytes.ToArray();
            wa.Play(wavdata, AudioPlayMode.WaitToComplete);
        }
 
      static void Main()
      {
        //NuWav(400,700);
        
        //WriteLine("Press ENTER to play sine wave. Enter 'q' to quit.\n");
        
        bool repeat = true;
        
        while (repeat) {
            int left = 2, right = 8;
            char[] bnoden = {'b','n','o','d','e','n','\0'};
            char bn = ' ';
            int j = 0;
            for (int i = 64; i < 256; i++) {
                    if (i%(j+1)==0) {
                        left-=(left*2);
                    }


                    bn = bnoden[j];
                    j=(j+1)>6?0:j+1;

                    if (i%3==0) {
                        left=right;
                    }
                    if (i%5==0) {
                        right=left;
                    }
                    if (i % 7 == 0) {
                        left = right/2;
                    }
                    if (i % 11 == 0) {
                        right = left/2;
                    }

                    Write($"{bn} {i-63} {(char)(left)} {left}");
                    NuWav(left+=i/4, right-=i);
                    
                    NuWav(0.0, right+=i/8);
                    Write($"{i-63} {(char)(i)} n {i}");
                    NuWav(left-=i+1, right+=left);
                    
                    NuWav(0.0, right-=i-1);
                    Write($"{i-63} {(char)(right)} {(right)}");
                    NuWav(right/3, left/3);
                    
                    NuWav(left+=1, right+=1);
                    Write($"{i-63} {(char)(left)} {left}");
                    left = i; //right = 0;
                    
                    NuWav(left/=6, right*=8);
                    Write($"{i-63} {(char)(i)} n {i}");
                    NuWav(left*=10, right/=12);
                    WriteLine($"{i-63} {(char)(right)} {(right)}");
                    left = 0; //right = i;

                    if (i>64&&i%64==0) {
                        WriteLine("Press ENTER to continue. Enter 'q' to quit.");
                        if ((string)(ReadLine()) == "q") {repeat = false;}
                    }

                }
            if ((string)(ReadLine()) == "q") {repeat = false;}
        }
 
      }
 
   }
}