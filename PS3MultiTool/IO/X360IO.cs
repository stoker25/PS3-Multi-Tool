using System.IO;

namespace PS3MultiTool.IO
{
    /// <summary>
    ///   X360IO v2.2 by stoker25
    ///   http://stoker25.com/
    /// </summary>

    public class X360IO
    {
        /// <summary>
        ///   The X360Reader instance.
        /// </summary>
        public X360Reader Reader;

        /// <summary>
        ///   The X360Writer instance.
        /// </summary>
        public X360Writer Writer;

        /// <summary>
        ///   The file name of the loaded file.
        /// </summary>
        public string FilePath;

        /// <summary>
        ///   The stream to use.
        /// </summary>
        public Stream Stream;

        /// <summary>
        ///   Determines if it should read values in Big Endian format.
        /// </summary>
        public bool BigEndian;
        public long Length
        {
            get
            {
                return Stream.Length;
            }
        }
        /// <summary>
        ///   Initializes a new instance of the X360IO.BaseIO class with the specified path, creation mode and big endian mode.
        /// </summary>
        /// <param name = "filePath">A relative or absolute path for the file that the current X360IO.BaseIO object will encapsulate.</param>
        /// <param name = "fileMode">A System.IO.FileMode constant that determines how to open or create the file.</param>
        /// <param name = "bigEndian">A boolean specifying the endian type to use.</param>
        public X360IO(string filePath, FileMode fileMode, bool bigEndian)
        {
            Stream = new FileStream(filePath, fileMode);
            FilePath = filePath;
            BigEndian = bigEndian;
            Open();
        }
        /// <summary>
        ///   Initializes a new instance of the X360IO.BaseIO class with the specified stream and big endian mode.
        /// </summary>
        /// <param name = "stream">A stream.</param>
        /// <param name = "bigEndian">A boolean specifying the endian type to use.</param>
        public X360IO(Stream stream, bool bigEndian)
        {
            Stream = stream;
            BigEndian = bigEndian;
            Open();
        }

        /// <summary>
        ///   Initializes a new instance of the X360IO.BaseIO class with the specified path and creation mode.
        /// </summary>
        /// <param name = "filePath">A relative or absolute path for the file that the current X360IO.BaseIO object will encapsulate.</param>
        /// <param name = "fileMode">A System.IO.FileMode constant that determines how to open or create the file.</param>
        public X360IO(string filePath, FileMode fileMode)
        {
            FilePath = filePath;
            Stream = new FileStream(filePath, fileMode);
            Open();
        }

        /// <summary>
        ///   Initializes a new instance of the X360IO.BaseIO class with the specified stream.
        /// </summary>
        /// <param name = "stream">A stream.</param>
        public X360IO(Stream stream)
        {
            Stream = stream;
            Open();
        }

        public X360IO(byte[] data)
        {
            Stream = new MemoryStream(data);
            Open();
        }
        public X360IO(byte[] data, bool bigEndian)
        {
            Stream = new MemoryStream(data);
            BigEndian = bigEndian;
            Open();
        }

        /// <summary>
        ///   Initalizes the X360Reader and X360Writer.
        /// </summary>
        public void Open()
        {
            Reader = new X360Reader(this);
            Writer = new X360Writer(this);
        }

        /// <summary>
        ///   Closes the stream and associated X360Reader/X360Writer.
        /// </summary>
        public void Close()
        {
            try
            {
                Stream.Close();
                Stream = null;

            }
            catch
            {
            }
        }
    }
}
