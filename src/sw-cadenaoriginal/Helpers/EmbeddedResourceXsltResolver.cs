using System;
using System.IO;
using System.Xml;
using System.Xml.Xsl;
using System.Reflection;

namespace sw_cadenaoriginal.Helpers
{
    internal class EmbeddedResourceXsltResolver : XmlUrlResolver
    {
        /// <summary>
        /// 
        /// </summary>
        public override System.Net.ICredentials Credentials
        {
            set { throw new NotImplementedException(); }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseUri"></param>
        /// <param name="relativeUri"></param>
        /// <returns></returns>
        public override Uri ResolveUri(Uri baseUri, string relativeUri)
        {
            return new Uri("tdb:" + relativeUri);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="absoluteUri"></param>
        /// <param name="role"></param>
        /// <param name="ofObjectToReturn"></param>
        /// <returns></returns>
        public override object GetEntity(Uri absoluteUri, string role, Type ofObjectToReturn)
        {
            var executingAssembly = Assembly.GetExecutingAssembly();

            foreach (var resourceName in executingAssembly.GetManifestResourceNames())
            {
                if (resourceName.EndsWith("." + absoluteUri.LocalPath))
                {
                    var xslt = executingAssembly.GetManifestResourceStream(resourceName);
                    return XmlReader.Create(new StreamReader(xslt), null, absoluteUri.LocalPath);
                }
            }

            throw new FileNotFoundException("Problemas al cargar el recurso: " + absoluteUri.LocalPath);
        }
    }
}
