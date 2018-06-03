﻿using System.IO;

namespace Mafia2
{
    public class ActorParse
    {
        public ActorParse(BinaryReader reader)
        {
            ReadFromFile(reader);
        }

        public void ReadFromFile(BinaryReader reader)
        {
            int poolLength = reader.ReadInt32();
            string pool = new string(reader.ReadChars(poolLength));

            int hashesLength = reader.ReadInt32()+12;

            ActorDefinition[] actors = new ActorDefinition[hashesLength];
            for (int i = 0; i != hashesLength; i++)
            {
                actors[i] = new ActorDefinition(reader);
                int pos = actors[i].namePos;
                actors[i].name = pool.Substring(pos, pool.IndexOf('\0', pos) - pos);
            }

        }

        public struct ActorDefinition
        {
            ulong hash; //hash, this is the same as in the frame.
            short unk01; //i feel like this has something to do with scenes.
            public short namePos; //starting position for the name.
            int frameIndex; //links to FrameResource

            public string name;

            public ActorDefinition (BinaryReader reader)
            {
                hash = reader.ReadUInt64();
                unk01 = reader.ReadInt16();
                namePos = reader.ReadInt16();
                frameIndex = reader.ReadInt32();
                name = "";
            }

            public override string ToString()
            {
                return string.Format("{0}, {1}", hash, name);
            }
        }
    }
}
