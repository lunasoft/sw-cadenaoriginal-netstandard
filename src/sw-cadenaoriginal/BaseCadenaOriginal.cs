using System;
using System.IO;
using System.Xml;
using System.Xml.Xsl;
using sw_cadenaoriginal.Helpers;

namespace sw_cadenaoriginal
{
    internal abstract class BaseCadenaOriginal
    {
        protected XslCompiledTransform xslt_cadenaoriginal = new XslCompiledTransform();

        public BaseCadenaOriginal(string xsltDirectory)
        {
            Stream strm = this.GetType().Assembly.GetManifestResourceStream(xsltDirectory);
            EmbeddedResourceXsltResolver resolver = new EmbeddedResourceXsltResolver();

            if (strm == null)
                throw new ArgumentException("Problemas al cargar recursos", "xslt");

            XmlReader xsltReader = XmlReader.Create(strm);
            XsltSettings settings = new XsltSettings(true, true);
            xslt_cadenaoriginal.Load(xsltReader, settings, resolver);
        }

        internal virtual string Transform(string strXml)
        {
            string cadenaoriginal = "";
            StringWriter writer = new StringWriter();
            XmlReader xml = XmlReader.Create(new StringReader(strXml));
            xslt_cadenaoriginal.Transform(xml, null, writer);
            cadenaoriginal = writer.ToString().Trim();
            writer.Close();

            return cadenaoriginal;
        }
    }
}
