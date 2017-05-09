using System;
using System.IO;
using System.Text;
using static System.Console;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Devices;

// note that VB is not currently supported on .NET Core, so this is using .NET Framework

namespace wavtest
{
    class Program
    {
       static Audio wa = new Audio();
        
        private static byte[] wavdata;
        static bool ok = true;

        static void Main(string[] args) {
            string dirWav = "";
            string strJump = "Jump.wav";
            try {
                dirWav = $"{Directory.GetCurrentDirectory()}\\wav\\";
                wavdata = File.ReadAllBytes($"{dirWav}{strJump}");
            } catch (DirectoryNotFoundException) {
                ok = false;
                WriteLine("Directory not found");
                ReadKey();
            }
            
            if (ok) {
                WriteLine($"Press ENTER to play {strJump}. Enter 'q' to quit.");

                bool repeat = true;
                while (repeat) {
                    if ((char)(Read()) == 'q') {repeat = false;}

                    //Wavheader w = new Wavheader();
                    wa.Play(wavdata, AudioPlayMode.Background);

                    for (int i=0;i<0xf;i++) {
                        Write((char)wavdata[i]);
                    }
                }
            }


        }
    }
}
