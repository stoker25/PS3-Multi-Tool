using System;
using System.IO;
using System.Drawing;
using System.Security.Cryptography;

namespace PS3MultiTool.IO
{
    /// <summary>
    ///   The Reader class.
    /// </summary>
    public class X360Reader : BinaryReader
    {
        internal X360IO xIO;

        /// <summary>
        ///   Determines if it should read values in Big Endian format.
        /// </summary>
        public bool BigEndian
        {
            get { return xIO.BigEndian; }
            set { xIO.BigEndian = value; }
        }

        /// <summary>
        ///   Initializes a new instance of the X360Reader class with the specified X360IO.BaseIO instance.
        /// </summary>
        internal X360Reader(X360IO io)
            : base(io.Stream)
        {
            xIO = io;
        }

        /// <summary>
        ///   Reads an ASCII string from the parent stream.
        /// </summary>
        /// <param name = "length">The length of the string to read.</param>
        /// <returns>An ASCII encoded string.</returns>
        public string ReadAsciiString(int length)
        {
            string str = "";
            int num = 0;
            for (int i = 0; i < length; i++)
            {
                char ch = ReadChar();
                num++;
                if (ch == '\0')
                {
                    break;
                }
                str = str + ch;
            }
            int num3 = length - num;
            BaseStream.Seek(num3, SeekOrigin.Current);
            return str;
        }

        /// <summary>
        ///   Reads a double precision float from the parent stream.
        /// </summary>
        /// <returns>A double precision float.</returns>
        public override double ReadDouble()
        {
            byte[] array = base.ReadBytes(4);
            if (BigEndian)
            {
                Array.Reverse(array);
            }
            return BitConverter.ToDouble(array, 0);
        }
        /// <summary>
        ///   Reads a 16-bit integer from the parent stream.
        /// </summary>
        /// <returns>A 16-bit integer.</returns>
        public override short ReadInt16()
        {
            byte[] array = base.ReadBytes(2);
            if (BigEndian)
            {
                Array.Reverse(array);
            }
            return BitConverter.ToInt16(array, 0);
        }
        public byte[] GenerateSHA1Hash(int length)
        {
            return new SHA1CryptoServiceProvider().ComputeHash(ReadBytes(length));
        }
        /// <summary>
        ///   Reads a 24-bit integer from the parent stream.
        /// </summary>
        /// <returns>A 24-bit integer.</returns>
        public int ReadInt24()
        {
            byte[] sourceArray = base.ReadBytes(3);
            byte[] destinationArray = new byte[4];
            Array.Copy(sourceArray, 0, destinationArray, 0, 3);
            if (BigEndian)
            {
                Array.Reverse(destinationArray);
            }
            return BitConverter.ToInt32(destinationArray, 0);
        }

        /// <summary>
        ///   Reads a 32-bit integer from the parent stream.
        /// </summary>
        /// <returns>A 32-bit integer</returns>
        public override int ReadInt32()
        {
            byte[] array = base.ReadBytes(4);
            if (BigEndian)
            {
                Array.Reverse(array);
            }
            return BitConverter.ToInt32(array, 0);
        }

        /// <summary>
        ///   Reads a 64-bit integer from the parent stream.
        /// </summary>
        /// <returns>A 64-bit integer.</returns>
        public override long ReadInt64()
        {
            byte[] array = base.ReadBytes(8);
            if (BigEndian)
            {
                Array.Reverse(array);
            }
            return BitConverter.ToInt64(array, 0);
        }

        /// <summary>
        ///   Reads an ASCII encoded string from the parent stream, terminated with a null byte.
        /// </summary>
        /// <returns>An ASCII encoded string.</returns>
        public string ReadNullTerminatedAsciiString()
        {
            string newString = string.Empty;
            while (true)
            {
                byte tempChar = ReadByte();
                if (tempChar != 0)
                    newString += (char)tempChar;
                else
                    break;
            }
            return newString;
        }

        /// <summary>
        ///   Reads a Unicode encoded string from the parent stream, terminated with a null byte.
        /// </summary>
        /// <returns>A Unicode encoded string.</returns>
        public string ReadNullTerminatedUnicodeString()
        {
            string newString = string.Empty;
            while (true)
            {
                ushort tempChar = ReadUInt16();
                if (tempChar != 0)
                    newString += (char)tempChar;
                else
                    break;
            }
            return newString;
        }

        /// <summary>
        ///   Reads a single precision float from the parent stream.
        /// </summary>
        /// <returns>A single precision float</returns>
        public override float ReadSingle()
        {
            byte[] array = base.ReadBytes(4);
            if (BigEndian)
            {
                Array.Reverse(array);
            }
            return BitConverter.ToSingle(array, 0);
        }

        /// <summary>
        ///   Reads an ASCII encoded string of the provided length from the parent stream.
        /// </summary>
        /// <param name = "length">The length of the string to read.</param>
        /// <returns>An ASCII encoded string.</returns>
        public string ReadString(int length)
        {
            return ReadAsciiString(length);
        }

        /// <summary>
        ///   Reads an unsigned 16-bit integer from the parent stream
        /// </summary>
        /// <returns>An unsigned 16-bit integer</returns>
        public override ushort ReadUInt16()
        {
            byte[] array = base.ReadBytes(2);
            if (BigEndian)
            {
                Array.Reverse(array);
            }
            return BitConverter.ToUInt16(array, 0);
        }

        /// <summary>
        ///   Reads an unsigned 32-bit integer from the parent stream
        /// </summary>
        /// <returns>An unsigned 32-bit integer</returns>
        public override uint ReadUInt32()
        {
            byte[] array = base.ReadBytes(4);
            if (BigEndian)
            {
                Array.Reverse(array);
            }
            return BitConverter.ToUInt32(array, 0);
        }

        /// <summary>
        ///   Reads an unsigned 64-bit integer from the parent stream
        /// </summary>
        /// <returns>An unsigned 64-bit integer</returns>
        public override ulong ReadUInt64()
        {
            byte[] array = base.ReadBytes(8);
            if (BigEndian)
            {
                Array.Reverse(array);
            }
            return BitConverter.ToUInt64(array, 0);
        }

        /// <summary>
        ///   Reads a Unicode encoded string of the provided length from the parent stream.
        /// </summary>
        /// <param name = "length">The length of the string to read.</param>
        /// <returns>An Unicode encoded string.</returns>
        public string ReadUnicodeString(int length)
        {
            string str = "";
            int num = 0;
            for (int i = 0; i < length; i++)
            {
                char ch = (char)ReadUInt16();
                num++;
                if (ch == '\0')
                {
                    break;
                }
                str = str + ch;
            }
            int num3 = (length - num) * 2;
            BaseStream.Seek(num3, SeekOrigin.Current);
            return str;
        }

        /// <summary>
        ///   Moves the streams position to the specified offset.
        /// </summary>
        /// <param name = "offset">The offset to move to.</param>
        public void SeekTo(int offset)
        {
            SeekTo(offset, SeekOrigin.Begin);
        }

        /// <summary>
        ///   Moves the streams position to the specified offset.
        /// </summary>
        /// <param name = "xOffset">The offset to move to.</param>
        public void SeekTo(long xOffset)
        {
            SeekTo((int)xOffset, SeekOrigin.Begin);
        }

        /// <summary>
        ///   Reads a null terminated ASCII encoded string from the parent stream.
        /// </summary>
        /// <returns>An ASCII encoded string</returns>
        public override string ReadString()
        {
            return ReadNullTerminatedAsciiString();
        }

        /// <summary>
        ///   Moves the streams position to the specified offset.
        /// </summary>
        /// <param name = "offset">The offset to move to.</param>
        public void SeekTo(uint offset)
        {
            SeekTo((int)offset, SeekOrigin.Begin);
        }

        /// <summary>
        ///   Moves the streams position to the specified offset.
        /// </summary>
        /// <param name = "offset">The offset to move to.</param>
        /// <param name = "seekOrigin">The SeekOrigin to use.</param>
        public void SeekTo(int offset, SeekOrigin seekOrigin)
        {
            BaseStream.Seek(offset, seekOrigin);
        }

        /// <summary>
        ///   Attempts to read an Image from the parent stream.
        /// </summary>
        /// <param name = "length">The size of the Image.</param>
        /// <returns>An Image</returns>
        public Image TryParseImage(int length)
        {
            MemoryStream stream = new MemoryStream(base.ReadBytes(length));
            Image img = null;
            try
            {
                img = Image.FromStream(stream);
            }
            catch
            {
            }
            stream.Dispose();
            return img;
        }
    }
}
