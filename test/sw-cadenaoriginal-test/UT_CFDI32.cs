using Xunit;
using System.IO;
using System.Text;
using sw_cadenaoriginal;

namespace sw_cadenaoriginal_test
{
    public class UT_CFDI32
    {
        /// <summary>
        /// Generar cadena original de un CFDI 3.2 sin especificar la versión
        /// </summary>
        [Fact]
        public void UT_CFDI32_SinVersion()
        {
            string xml = Encoding.UTF8.GetString(File.ReadAllBytes("Resources/CFDI32/CFDI32.xml"));
            string cadena = CadenaOriginal.CadenaOriginalCFDI(xml);
            Assert.True(cadena.Equals("||3.2|2017-11-07T23:35:52|ingreso|Pago en una sola exhibición|1333.00|1.0000|MXN|1546.28|NA|ZAPOPAN, JALISCO|No Identificado|IIA040805DZ4|MI SUPER CUENTA DE DESSARROLLO|AV WASHINGTON|4921|12345|JARDINES VALLARTA|ZAPOPAN|ZAPOPAN|JALISCO|MÉXICO|45110|GENERAL DE LEY PERSONAS MORALES|GENERAL DE LEY PERSONAS MORALES DOBLE REGIMEN|CACX7605101P8|PUBLICO GENERAL|CALLE|1|GUADALAJARA|GUADALAJARA|GUADALAJARA|JALISCO|MEX|45100|1|No Aplica|UT421511|123|1333|1333.000000|IVA|16|213.28||"), cadena);
        }

        /// <summary>
        /// Generar cadena original de un CFDI 3.2 especificando la versión
        /// </summary>
        [Fact]
        public void UT_CFDI32_Version()
        {
            string xml = Encoding.UTF8.GetString(File.ReadAllBytes("Resources/CFDI32/CFDI32.xml"));
            string cadena = CadenaOriginal.CadenaOriginalCFDI(xml, "3.2");
            Assert.True(cadena.Equals("||3.2|2017-11-07T23:35:52|ingreso|Pago en una sola exhibición|1333.00|1.0000|MXN|1546.28|NA|ZAPOPAN, JALISCO|No Identificado|IIA040805DZ4|MI SUPER CUENTA DE DESSARROLLO|AV WASHINGTON|4921|12345|JARDINES VALLARTA|ZAPOPAN|ZAPOPAN|JALISCO|MÉXICO|45110|GENERAL DE LEY PERSONAS MORALES|GENERAL DE LEY PERSONAS MORALES DOBLE REGIMEN|CACX7605101P8|PUBLICO GENERAL|CALLE|1|GUADALAJARA|GUADALAJARA|GUADALAJARA|JALISCO|MEX|45100|1|No Aplica|UT421511|123|1333|1333.000000|IVA|16|213.28||"), cadena);
        }
    }
}
