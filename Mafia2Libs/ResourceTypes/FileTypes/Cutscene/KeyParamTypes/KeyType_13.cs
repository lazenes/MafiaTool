using System.ComponentModel;
using System.IO;
using Utils.Extensions;

namespace ResourceTypes.Cutscene.KeyParams
{
    public class KeyType_13 : IKeyType
    {
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public class AnimationData
        {
            public int Unk01 { get; set; }
            public int Unk02 { get; set; } // Key Frame Start?
            public int Unk03 { get; set; } // Key Frame End?
            public byte Unk04 { get; set; } // Is Name Available?
            public string AnimationName { get; set; } // Links too .an2 file
            public int Unk05 { get; set; }
            public float Unk06 { get; set; }
            public int Unk07 { get; set; }
            public float Unk08 { get; set; }

            public override string ToString()
            {
                return string.Format("{0} Start: {1} End: {2}", AnimationName, Unk02, Unk03);
            }
        }

        public AnimationData[] Animations { get; set; }
        public ushort Unk01 { get; set; }

        public override void ReadFromFile(MemoryStream stream, bool isBigEndian)
        {
            base.ReadFromFile(stream, isBigEndian);

            int animationCount = stream.ReadInt32(isBigEndian);
            Animations = new AnimationData[animationCount];

            for (int i = 0; i < Animations.Length; i++)
            {
                AnimationData animation = new AnimationData();
                animation.Unk01 = stream.ReadInt32(isBigEndian);
                animation.Unk02 = stream.ReadInt32(isBigEndian);
                animation.Unk03 = stream.ReadInt32(isBigEndian);
                animation.Unk04 = stream.ReadByte8();
                animation.AnimationName = stream.ReadString16(isBigEndian);
                animation.Unk05 = stream.ReadInt32(isBigEndian);
                animation.Unk06 = stream.ReadSingle(isBigEndian);
                animation.Unk07 = stream.ReadInt32(isBigEndian);
                animation.Unk08 = stream.ReadSingle(isBigEndian);
                Animations[i] = animation;
            }

            Unk01 = stream.ReadUInt16(isBigEndian);
        }

        public override void WriteToFile(MemoryStream stream, bool isBigEndian)
        {
            base.WriteToFile(stream, isBigEndian);
            stream.Write(Animations.Length, isBigEndian);

            foreach(AnimationData Animation in Animations)
            {
                stream.Write(Animation.Unk01, isBigEndian);
                stream.Write(Animation.Unk02, isBigEndian);
                stream.Write(Animation.Unk03, isBigEndian);
                stream.WriteByte(Animation.Unk04);
                stream.WriteString16(Animation.AnimationName, isBigEndian);
                stream.Write(Animation.Unk05, isBigEndian);
                stream.Write(Animation.Unk06, isBigEndian);
                stream.Write(Animation.Unk07, isBigEndian);
                stream.Write(Animation.Unk08, isBigEndian);
            }

            stream.Write(Unk01, isBigEndian);
        }

        public override string ToString()
        {
            return string.Format("NumAnimations: {0}", Animations.Length);
        }
    }
}
