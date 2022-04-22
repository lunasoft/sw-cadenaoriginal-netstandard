using Xunit;
using System.IO;
using System.Text;
using sw_cadenaoriginal;

namespace sw_cadenaoriginal_test
{
    public class UT_CFDI33
    {
        /// <summary>
        /// Generar cadena original de un CFDI 3.3 sin especificar la versión
        /// </summary>
        [Fact]
        public void UT_CFDI33_SinVersion()
        {
            string xml = Encoding.UTF8.GetString(File.ReadAllBytes("Resources/CFDI33/CFDI33.xml"));
            string cadena = CadenaOriginal.CadenaOriginalCFDI(xml);
            Assert.True(cadena.Equals("||3.3|RogueOne|HNFK231|2018-07-06T12:17:59|01|20001000000300022816|200.00|MXN|1|603.20|I|PUE|06300|LAN8507268IA|MB IDEAS DIGITALES SC|601|AAA010101AAA|SW SMARTERWEB|G03|50211503|UT421511|1|H87|Pieza|Cigarros|200.00|200.00|200.00|002|Tasa|0.160000|32.00|232.00|003|Tasa|1.600000|371.20|002|Tasa|0.160000|32.00|003|Tasa|1.600000|371.20|403.20||"), cadena);
        }

        /// <summary>
        /// Generar cadena original de un CFDI 3.3 especificando la versión
        /// </summary>
        [Fact]
        public void UT_CFDI33_Version()
        {
            string xml = Encoding.UTF8.GetString(File.ReadAllBytes("Resources/CFDI33/CFDI33.xml"));
            string cadena = CadenaOriginal.CadenaOriginalCFDI(xml, "3.3");
            Assert.True(cadena.Equals("||3.3|RogueOne|HNFK231|2018-07-06T12:17:59|01|20001000000300022816|200.00|MXN|1|603.20|I|PUE|06300|LAN8507268IA|MB IDEAS DIGITALES SC|601|AAA010101AAA|SW SMARTERWEB|G03|50211503|UT421511|1|H87|Pieza|Cigarros|200.00|200.00|200.00|002|Tasa|0.160000|32.00|232.00|003|Tasa|1.600000|371.20|002|Tasa|0.160000|32.00|003|Tasa|1.600000|371.20|403.20||"), cadena);
        }
    }
}
