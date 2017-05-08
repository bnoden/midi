using System;
using System.IO;
using static System.Console;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Devices;

namespace Wavtest {
    class Program {
       static Audio wa = new Audio();
        
        private static byte[] wavdata;
        

        static void Main(string[] args) {
            //var curdir = Directory.GetCurrentDirectory();
            string dirFX = $"{Directory.GetCurrentDirectory()}\\res\\", strJump = "Jump.wav";

            wavdata = File.ReadAllBytes($"{dirFX}{strJump}");

            WriteLine($"Playing {strJump}\nrepeat=true");
            
            int count = 5;
            while (count>0) {
                wa.Play(wavdata, AudioPlayMode.WaitToComplete);
                count--;
            }


        }
    }
}
