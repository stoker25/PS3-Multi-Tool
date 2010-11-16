using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using PS3MultiTool.IO;

namespace PS3MultiTool
{
    public class PackageDataBase
    {
        public class DataBaseEntry
        {
            public EntryID ID;
            public uint Size;
            public uint Size2;
            public byte[] Data;
            public long Offset;
            public string DataString
            {
                get
                {
                    if (Data != null)
                        return Program.BytesToHexString((byte[])Data);
                    return String.Empty;
                }
            }
            public bool Load(X360IO io)
            {
                Offset = io.Stream.Position;
                ID = (EntryID)io.Reader.ReadUInt32();
                Size = io.Reader.ReadUInt32();
                Size2 = io.Reader.ReadUInt32();
                Data = io.Reader.ReadBytes((int)Size); // BADBADBAD
                return true;
            }

            public bool Save(X360IO io)
            {

                Offset = io.Stream.Position;
                Size = (uint)Data.Length;
                Size2 = Size;
                io.Writer.Write((uint)ID);
                io.Writer.Write(Size);
                io.Writer.Write(Size2);
                io.Writer.Write(Data);
                return true;
            }
        }
        public enum EntryID : uint
        {
            PackageName = 0x69,
            IconPath = 0x6A,
            ServerURL = 0xCA,
            PackageFileName = 0xCB,
            PackageCreation = 0xCC,
            PackageFileSize = 0xCE,
            DownloadedSize = 0xD0,
            ContentID = 0xD9,
            DownloadComplete = 0xDA,

        }
        public X360IO IO;
        public uint Magic = 0x0;
        public List<DataBaseEntry> Entries;
        public void Load(string fileName)
        {
            Load(new X360IO(fileName, FileMode.Open, true));
        }
        public void Load(X360IO io)
        {
            IO = io;
            IO.Stream.Position = 0x0;
            Magic = IO.Reader.ReadUInt32();
            Entries = new List<DataBaseEntry>();
            while (IO.Stream.Position < IO.Stream.Length)
            {
                DataBaseEntry entry = new DataBaseEntry();
                entry.Load(IO);
                Entries.Add(entry);
            }
        }

        public void Save()
        {
            IO.Stream.Position = 0x0;
            IO.Writer.Write(new byte[IO.Stream.Length]);
            IO.Stream.Position = 0x0;
            IO.Writer.Write(Magic);
            foreach (DataBaseEntry entry in Entries)
                entry.Save(IO);
            IO.Stream.Flush();
        }

        public void LoadInitialValues()
        {
            Entries.Add(new DataBaseEntry() { ID = (EntryID)0x64, Size = 4, Size2 = 4, Data = new byte[4] });
            Entries.Add(new DataBaseEntry() { ID = (EntryID)0x65, Size = 4, Size2 = 4, Data = new byte[4] });
            Entries.Add(new DataBaseEntry() { ID = (EntryID)0x66, Size = 1, Size2 = 1, Data = new byte[1] });
            Entries.Add(new DataBaseEntry() { ID = (EntryID)0x6B, Size = 4, Size2 = 4, Data = new byte[4] }); // last byte is 3
            Entries.Add(new DataBaseEntry() { ID = (EntryID)0x68, Size = 4, Size2 = 4, Data = new byte[4] }); // looks like an error code in d1.pdb (80023E13)
            Entries.Add(new DataBaseEntry() { ID = (EntryID)0x6C, Size = 4, Size2 = 4, Data = new byte[4] });
            Entries.Add(new DataBaseEntry() { ID = EntryID.DownloadedSize, Size = 8, Size2 = 8, Data = new byte[8] });
            Entries.Add(new DataBaseEntry() { ID = EntryID.PackageFileSize, Size = 8, Size2 = 8, Data = new byte[8] });
            Entries.Add(new DataBaseEntry() { ID = EntryID.PackageCreation, Size = 30, Size2 = 30, Data = new byte[30] });
            Entries.Add(new DataBaseEntry() { ID = EntryID.IconPath, Size = 38, Size2 = 38, Data = new byte[38] });
            Entries.Add(new DataBaseEntry() { ID = EntryID.PackageName, Size = 24, Size2 = 24, Data = new byte[24] });
            Entries.Add(new DataBaseEntry() { ID = EntryID.ServerURL, Size = 185, Size2 = 185, Data = new byte[185] });
            Entries.Add(new DataBaseEntry() { ID = EntryID.PackageFileName, Size = 106, Size2 = 106, Data = new byte[106] });
            Entries.Add(new DataBaseEntry() { ID = EntryID.ContentID, Size = 37, Size2 = 37, Data = new byte[37]});
            Entries.Add(new DataBaseEntry() { ID = EntryID.DownloadComplete, Size = 1, Size2 = 1, Data = new byte[1] });
            Entries.Add(new DataBaseEntry() { ID = (EntryID)0xCD, Size = 1, Size2 = 1, Data = new byte[1] });
            Entries.Add(new DataBaseEntry() { ID = (EntryID)0xD2, Size = 1, Size2 = 1, Data = new byte[1] });
        }
    }
}
