using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDPFManager
{
    class Global
    {
        public static PDFFileModel Model
        {
            set;
            get;
        }

        public static PDFManagerController Controller
        {
            get
            {
                return m_Controller;
            }
        }

        public static Config Config
        {
            get
            {
                return m_Config;
            }
        }

        public static void Init()
        {
            m_Controller = new PDFManagerController();
            Model = new PDFFileModel();
            m_Config = Config.Load();
        }

        private static PDFManagerController m_Controller = null;
        private static Config m_Config = null;
    }
}
