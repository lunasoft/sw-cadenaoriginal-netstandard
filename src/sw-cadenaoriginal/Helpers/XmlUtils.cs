using System.Xml;

namespace SW.Helpers
{
    public static class XmlUtils
    {
        public static string VersionCFDI(string strXml) 
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(strXml);

            string version = xmlDoc.DocumentElement.GetAttribute("Version");
            if(string.IsNullOrEmpty(version))
                version = xmlDoc.DocumentElement.GetAttribute("version");

            return version;
        }
    }
}
