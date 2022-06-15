using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADPedit
{
    public class adpFunc //make a struct with all the values from an adp function
    {
        public uint Padding;
        public byte[] timeSecondsMarker;
        public float TimeSeconds;
        public int frameTime;
        public int unk2;
        public int altFlag;
        public double padding;
        public uint ADPfuncID;
        public bool is30fps;
        public float ADPfuncVal;
        public string ADPfuncName;
    }
    public class adpHeader
    {
        public long count;
        public int unk0;
        public long dataLength;
        public int unk1;
        public long offset;
        public int unk2;
        public int unk3;
        public byte[] unkLayout;
    }
}
