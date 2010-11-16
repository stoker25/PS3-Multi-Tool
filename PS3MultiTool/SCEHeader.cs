using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using PS3MultiTool.IO;

namespace PS3MultiTool
{
    public interface ISCEMainHeader
    {
        void Load();
    }
    public class SCEHeader
    {
        public class SCEELFHeader : ISCEMainHeader
        {
            private SCEHeader mainHeader;
            public ulong Unknown1;
            public ulong Unknown2;
            public ulong Unknown3;
            public ulong Unknown4;
            public ulong Unknown5;
            public ulong ELFInformationOffset;
            public SCEELFHeader(SCEHeader main)
            {
                mainHeader = main;
            }
            public void Load()
            {
                Unknown1 = mainHeader.IO.Reader.ReadUInt64();
                Unknown2 = mainHeader.IO.Reader.ReadUInt64();
                Unknown3 = mainHeader.IO.Reader.ReadUInt64();
                Unknown4 = mainHeader.IO.Reader.ReadUInt64();
                Unknown5 = mainHeader.IO.Reader.ReadUInt64();
                ELFInformationOffset = mainHeader.IO.Reader.ReadUInt64();
            }
        }
        public class SCEPKGHeader : ISCEMainHeader
        {
            private SCEHeader mainHeader;
            public byte[] SignatureData; // not sure what it is, 0x260 bytes though
            public SCEPKGHeader(SCEHeader main)
            {
                mainHeader = main;
            }
            public void Load()
            {
                SignatureData = mainHeader.IO.Reader.ReadBytes(0x260);
            }
        }
        public static Hashtable FileTypes = new Hashtable()
	    {
	    	{(ushort)0x1, "SELF Executable"},
	    	{(ushort)0x3, "Update PKG"}
	    };
        public X360IO IO;
        public ISCEMainHeader MainHeader;
        public uint Magic;
        public uint Version;
        public ushort Flags;
        public ushort FileType; // 1 = ELF, 3 = Update Package
        public uint Unknown1;
        public ulong HeaderSize;
        public ulong Unknown2;
        public bool IsContentEncrypted
        {
            get
            {
                return !IsBitSet(Flags, 15);
            }
        }
        public static bool IsBitSet(ushort value, byte index)
        {
            return ((value & (1 << index)) != 0);
        }
        public void Load(string fileName)
        {
            Load(new X360IO(fileName, FileMode.Open, true));
        }

        public void Load(X360IO io)
        {
            IO = io;
            IO.Stream.Position = 0x0;
            Magic = IO.Reader.ReadUInt32();
            if (Magic != 0x53434500)
                return;
            Version = IO.Reader.ReadUInt32();
            Flags = IO.Reader.ReadUInt16();
            FileType = IO.Reader.ReadUInt16();
            Unknown1 = IO.Reader.ReadUInt32();
            HeaderSize = IO.Reader.ReadUInt64();
            Unknown2 = IO.Reader.ReadUInt64();
            switch(FileType)
            {
                case 1:
                    MainHeader = new SCEELFHeader(this);
                    break;
                case 3:
                    MainHeader = new SCEPKGHeader(this);
                    break;
            }
            if(MainHeader != null)
                MainHeader.Load();
        }

        public byte[] UnFSELF()
        {
            if(FileType == 1 && !IsContentEncrypted)
            {
                IO.Stream.Position = (long)HeaderSize;
                byte[] data = IO.Reader.ReadBytes((int) (IO.Stream.Length - (long)HeaderSize)); // BADBADBAD
                return data;
            }
            return null;
        }
    }
}
