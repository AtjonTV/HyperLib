﻿using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Windows;
using System.Windows.Forms;

namespace HyperLib
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

        public void SerializeToFile(Type type, object obj)
        {
            CheckFile();
            FileStream stream = new FileStream(file, FileMode.OpenOrCreate);
            XmlSerializer seri = new XmlSerializer(type);
            seri.Serialize(stream, obj);
            stream.Flush();
            stream.Close();
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
                    File.Create(file);
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