using System;
using System.IO;
using System.Web.Script.Serialization;

namespace HyperLib
{
    public class JsonManager
    {
        private string file;

        public JsonManager()
        {

        }

        public JsonManager(string File)
        {
            file = File;
        }

        public void SetFile(string File) { file = File; }
        public string GetFile() { return file; }

        public void SerializeToFile(object ToSerialize)
        {
            JavaScriptSerializer JSS = new JavaScriptSerializer();
            string json = JSS.Serialize(ToSerialize);

            StreamWriter sw = new StreamWriter(file);
            try
            {
                sw.Write(json);
                sw.Flush();
                sw.Close();
            }
            catch (IOException)
            {
            }
        }

        public string Serialize(object ToSerialize)
        {
            JavaScriptSerializer JSS = new JavaScriptSerializer();
            string json = JSS.Serialize(ToSerialize);
            return json;
        }

        public object DeSerializeFromFile(Type TargetType)
        {
            JavaScriptSerializer JSS = new JavaScriptSerializer();

            StreamReader sr = new StreamReader(file);
            string fromfile = "";
            try
            {
                fromfile = sr.ReadToEnd();
                sr.Close();
            }
            catch(IOException)
            {
            }

            object obj = JSS.Deserialize(fromfile, TargetType);
            return obj;
        }

        public object DeSerialize(string JsonString, Type TargetType)
        {
            JavaScriptSerializer JSS = new JavaScriptSerializer();
            object obj = JSS.Deserialize(JsonString, TargetType);
            return obj;
        }
    }
}
