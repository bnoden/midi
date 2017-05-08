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

            WriteLine($"Press ENTER to hear {strJump}. Enter 'q' to quit.");

            bool repeat = true;
            while (repeat) {
                if ((char)(Read()) == 'q') {repeat = false;}
                wa.Play(wavdata, AudioPlayMode.Background);
                
            }


        }
    }
}
