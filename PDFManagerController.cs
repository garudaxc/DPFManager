using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace MyDPFManager
{
    delegate void ShowParseFileInfo(string info);

    class UpdateFileInfo
    {
        public int fileIndex;
        public bool matched = false;
    }

    class PDFManagerController
    {
        private List<string> metaOnlyFile_;

        public List<string> MetaOnlyFile
        {
            get
            {
                return metaOnlyFile_;
            }
        }
        
        private void ListFiles_r(PDFFileModel model, string pathName, int dirIndex)
        {
            if (Directory.Exists(pathName))
            {
                FileDirectory newDir = new FileDirectory();
                newDir.pathName = pathName;
                newDir.name = Path.GetFileName(pathName);

                newDir.parent = dirIndex;
                int index = model.Directories.Count;
                model.Directories.Add(newDir);

                //文件夹及子文件夹下的所有文件的全路径
                IEnumerable<string> files = Directory.EnumerateFileSystemEntries(pathName, "*.*", SearchOption.TopDirectoryOnly);
                foreach (string p in files)
                {
                    ListFiles_r(model, p, index);
                }
            }
            else if (File.Exists(pathName))
            {
                if (Path.GetExtension(pathName) == ".met")
                {
                    string name = pathName.Substring(0, pathName.Length - 4);
                    if (!File.Exists(name))
                    {
                        metaOnlyFile_.Add(pathName);
                    }
                    return;
                }
                FileData fileData = new FileData();
                fileData.filePath = pathName;
                fileData.name = Path.GetFileName(pathName); 

                int index = model.Files.Count;
                model.Files.Add(fileData);
                model.Directories[dirIndex].files.Add(index);
            }
        }

        private PDFFileModel ListFiles(string path)
        {
            metaOnlyFile_ = new List<string>();
            PDFFileModel model = new PDFFileModel();
            model.Path = path;

            FileDirectory dir = new FileDirectory();
            dir.pathName = path;
            dir.name = Path.GetFileName(path);
            dir.parent = -1;
            model.Directories.Add(dir);

            //文件夹及子文件夹下的所有文件的全路径
            IEnumerable<string> files = Directory.EnumerateFileSystemEntries(path, "*.*", SearchOption.TopDirectoryOnly);
            foreach (string pathName in files)
            {
                ListFiles_r(model, pathName, 0);
            }

            return model;
        }

        private void GetFileMeta(FileData f, MD5 md5)
        {
            string metaFile = f.filePath + ".met";
            while (File.Exists(metaFile))
            {
                FileStream fileStream = File.Open(metaFile, FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(fileStream);
                f.md5 = reader.ReadLine();
                f.size = int.Parse(reader.ReadLine());

                reader.Close();
                fileStream.Close();

                if (f.md5.Length != 32)
                {
                    break;
                }

                if (f.size <= 0)
                {
                    break;
                }

                return;
            }

            FileStream fs = File.Open(f.filePath, FileMode.Open, FileAccess.Read);
            f.size = fs.Length;
            byte[] code = md5.ComputeHash(fs);
            f.md5 = MD5ToString(code);
            fs.Close();

            fs = File.Open(metaFile, FileMode.Create, FileAccess.Write);
            StreamWriter writer = new StreamWriter(fs);
            writer.WriteLine(f.md5);
            writer.WriteLine(f.size);
            writer.Close();
            fs.Close();
        }

        private void CalcFileMD5(PDFFileModel model, ShowParseFileInfo ShowInfo)
        {
            int count = 0;
            for (int i = 0; i < model.Files.Count; i++ )
            {
                if (model.Files[i].md5 == null || model.Files[i].md5 == string.Empty)
                {
                    count++;
                }
            }

            int index = 0;
            MD5 md5 = MD5.Create();
            for (int i = 0; i < model.Files.Count; i++)
            {
                if (model.Files[i].md5 != null && model.Files[i].md5 != string.Empty)
                {
                    continue;
                }

                if (ShowInfo != null)
                {
                    string info = string.Format("共{0}个文件，正在计算第{1}个文件", count, index++);
                    ShowInfo(info);
                }

                GetFileMeta(model.Files[i], md5);
            }
        }

        public PDFFileModel BuildNewData(string path, ShowParseFileInfo ShowInfo)
        {
            if (!Directory.Exists(path))
            {
                return null;
            }

            PDFFileModel model = ListFiles(path);

            CalcFileMD5(model, ShowInfo);

            return model;
        }

        private string MD5ToString(byte[] md5)
        {
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data  
            // and format each one as a hexadecimal string. 
            for (int i = 0; i < md5.Length; i++)
            {
                sBuilder.Append(md5[i].ToString("x2"));
            }

            // Return the hexadecimal string. 
            return sBuilder.ToString();
        }

        private static bool CompareMD5(byte[] m0, byte[] m1)
        {
            if (m0.Length != m1.Length)
            {
                return false;
            }

            for (int i = 0; i < m0.Length; i++ )
            {
                if (m0[i] != m1[i])
                {
                    return false;
                }
            }

            return true;
        }

        public List<int> ScanIdentityFiles()
        {
            Dictionary<string, List<int>> set0 = new Dictionary<string, List<int>>();

            for (int i = 0; i < Global.Model.Files.Count; i++ )
            {
                FileData f = Global.Model.Files[i];
                List<int> l;
                if (set0.TryGetValue(f.md5, out l))
                {
                    l.Add(i);
                }
                else
                {
                    List<int> ll = new List<int>();
                    ll.Add(i);
                    set0.Add(f.md5, ll);
                }
            }

            List<int> list = new List<int>();
            foreach (KeyValuePair<string, List<int>> p in set0)
            {
                if (p.Value.Count > 1)
                {
                    list.AddRange(p.Value);
                }
            }

            return list;
        }

        private void LogInfo(ShowParseFileInfo ShowInfo, string text)
        {
            if (ShowInfo != null)
            {
                ShowInfo(text);
            }
        }

        public void DeleteFile(int fileIndex)
        {
            for (int i = 0; i < Global.Model.Directories.Count; i++)
            {
                FileDirectory dir = Global.Model.Directories[i];
                dir.files.Remove(fileIndex);
            }

            for (int i = 0; i < Global.Model.Lables.Count; i++ )
            {
                Lable l = Global.Model.Lables[i];
                l.files.Remove(fileIndex);
            }
        }

        private void RemapFiles(Dictionary<int, int> oldToNewIndex)
        {
            for (int i = 0; i < Global.Model.Lables.Count; i++)
            {
                Lable l = Global.Model.Lables[i];
                for (int j = 0; j < l.files.Count; j++ )
                {
                    l.files[j] = oldToNewIndex[l.files[j]];
                }
            }
        }


        // 更新数据
        // 文件的增加和删除
        public void UpdateData(ShowParseFileInfo ShowInfo)
        {
            LogInfo(ShowInfo, "list all files...");
            PDFFileModel newModel = ListFiles(Global.Model.Path);

            LogInfo(ShowInfo, "comparing...");
            Dictionary<string, UpdateFileInfo> oldFiles = new Dictionary<string, UpdateFileInfo>();
            for (int i = 0; i < Global.Model.Files.Count; i++ )
            {
                FileData f = Global.Model.Files[i];

                UpdateFileInfo info = new UpdateFileInfo();
                info.fileIndex = i;
                info.matched = false;
                oldFiles.Add(f.filePath, info);
            }

            // find deleted files and new files
            List<int> newFileIndex = new List<int>();
            Dictionary<int, int> oldToNewIndex = new Dictionary<int, int>();
            for (int i = 0; i < newModel.Files.Count; i++ )
            {
                FileData f = newModel.Files[i];
                UpdateFileInfo info;
                if (oldFiles.TryGetValue(f.filePath, out info))
                {
                    info.matched = true;
                    oldToNewIndex.Add(info.fileIndex, i);
                    f.md5 = Global.Model.Files[info.fileIndex].md5;
                    f.size = Global.Model.Files[info.fileIndex].size;
                }
                else
                {
                    newFileIndex.Add(i);
                }
            }

            LogInfo(ShowInfo, "delete files...");
            foreach (KeyValuePair<string, UpdateFileInfo> p in oldFiles)
            {
                if (!p.Value.matched)
                {
                    DeleteFile(p.Value.fileIndex);
                }
            }
            
            LogInfo(ShowInfo, "add new files...");
            CalcFileMD5(newModel, ShowInfo);

            LogInfo(ShowInfo, "remap lable...");
            RemapFiles(oldToNewIndex);

            LogInfo(ShowInfo, "ok!");

            newModel.Lables = Global.Model.Lables;
            Global.Model = newModel;

            string time = DateTime.Today.ToShortDateString() + " ";
            time += DateTime.Now.ToShortTimeString();
            time = time.Replace('/', '_').Replace(':', '_');
            string logFileName = Config.ProjectPath + "\\" + time + ".log";
            FileStream fs = new FileStream(logFileName, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            int count = 0;
            sw.WriteLine("delete files");
            foreach (KeyValuePair<string, UpdateFileInfo> p in oldFiles)
            {
                if (!p.Value.matched)
                {
                    sw.WriteLine(p.Key);
                    count++;
                }
            }
            sw.WriteLine("{0} files deleted", count);

            sw.WriteLine();
            sw.WriteLine("added files");
            for (int i = 0; i < newFileIndex.Count; i++ )
            {
                FileData f = newModel.Files[newFileIndex[i]];
                sw.WriteLine(f.filePath);
            }
            sw.WriteLine("{0} files added", newFileIndex.Count);

            sw.Close();
            fs.Close();
        }

        public void MergeDirctory(string from, string to, string MidDir, ShowParseFileInfo ShowInfo)
        {
            PDFFileModel model = null;
            if (to != null)
            {
                model = ListFiles(to);
                CalcFileMD5(model, ShowInfo);
            }
            else
            {
                model = Global.Model;
            }
            HashSet<string> set = new HashSet<string>();
            for (int i = 0; i < model.Files.Count; i++ )
            {
                set.Add(model.Files[i].md5);
            }

            model = ListFiles(from);
            CalcFileMD5(model, ShowInfo);
            List<int> toMerge = new List<int>();
            for (int i = 0; i < model.Files.Count; i++ )
            {
                if (!set.Contains(model.Files[i].md5))
                {
                    toMerge.Add(i);
                }
            }

            for (int i = 0; i < toMerge.Count; i++)
            {
                if (MidDir[MidDir.Length - 1] != '\\' && MidDir[MidDir.Length - 1] != '/')
                {
                    MidDir += '/';
                }
                string origFile = model.Files[toMerge[i]].filePath;
                string fileDestPath = MidDir + Path.GetFileName(origFile);
                File.Copy(origFile, fileDestPath);
                File.Copy(origFile + ".met", fileDestPath + ".met");
            }
        }

        //public void MD5Test()
        //{
        //    MD5 md5 = MD5.Create();

        //    FileStream file1 = File.Open("D:\\养生\\养生瑜伽-2.rmvb", FileMode.Open);
        //    FileStream file2 = File.Open("D:\\养生\\养生瑜伽-2 - 副本.rmvb", FileMode.Open);

        //    byte[] m1 = md5.ComputeHash(file1);
        //    byte[] m2 = md5.ComputeHash(file2);

        //    file1.Close();
        //    file2.Close();

        //    string s = string.Format("{0} {1}", m1.Length, m2.Length);
        //    Console.WriteLine(s);
        //    Console.WriteLine(MD5ToString(m1));
        //    Console.WriteLine(MD5ToString(m2));
        //}

 
    }
}
