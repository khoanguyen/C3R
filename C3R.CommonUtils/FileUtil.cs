using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C3R.CommonUtils
{
    public static class FileUtil
    {
        /// <summary>
        /// Reads all text from file path
        /// </summary>
        /// <param name="path">File path</param>
        /// <returns></returns>
        public static string ReadTextAll(string path)
        {
            using (var reader = File.OpenText(path))
            {
                return reader.ReadToEnd();
            }
        }

        /// <summary>
        /// Reads binary data from file
        /// </summary>
        /// <param name="path">File path</param>
        /// <returns></returns>
        public static byte[] ReadBinAll(string path)
        {
            byte[] result = null;
            using (var reader = new BinaryReader(File.OpenRead(path)))
            {
                long length = reader.BaseStream.Length;
                result = new byte[length];
                byte[] buf = null;
                long readCount = 0;
                int bufCount = 65536 > length ? (int)length : 65536; // 64K
                while (readCount < length)
                {
                    buf = reader.ReadBytes(bufCount);
                    Array.Copy(buf, 0, result, readCount, bufCount);
                    readCount += bufCount;
                    bufCount = Math.Min(65536, (int)(length - readCount));
                }
            }

            return result;
        }

        /// <summary>
        /// Saves text to file. Existing file will be overwritten
        /// </summary>
        /// <param name="path">File path</param>
        /// <param name="text">Text to be saved</param>
        public static void SaveText(string path, string text)
        {
            using (var writer = new StreamWriter(File.Open(path, FileMode.Create)))
            {
                writer.Write(text);
                writer.Flush();
                writer.Close();
            }
        }

        /// <summary>
        /// Appends text to file
        /// </summary>
        /// <param name="path">File path</param>
        /// <param name="text">Text to be appended</param>
        public static void AppendText(string path, string text)
        {
            using (var writer = new StreamWriter(File.Open(path, FileMode.Append)))
            {
                writer.Write(text);
                writer.Flush();
                writer.Close();
            }
        }

        /// <summary>
        /// Saves binary data to file. Existing file will be overwritten
        /// </summary>
        /// <param name="path">File path</param>       
        /// <param name="bin">Binary data to be saved</param>
        public static void SaveBin(string path, byte[] bin)
        {
            using (var writer = new BinaryWriter(File.Open(path, FileMode.Create)))
            {
                writer.Write(bin);
                writer.Flush();
                writer.Close();
            }
        }

        /// <summary>
        /// Appends binary data to file. Existing file will be overwritten
        /// </summary>
        /// <param name="path">File path</param>       
        /// <param name="bin">Binary data to be appended</param>
        public static void AppendBin(string path, byte[] bin)
        {
            using (var writer = new BinaryWriter(File.Open(path, FileMode.Append)))
            {
                writer.Write(bin);
                writer.Flush();
                writer.Close();
            }
        }

        /// <summary>
        /// Deletes File
        /// </summary>
        /// <param name="path">file path</param>
        public static void Delete(string path)
        {
            File.Delete(path);
        }
    }
}
