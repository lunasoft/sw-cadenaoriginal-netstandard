using System;
using SW.Helpers;

namespace sw_cadenaoriginal
{
    /// <summary>
    /// Creación de cadenas originales para los diferentes CFDI sin importar su versión.
    /// </summary>
    public class CadenaOriginal
    {
        static CadenaOriginal()
        {
            Singleton.InstanceCadenaOriginal32.getInstance();
            Singleton.InstanceCadenaOriginal33.getInstance();
            Singleton.InstanceCadenaOriginal40.getInstance();
        }

        /// <summary>
        /// Genera y devuelve la cadena original de acuerdo al XML recibido.
        /// </summary>
        /// <param name="strXml">Cadena que contendrá el XML que se utilizara para la generación de la cadena original</param>
        /// <param name="version">Cadena para especificar la versión del CFDI con tenido en el parámetro strXml, en caso de no especificar este parámetro se tomara la versión de acuerdo al XML recibido</param>
        /// <returns>string que representa la cadena originar generada</returns>
        /// <exception cref="ArgumentException"> 
        /// Cuando <paramref name="strXml"/> está vacío. 
        /// Cuando se tenga problemas al cargar recursos para generar la cadena original. 
        /// </excepción>
        /// <exception cref="NotImplementedException"> 
        /// Cuando <paramref name="version"/> está vacío y no se encuentre en <paramref name="strXml"/>. 
        /// </excepción>
        public static string CadenaOriginalCFDI(string strXml, string version = "")
        {
            if (string.IsNullOrEmpty(strXml))
                throw new ArgumentException("El XML no puede estar vacío", "strXml");

            if (string.IsNullOrEmpty(version))
                version = XmlUtils.VersionCFDI(strXml); 

            switch (version)
            {
                case "3.2":
                    return Singleton.InstanceCadenaOriginal32.getInstance().Transform(strXml);
                case "3.3":
                    return Singleton.InstanceCadenaOriginal33.getInstance().Transform(strXml);
                case "4.0":
                    return Singleton.InstanceCadenaOriginal40.getInstance().Transform(strXml);
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
