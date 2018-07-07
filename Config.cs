using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.IO;

namespace MyDPFManager
{
    public class Config
    {
        public string LastProject = string.Empty;
        public string SelectPath = string.Empty;

        public static string ProjectPath
        {
            get
            {
                string path = System.Windows.Forms.Application.StartupPath;
                path += "\\Project";
                return path;
            }
        }

        public string ProjectFullFileName
        {
            get
            {
                string fileName = string.Format("{0}\\{1}.bin", ProjectPath, LastProject);
                return fileName;
            }
        }

        public static Config Load()
        {
            string path = System.Windows.Forms.Application.StartupPath;
            path += "\\config.xml";

            if (!File.Exists(path))
            {
                return new Config();
            }

            Config config = null;
            FileStream fs = null;
            try
            {
                XmlSerializer xs = new XmlSerializer(typeof(Config));
                fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                config = (Config)xs.Deserialize(fs);
                fs.Close();
            }
            catch
            {
                if (fs != null)
                    fs.Close();
                throw new Exception("Xml deserialization failed!");
            }

            return config;
        }

        public void Save()
        {
            string path = System.Windows.Forms.Application.StartupPath;
            path += "\\config.xml";

            FileStream fs = null;
            try
            {
                XmlSerializer xs = new XmlSerializer(typeof(Config));
                fs = new FileStream(path, FileMode.Create, FileAccess.Write);
                xs.Serialize(fs, this);
                fs.Close();
            }
            catch
            {
                if (fs != null)
                    fs.Close();
                throw new Exception("Xml serialization failed!");
            }
        }

    }

}
