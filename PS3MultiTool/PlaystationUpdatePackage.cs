using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using PS3MultiTool.IO;

namespace PS3MultiTool
{
    public class PlaystationUpdatePackage
    {
        public static Hashtable FileNames = new Hashtable()
	    {
	    	{(long)0x100, "version.txt"},
	    	{(long)0x101, "license.txt"},
            {(long)0x102, "promo_flag.txt"},
            {(long)0x103, "update_flags.txt"}, // contents: XYZZ (e.g. 0100, 1000) x = patch file, y = demo/debug, Z = unknown
            {(long)0x104, "patch_build.txt"},
            {(long)0x200, "updater.self"},
            {(long)0x201, "vsh.tar"},
            {(long)0x202, "dots.txt"},
            {(long)0x203, "patch_data.pkg"},
            {(long)0x300, "update_files.tar"}
	    };

        public class FileEntry
        {
            public long ID;
            public long Offset;
            public long Size;
            public long Padding;
            public HashEntry Hash;
        }
        public class HashEntry
        {
            public long FileID;
            public byte[] HMACSHA1;
            public int Padding;
        }
        public long Magic;
        public long Version;
        public long ImageVersion;
        public long FileCount;
        public long HeaderSize;
        public long DataSize;
        public byte[] HeaderHash;
        public byte[] Padding;
        public List<FileEntry> Files;
        public List<HashEntry> Hashes;
        public X360IO IO;

        public void Load(string fileName)
        {
            Load(new X360IO(fileName, FileMode.Open, true));
        }
        public void Load(X360IO io)
        {
            IO = io;
            IO.Stream.Position = 0x0;
            Magic = IO.Reader.ReadInt64();
            if (Magic != 0x5343455546000000)
                return;
            Version = IO.Reader.ReadInt64();
            ImageVersion = IO.Reader.ReadInt64();
            FileCount = IO.Reader.ReadInt64();
            HeaderSize = IO.Reader.ReadInt64();
            DataSize = IO.Reader.ReadInt64();
            Files = new List<FileEntry>();
            for(int i = 0; i < FileCount; i++)
            {
                FileEntry entry = new FileEntry
                                      {
                                          ID = IO.Reader.ReadInt64(),
                                          Offset = IO.Reader.ReadInt64(),
                                          Size = IO.Reader.ReadInt64(),
                                          Padding = IO.Reader.ReadInt64()
                                      };
                Files.Add(entry);
            }
            Hashes = new List<HashEntry>();
            for(int i = 0; i < FileCount; i++)
            {
                HashEntry entry = new HashEntry();
                entry.FileID = IO.Reader.ReadInt64();
                entry.HMACSHA1 = IO.Reader.ReadBytes(0x14);
                entry.Padding = IO.Reader.ReadInt32();
                Hashes.Add(entry);
                Files[(int) entry.FileID].Hash = entry;
            }
            HeaderHash = IO.Reader.ReadBytes(0x14);
            Padding = IO.Reader.ReadBytes(0xC);
        }
        public byte[] GetFileData(FileEntry entry)
        {
            IO.Stream.Position = entry.Offset;
            byte[] data = IO.Reader.ReadBytes((int)entry.Size); // BADBADBAD
            return data;
        }
    }
}
