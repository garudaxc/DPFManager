using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;

namespace MyDPFManager
{
    public class RemoveLableInfo
    {
        public int lable;
        public int removeAt;
        public object obj;

        public RemoveLableInfo(int l, int at, object o)
        {
            lable = l;
            removeAt = at;
            obj = o;
        }
    }

    [Serializable]
    class FileData
    {
        public string filePath;
        public string name;
        public string md5;
        public long size;
        
    }

    [Serializable]
    class FileDirectory
    {
        public string pathName;
        public string name;
        public int parent;
        public List<int> files = new List<int>();
    }

    [Serializable]
    class Lable
    {
        public string name;
        public int parent;
        public List<int> files = new List<int>();
    }

    [Serializable]
    class PDFFileModel //: ISerializable
    {
        public PDFFileModel()
        {
        }

        public List<FileData> Files
        {
            get
            {
                return m_Files;
            }
        }

        public List<FileDirectory> Directories
        {
            get
            {
                return m_Dir;
            }
        }

        public List<Lable> Lables
        {
            get
            {
                return m_Lables;
            }

            set 
            {
                m_Lables = value;
            }
        }

        public string Path
        {
            get
            {
                return m_Path;
            }

            set
            {
                m_Path = value;
            }
        }

        public bool SaveToFile(string pathName)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(pathName, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, this);
            stream.Flush();
            stream.Close();
            return true;
        }

        public static PDFFileModel LoadFromFile(string pathName)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            Stream destream = new FileStream(pathName, FileMode.Open, FileAccess.Read, FileShare.Read);
            PDFFileModel o = (PDFFileModel)formatter.Deserialize(destream);
            destream.Flush();
            destream.Close();
            return o;
        }

        private string m_Path = string.Empty;
        private List<FileData> m_Files = new List<FileData>();
        private List<FileDirectory> m_Dir = new List<FileDirectory>();
        private List<Lable> m_Lables = new List<Lable>();
    }
}
