using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PS3MultiTool.IO;

namespace PS3MultiTool
{
    public class PS3Registry
    {
        public class SettingEntry
        {
            public uint ID;
            public byte Value;
            public string Setting;
            public long Offset;
            public long EndOffset;
            public bool DataExists;

            public bool Load(X360IO io)
            {
                Offset = io.Stream.Position;
                ID = io.Reader.ReadUInt32();
                Value = io.Reader.ReadByte();
                if (Value == 0xEE) // 0xAABBCCDDEE
                    return false;
                Setting = io.Reader.ReadNullTerminatedAsciiString();
                EndOffset = io.Stream.Position;
                return true;
            }

            public override string ToString()
            {
                return Setting;
            }

            public bool IsEntryOffset(long offset)
            {
                return Offset <= offset && EndOffset > offset;
            }

            public void Save(X360IO io)
            {
                io.Stream.Position = Offset;
                io.Writer.Write(ID);
                io.Writer.Write(Value);
                io.Writer.WriteNullTerminatedAsciiString(Setting);
            }
        }

        public class SettingDataEntry
        {
            public ushort Checksum;
            public ushort Length;
            public ushort Flags;
            public byte Type; // 1 = integer, 2 = string
            public byte[] Value;
            public byte Terminator;
            public long Offset;
            public ushort FileNameOffset;
            public SettingEntry FileNameEntry;

            public string ValueString
            {
                get
                {
                    switch (Type)
                    {
                        case 0:
                        case 1:
                            return Program.BytesToHexString(Value);
                        case 2:
                            return Encoding.ASCII.GetString(Value).Trim('\0');
                        default:
                            return String.Empty;
                    }
                }
                set
                {
                    switch (Type)
                    {
                        case 0:
                        case 1:
                            Value = Program.HexStringToBytes(value);
                            break;
                        case 2:
                            Value = Encoding.ASCII.GetBytes(value);
                            break;
                        default:
                            break;
                    }
                }
            }

            public bool Load(X360IO io)
            {
                Offset = io.Stream.Position;
                Flags = io.Reader.ReadUInt16();
                FileNameOffset = io.Reader.ReadUInt16();
                Checksum = io.Reader.ReadUInt16();
                Length = io.Reader.ReadUInt16();
                Type = io.Reader.ReadByte();
                Value = io.Reader.ReadBytes(Length);
                io.Stream.Position = Offset + 9 + Length;
                Terminator = io.Reader.ReadByte();
                return true;
            }

            public bool Save(X360IO io)
            {
                Offset = io.Stream.Position;
                Length = (ushort)Value.Length;
                if (FileNameEntry != null)
                    FileNameOffset = (ushort)(FileNameEntry.Offset - 0x10);
                io.Writer.Write(Flags);
                io.Writer.Write(FileNameOffset);
                io.Writer.Write(Checksum);
                io.Writer.Write(Length);
                io.Writer.Write(Type);
                io.Writer.Write(Value);
                io.Stream.Position = Offset + 9 + Length;
                io.Writer.Write(Terminator);
                return true;
            }
        }

        public X360IO IO;
        public uint Magic = 0xBCADADBC;
        public uint Unknown1 = 0x90;
        public uint Unknown2 = 0x02;
        public uint Magic2 = 0xBCADADBC;
        public ushort DataMagic = 0x4D26;
        public List<SettingEntry> SettingEntries;
        public List<SettingDataEntry> DataEntries;
        

        public SettingDataEntry CreateSetting(string settingName, byte settingType, string settingValue)
        {
            SettingEntry entry = new SettingEntry {ID = 0x0, Value = 0x0, Setting = settingName};
            SettingDataEntry entry2 = new SettingDataEntry
                                          {
                                              Flags = 0x0,
                                              Checksum = 0x0,
                                              Type = settingType,
                                              FileNameEntry = entry
                                          };
            entry2.ValueString = settingValue;
            entry.DataExists = true;
            SettingEntries.Add(entry);
            DataEntries.Add(entry2);
            return entry2;
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
            Unknown1 = IO.Reader.ReadUInt32();
            Unknown2 = IO.Reader.ReadUInt32();
            Magic2 = IO.Reader.ReadUInt32();
            if (Magic != 0xBCADADBC || Magic2 != 0xBCADADBC)
                return;
            IO.Stream.Position = 0x10;
            SettingEntries = new List<SettingEntry>();
            DataEntries = new List<SettingDataEntry>();
            while (true)
            {
                SettingEntry entry = new SettingEntry();
                if (!entry.Load(IO))
                    break;
                SettingEntries.Add(entry);
            }
            IO.Stream.Position = 0xFFF0;
            DataMagic = IO.Reader.ReadUInt16();
            if (DataMagic != 0x4D26)
                return;

            // data
            while (true)
            {
                SettingDataEntry entry = new SettingDataEntry();
                entry.Load(IO);
                if (!(entry.Flags == 0xAABB && entry.FileNameOffset == 0xCCDD && entry.Checksum == 0xEE00))
                    DataEntries.Add(entry);
                else
                    break;
            }

            foreach (SettingDataEntry entry in DataEntries)
            {
                if (entry.Flags != 0x7A)
                {
                    SettingEntry ent = SettingEntries.Find(sec => sec.IsEntryOffset(entry.FileNameOffset + 0x10));
                    if (ent == null)
                    {
                        break;
                    }
                    ent.DataExists = true;
                    entry.FileNameEntry = ent;
                }
            }
        }
        public void Save()
        {
            IO.Stream.Position = 0x0;
            IO.Writer.Write(new byte[IO.Stream.Length]);
            IO.Stream.Position = 0x0;
            IO.Writer.Write(Magic);
            IO.Writer.Write(Unknown1);
            IO.Writer.Write(Unknown2);
            IO.Writer.Write(Magic2);
            foreach(SettingEntry entry in SettingEntries)
            {
                entry.Save(IO);
            }
            IO.Stream.Position = 0xFFF0;
            IO.Writer.Write(DataMagic);
            foreach (SettingDataEntry entry in DataEntries)
            {
                entry.Save(IO);
            }
            IO.Writer.Write((byte)0xAA);
            IO.Writer.Write((byte)0xBB);
            IO.Writer.Write((byte)0xCC);
            IO.Writer.Write((byte)0xDD);
            IO.Writer.Write((byte)0xEE);
            IO.Stream.Flush();
        }

    }
}
