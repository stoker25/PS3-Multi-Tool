using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace PS3MultiTool
{
    static class Program
    {
        /// <summary>
        /// PS3 Multi Tool
        /// by stoker25
        /// ------------
        /// CHANGELOG
        /// ------------
        /// v0.25:
        /// + PDB (Package DataBase) Editor
        /// * Add new PDB entries
        /// * Create new PDB?
        /// v0.2:
        /// + SCE header loading
        /// + UnFSELF (for decrypted SELFs only)
        /// * SELF decryption
        /// * Update PKG decryption
        /// * Reorganise SCEEditor form
        ///
        /// v0.15:
        /// + Implemented xRegistry.sys Editor
        /// * new setting feature
        /// * change setting type
        ///
        /// v0.1:
        /// + PUP loading
        /// + PUP extraction
        /// 
        /// ------------
        /// TODO
        /// ------------
        /// * Registry - new setting feature
        /// * Registry - change setting type
        /// * Registry - create new registry
        /// * PUPFile - PUP creation (NEED HMAC :/)
        /// * SCE - SELF decryption
        /// * SCE - Update PKG decryption
        /// * SCE - Reorganise SCEEditor form
        /// * PDB - Add new entries
        /// * PDB - Create new PDB
        /// * SFD system file editor
        /// ------------
        /// BAD CODE (fix before 0.5)
        /// ------------
        /// * SCEHeader.cs -> UnFSELF()
        /// * PlaystationUpdatePackage.cs -> GetFileData(FileEntry entry)
        /// * PackageDataBase.cs -> DataBaseEntry.Load(X360IO io) 
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }
        public static string BytesToHexString(IEnumerable<byte> bytes)
        {
            return bytes.Aggregate("", (current, data) => current + data.ToString("X2"));
        }
        public static byte[] HexStringToBytes(string hexString)
        {
            if (hexString.Length % 2 > 0)
                throw new Exception("Not a hex string.");
            byte[] bytes = new byte[hexString.Length / 2];
            for(int i = 0; i < hexString.Length / 2; i++)
            {
                string str = hexString.Substring(i*2, 2);
                bytes[i] = byte.Parse(str, NumberStyles.HexNumber);
            }
            return bytes;
        }
    }
}
