using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
 
namespace miditest
{
   class Program
   {
      // MCI Interface
      [DllImport("winmm.dll")]
      private static extern long mciSendString(string command,
         StringBuilder returnValue, int returnLength,
         IntPtr winHandle);
 
      // midi API
      [DllImport("winmm.dll")]
      private static extern int midiOutGetNumDevs();
 
      [DllImport("winmm.dll")]
      private static extern int midiOutGetDevCaps(Int32 uDeviceID,
         ref MidiOutCaps lpMidiOutCaps, UInt32 cbMidiOutCaps);
 
      [DllImport("winmm.dll")]
      private static extern int midiOutOpen(ref int handle,
         int deviceID, MidiCallBack proc, int instance, int flags);
 
      [DllImport("winmm.dll")]
      private static extern int midiOutShortMsg(int handle,
         int message);
 
      [DllImport("winmm.dll")]
      private static extern int midiOutClose(int handle);
 
      private delegate void MidiCallBack(int handle, int msg,
         int instance, int param1, int param2);
 
      static string Mci(string command)
      {
         StringBuilder reply = new StringBuilder(256);
         mciSendString(command, reply, 256, IntPtr.Zero);
         return reply.ToString();
      }
 
      static void MciMidiTest()
      {
            var res = String.Empty;

            string dirmid = $"{Directory.GetCurrentDirectory()}\\mid\\";
            string mfname ="ff6f.mid";

            res = Mci($"open \"{dirmid}{mfname}\" alias music");
            res = Mci("play music");
            Console.WriteLine($"{dirmid}{mfname}");
            Console.ReadLine();
            res = Mci("close crooner");
      }
 
      static void Main() {
            

            
            MciMidiTest();
      }
 
   }
}