﻿using System;
using System.IO;
using static System.Console;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Devices;

// note that VB is not currently supported on .NET Core, so this is using .NET Framework

namespace Wavtest {
    class Program {
       static Audio wa = new Audio();
        
        private static byte[] wavdata;
        static bool ok = true;

        static void Main(string[] args) {
            string strJump = "Jump.wav";
            try {
                string dirFX = $"{Directory.GetCurrentDirectory()}\\res\\";
                wavdata = File.ReadAllBytes($"{dirFX}{strJump}");
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
                wa.Play(wavdata, AudioPlayMode.Background);
                }
            }


        }
    }
}
