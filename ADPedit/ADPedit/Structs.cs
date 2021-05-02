using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADPedit
{
    public class adpFunc //make a struct with all the values from an adp function
    {
        public uint TimeID;
        public float timeSecondsMarker;
        public int unk;
        public int frameTime;
        public double padding;
        public uint ADPfuncID;
        public bool is30fps;
        public float ADPfuncVal;
        public string ADPfuncName;
    }
    public class adpHeader
    {
        public int count;
        public int unk0;
        public int dataLength;
        public int unk1;
        public int offset;
        public int trash1;
        public int trash2;
        public int trash3;
        public int trash4;
        public int trash5;
        public int trash6;
        public int trash7;
        public int trash8;
    }
}
