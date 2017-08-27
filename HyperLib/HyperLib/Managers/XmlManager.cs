using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace HyperLib.Managers
{
    public class XmlManager
    {
        private XmlDocument doc;
        private string file;

        public XmlManager()
        {

        }

        public XmlManager(string File)
        {
            file = File;
        }

        public void SetFile(string File) { file = File; }
        public string GetFile() { return file; }

        public string ReadNode(string NodeName)
        {
            XmlNode node = doc.SelectSingleNode(NodeName);
            return node.InnerText;
        }

        public void WriteNode(string NodeName, string Content)
        {
            XmlNode node = doc.SelectSingleNode(NodeName);
            node.InnerText = Content;
            doc.Save(file);
        }

        public string Serialize(Type type, object obj)
        {
            string tmpDir = Path.GetTempPath() + "\\HyperLib\\Managers\\XmlManager\\Serialize\\";
            string tmpFile = "tmp_"+DateTime.Now.Year + "~" + DateTime.Now.Hour + "~" + DateTime.Now.Minute + "~" + DateTime.Now.Second + "~" + DateTime.Now.Millisecond + ".xml";
            Directory.CreateDirectory(tmpDir);
            SetFile(tmpDir + tmpFile);
            SerializeToFile(type, obj);

            StreamReader sr = new StreamReader(tmpDir + tmpFile);
            string content = "";
            try
            {
                content = sr.ReadToEnd();
            }
            catch(Exception e)
            {
                content = e.Message;
            }

            return content;
        }

        public object DeSerialize(Type type, string xml)
        {
            XmlSerializer seri = new XmlSerializer(type);
            StringReader rdr = new StringReader(xml);
            return seri.Deserialize(rdr);
        }

        public void SerializeToFile(Type type, object obj)
        {
            CheckFile();
            FileStream stream = new FileStream(file, FileMode.Open, FileAccess.Write, FileShare.ReadWrite);
            XmlSerializer seri = new XmlSerializer(type);
            seri.Serialize(stream, obj);
            stream.Flush();
            stream.Close();
            stream.Dispose();
        }

        public object DeSerializeFromFile(Type type)
        {
            FileStream stream = new FileStream(file, FileMode.Open);
            XmlSerializer seri = new XmlSerializer(type);
            object obj = seri.Deserialize(stream);
            stream.Close();
            return obj;
        }

        private void CheckFile()
        {
           if(file != "" && file != null)
            {
                if (!File.Exists(file))
                {
                    var myFile = File.Create(file);
                    myFile.Close();
                    StreamWriter sw = new StreamWriter(file);
                    sw.Write("<root></root>");
                    sw.Flush();
                    sw.Close();
                }
                else
                {
                    StreamWriter sw = new StreamWriter(file);
                    sw.Write("<root></root>");
                    sw.Flush();
                    sw.Close();
                    doc = new XmlDocument();
                    doc.Load(file);
                }
            }
           else
            {
                throw new Exception("");
            }
        }
    }
}
