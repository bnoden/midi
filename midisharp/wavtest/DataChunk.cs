using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace wavtest
{
    public class DataChunk 
    {
        private const string CHUNK_ID = "data";

        public string ChunkId {get;private set;}
        public UInt32 ChunkSize {get;set;}
        public short[] WaveData {get; private set;}

        public DataChunk() {
            ChunkId = CHUNK_ID;
            ChunkSize = 0;
        }

        public UInt32 Length() {return (UInt32)GetBytes().Length;}

        public byte[] GetBytes() {
            List<Byte> chunkBytes = new List<Byte>();
            chunkBytes.AddRange(Encoding.ASCII.GetBytes(ChunkId));
            chunkBytes.AddRange(BitConverter.GetBytes(ChunkSize));
            byte[] bufferBytes = new byte[WaveData.Length*2];
            Buffer.BlockCopy(WaveData, 0, bufferBytes, 0, bufferBytes.Length);
            chunkBytes.AddRange(bufferBytes.ToList());

            return chunkBytes.ToArray();
        }

        public void AddSampleData(short[] bufferLeft, short[] bufferRight) {
            WaveData = new short[bufferLeft.Length+bufferRight.Length];
            int offset = 0;
            for (int i = 0; i < WaveData.Length; i+=2) {
                WaveData[i] = bufferLeft[offset];
                WaveData[i++] = bufferRight[offset];
                offset++;
            }
            ChunkSize = (UInt32)WaveData.Length*2;
        }

    }
}
