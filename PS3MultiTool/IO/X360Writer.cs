using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace PS3MultiTool.IO
{
    /// <summary>
    ///   The Writer class.
    /// </summary>
    public class X360Writer : BinaryWriter
    {
        private bool _bigEndian;

        internal X360IO xIO;

        /// <summary>
        ///   Determines if it should read values in Big Endian format.
        /// </summary>
        public bool BigEndian
        {
            get { return xIO != null ? xIO.BigEndian : _bigEndian; }
            set
            {
                if (xIO != null) { xIO.BigEndian = value; }
                else
                {
                    _bigEndian = value;
                }
            }
        }

        /// <summary>
        ///   Initializes a new instance of the X360Writer class with the specified X360IO.BaseIO instance.
        /// </summary>
        /// <param name = "xIO">The X360IO.BaseIO instance to use.</param>
        internal X360Writer(X360IO xIO)
            : base(xIO.Stream)
        {
            this.xIO = xIO;
        }

        public X360Writer(Stream stream)
            : base(stream)
        {

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
        /// <param name = "offset">The offset to move to.</param>
        public void SeekTo(long offset)
        {
            SeekTo((int)offset, SeekOrigin.Begin);
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
        ///   Writes the specified string to the parent stream, in the ASCII format.
        /// </summary>
        /// <param name = "value">The string to write.</param>
        public override void Write(string value)
        {
            int length = value.Length;
            for (int i = 0; i < length; i++)
            {
                byte num3 = (byte)value[i];
                Write(num3);
            }
        }

        /// <summary>
        ///   Writes the specified double precision float to the parent stream.
        /// </summary>
        /// <param name = "value">The double precision float to write.</param>
        public override void Write(double value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            if (BigEndian)
            {
                Array.Reverse(bytes);
            }
            base.Write(bytes);
        }

        /// <summary>
        ///   Writes the specified 16-bit integer to the parent stream.
        /// </summary>
        /// <param name = "value">The 16-bit integer to write.</param>
        public override void Write(short value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            if (BigEndian)
            {
                Array.Reverse(bytes);
            }
            base.Write(bytes);
        }

        /// <summary>
        ///   Writes the specified 32-bit integer to the parent stream.
        /// </summary>
        /// <param name = "value">The 32-bit integer to write.</param>
        public override void Write(int value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            if (BigEndian)
            {
                Array.Reverse(bytes);
            }
            base.Write(bytes);
        }

        public void WriteInt24(int value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            byte num = bytes[0];
            byte num2 = bytes[1];
            byte num3 = bytes[2];
            byte[] array = new[] { num, num2, num3 };
            if (BigEndian)
            {
                Array.Reverse(array);
            }
            Write(array);
        }

        /// <summary>
        ///   Writes the specified 64-bit integer to the parent stream.
        /// </summary>
        /// <param name = "value">The 64-bit integer to write.</param>
        public override void Write(long value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            if (BigEndian)
            {
                Array.Reverse(bytes);
            }
            base.Write(bytes);
        }

        /// <summary>
        ///   Writes the specified single precision float to the parent stream.
        /// </summary>
        /// <param name = "value">The single precision float to write.</param>
        public override void Write(float value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            if (BigEndian)
            {
                Array.Reverse(bytes);
            }
            base.Write(bytes);
        }

        /// <summary>
        ///   Writes the specified unsigned 16-bit integer to the parent stream.
        /// </summary>
        /// <param name = "value">The unsigned 16-bit integer to write.</param>
        public override void Write(ushort value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            if (BigEndian)
            {
                Array.Reverse(bytes);
            }
            base.Write(bytes);
        }

        /// <summary>
        ///   Writes the specified unsigned 32-bit integer to the parent stream.
        /// </summary>
        /// <param name = "value">The unsigned 32-bit integer to write.</param>
        public override void Write(uint value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            if (BigEndian)
            {
                Array.Reverse(bytes);
            }
            base.Write(bytes);
        }

        /// <summary>
        ///   Writes the specified unsigned 64-bit integer to the parent stream.
        /// </summary>
        /// <param name = "value">The unsigned 64-bit integer to write.</param>
        public override void Write(ulong value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            if (BigEndian)
            {
                Array.Reverse(bytes);
            }
            base.Write(bytes);
        }

        /// <summary>
        ///   Writes the specified Image to the parent stream.
        /// </summary>
        /// <param name = "value">The Image to write.</param>
        /// <param name = "imageFormat">The ImageFormat to use.</param>
        public void Write(Image value, ImageFormat imageFormat)
        {
            MemoryStream ms = new MemoryStream();
            value.Save(ms, imageFormat);
            byte[] bytes = ms.ToArray();
            ms.Dispose();
            base.Write(bytes);
        }

        /// <summary>
        ///   Writes the specified string to the parent stream in ASCII format, up to the specified length.
        /// </summary>
        /// <param name = "value">The string to write.</param>
        /// <param name = "length">The length to write.</param>
        public void WriteAsciiString(string value, int length)
        {
            int length1 = value.Length;
            for (int i = 0; i < length1; i++)
            {
                if (i > length)
                {
                    break;
                }
                byte num3 = (byte)value[i];
                Write(num3);
            }
            int num4 = length - length1;
            if (num4 > 0)
            {
                Write(new byte[num4]);
            }
        }

        /// <summary>
        ///   Writes the specified string to the parent stream in Unicode format, terminated with two null bytes.
        /// </summary>
        /// <param name = "value">The string to write.</param>
        public void WriteNullTerminatedUnicodeString(string value)
        {
            int strLen = value.Length;
            for (int x = 0; x < strLen; x++)
            {
                ushort val = value[x];
                Write(val);
            }
            Write((ushort)0);
        }

        /// <summary>
        ///   Writes the specified string to the parent stream in ASCII format, terminated with a null byte.
        /// </summary>
        /// <param name = "value">The string to write.</param>
        public void WriteNullTerminatedAsciiString(string value)
        {
            Write(value.ToCharArray());
            Write((byte)0);
        }

        /// <summary>
        ///   Writes the specified string to the parent stream in Unicode format, up to the specified length.
        /// </summary>
        /// <param name = "value">The string to write.</param>
        /// <param name = "length">The length to write.</param>
        public void WriteUnicodeString(string value, int length)
        {
            int length1 = value.Length;
            for (int i = 0; i < length1; i++)
            {
                if (i > length)
                {
                    break;
                }
                ushort num3 = value[i];
                Write(num3);
            }
            int num4 = (length - length1) * 2;
            if (num4 > 0)
            {
                Write(new byte[num4]);
            }
        }
    }
}
