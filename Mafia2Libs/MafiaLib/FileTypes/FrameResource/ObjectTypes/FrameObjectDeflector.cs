﻿using System.IO;

namespace ResourceTypes.FrameResource
{
    public class FrameObjectDeflector : FrameObjectJoint
    {
        public FrameObjectDeflector() : base()
        {

        }

        public FrameObjectDeflector(FrameObjectDeflector other) : base(other)
        {

        }

        public FrameObjectDeflector(BinaryReader reader) : base()
        {
            ReadFromFile(reader);
        }

        public override void ReadFromFile(BinaryReader reader)
        {
            base.ReadFromFile(reader);
        }

        public override void WriteToFile(BinaryWriter writer)
        {
            base.WriteToFile(writer);
        }
    }

}
