﻿using System;
using System.Collections.Generic;
using System.Text;
 
namespace wavtest
{
   public class Wavheader
   {
      private const string FILE_TYPE_ID = "RIFF";
      private const string MEDIA_TYPE_ID = "WAVE";
 
      public string FileTypeId { get; private set; }
      public UInt32 FileLength { get; set; }
      public string MediaTypeId { get; private set; }
 
      public Wavheader() {
         FileTypeId = FILE_TYPE_ID;
         MediaTypeId = MEDIA_TYPE_ID;
         FileLength = 4;
      }
 
      public byte[] GetBytes()
      {
         List<Byte> chunkData = new List<byte>();
         chunkData.AddRange(Encoding.ASCII.GetBytes(FileTypeId));
         chunkData.AddRange(BitConverter.GetBytes(FileLength));
         chunkData.AddRange(Encoding.ASCII.GetBytes(MediaTypeId));
         return chunkData.ToArray();
      }
 
   }
}