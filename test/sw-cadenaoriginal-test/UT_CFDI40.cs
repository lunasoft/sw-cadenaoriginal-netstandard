using Xunit;
using System.IO;
using System.Text;
using sw_cadenaoriginal;

namespace sw_cadenaoriginal_test
{
    public class UT_CFDI40
    {
        /// <summary>
        /// Generar cadena original de un CFDI 4.0 de tipo ingreso sin especificar la versión
        /// </summary>
        [Fact]
        public void UT_CFDI40_Ingreso()
        {
            string xml = Encoding.UTF8.GetString(File.ReadAllBytes("Resources/CFDI40/CFDI40_Ingreso.xml"));
            string cadena = CadenaOriginal.CadenaOriginalCFDI(xml);
            Assert.True(cadena.Equals("||4.0|Serie|Folio|2021-12-14T00:18:10|99||CondicionesDePago|200|1|AMD|1|199.16|I|01|PPD|20000|EKU9003173C9|ESCUELA KEMPER URGATE|601|URE180429TM6|UNIVERSIDAD ROBOTICA ESPAÑOLA|65000|601|G01|50211503|1|H87|Pieza|Cigarros|200.00|200.00|1|02|1|002|Tasa|0.160000|0.16|1|001|Tasa|0.100000|0.00|1|002|Tasa|0.106666|0.00|001|0.00|002|0.00|0.00|1|002|Tasa|0.160000|0.16|0.16||"), cadena);
        }

        /// <summary>
        /// Generar cadena original de un CFDI 4.0 de tipo egreso especificando la versión
        /// </summary>
        [Fact]
        public void UT_CFDI40_Egreso()
        {
            string xml = Encoding.UTF8.GetString(File.ReadAllBytes("Resources/CFDI40/CFDI40_Egreso.xml"));
            string cadena = CadenaOriginal.CadenaOriginalCFDI(xml, "4.0");
            Assert.True(cadena.Equals("||4.0|Serie|Folio|2022-01-30T00:18:10||CondicionesDePago|10.00|0|AMD|1|11.60|E|01|20000|01|1fac4464-1111-0000-1111-cd37179db12e|EKU9003173C9|ESCUELA KEMPER URGATE|601|URE180429TM6|UNIVERSIDAD ROBOTICA ESPAÑOLA|65000|601|P01|84111506|1.0|ACT|NC por devolucion|10.00|10.00|0.00|02|10.00|002|Tasa|0.160000|1.6|10.00|002|Tasa|0.160000|1.6|1.6||"), cadena);
        }

        /// <summary>
        /// Generar cadena original de un CFDI 4.0 de tipo pago sin especificar la versión
        /// </summary>
        [Fact]
        public void UT_CFDI40_Pago()
        {
            string xml = Encoding.UTF8.GetString(File.ReadAllBytes("Resources/CFDI40/CFDI40_Pago.xml"));
            string cadena = CadenaOriginal.CadenaOriginalCFDI(xml);
            Assert.True(cadena.Equals("||4.0|Serie|Folio|2022-03-29T00:18:10||0|XXX|0.00|P|01|20000|EKU9003173C9|ESCUELA KEMPER URGATE|601|URE180429TM6|UNIVERSIDAD ROBOTICA ESPAÑOLA|65000|601|CP01|84111506|1|ACT|Pago|0|0|01|2.0|200.00|2021-12-15T00:00:00|01|MXN|1|200.00|bfc36522-4b8e-45c4-8f14-d11b289f9eb7|MXN|1|1|200.00|200.00|0.00|01||"), cadena);
        }

        /// <summary>
        /// Generar cadena original de un CFDI 4.0 de tipo traslado especificando la versión
        /// </summary>
        [Fact]
        public void UT_CFDI40_Traslado()
        {
            string xml = Encoding.UTF8.GetString(File.ReadAllBytes("Resources/CFDI40/CFDI40_Traslado.xml"));
            string cadena = CadenaOriginal.CadenaOriginalCFDI(xml, "4.0");
            Assert.True(cadena.Equals("||4.0|Serie|Folio|2022-02-23T00:18:10||CondicionesDePago|0|0|AMD|1|0|T|01|20000|EKU9003173C9|ESCUELA KEMPER URGATE|601|EKU9003173C9|ESCUELA KEMPER URGATE|26015|601|G01|50211503|UT421511|1|H87|Pieza|Cigarros|0.00|0.00|01|21 47 3807 8003832|50211503|123|1|Pieza|cosas|200.00|200.00||"), cadena);
        }

        /// <summary>
        /// Generar cadena original de un CFDI 4.0 de tipo nomina sin especificar la versión
        /// </summary>
        [Fact]
        public void UT_CFDI40_Nomina()
        {
            string xml = Encoding.UTF8.GetString(File.ReadAllBytes("Resources/CFDI40/CFDI40_Nomina.xml"));
            string cadena = CadenaOriginal.CadenaOriginalCFDI(xml);
            Assert.True(cadena.Equals("||4.0|Serie|Folio|2022-03-28T00:00:00|30001000000400002444|CondicionesDePago|5000|300|MXN|1|4700|N|01|PPD|20000|EKU9003173C9|ESCUELA KEMPER URGATE|601|XOJI740919U48|INGRID XODAR JIMENEZ|88965|605|CN01|84111505|1|ACT|Pago de nómina|5000.00|5000.00|300|01|1.2|O|2021-12-24|2021-12-09|2021-12-24|15|5000.0|300|B5510768108|URE180429TM6|BADD110313HCMLNS09|000000|2015-01-01|P364W|01|01|03|120|Desarrollo|Ingeniero de Software|1|04|072320002084170154|490.22|146.47|JAL|5000.0|2808.8|2191.2|001|00500|Sueldos, Salarios Rayas y Jornales|2808.8|2191.2|200|100|001|00301|Seguridad Social|200|002|00302|ISR|100||"), cadena);
        }

        /// <summary>
        /// Generar cadena original de un CFDI 4.0 de tipo ingreso con comercio exterior especificando la versión
        /// </summary>
        [Fact]
        public void UT_CFDI40_ComercioExterior()
        {
            string xml = Encoding.UTF8.GetString(File.ReadAllBytes("Resources/CFDI40/CFDI40_ComercioExterior.xml"));
            string cadena = CadenaOriginal.CadenaOriginalCFDI(xml, "4.0");
            Assert.True(cadena.Equals("||4.0|Serie|Folio|2022-02-14T00:18:00|99|30001000000400002434|CondicionesDePago|400|1|AMD|1|399.16|I|02|PPD|20000|EKU9003173C9|ESCUELA KEMPER URGATE|601|URE180429TM6|UNIVERSIDAD ROBOTICA ESPAÑOLA|65000|601|G01|50211503|131494-1055|2|H87|Pieza|Cigarros|200.00|400.00|1|02|1|002|Tasa|0.160000|0.16|1|001|Tasa|0.100000|0.00|1|002|Tasa|0.106666|0.00|001|0.00|002|0.00|0.00|1|002|Tasa|0.160000|0.16|0.16|1.1|2|A1|0|FOB|0|15.6446|25.56|CALLE DEL PAPEL|0214|01|014|QUE|MEX|76199|CALLE DEL PAPEL|0214|01|014|QUE|MEX|76199|131494-1055|2402200100|117.64|01|12.78|25.56||"), cadena);
        }

        /// <summary>
        /// Generar cadena original de un CFDI 4.0 de tipo ingreso con carta porte sin especificar la versión
        /// </summary>
        [Fact]
        public void UT_CFDI40_Ingreso_CartaPorte()
        {
            string xml = Encoding.UTF8.GetString(File.ReadAllBytes("Resources/CFDI40/CFDI40_Ingreso_CartaPorte_Autotransporte.xml"));
            string cadena = CadenaOriginal.CadenaOriginalCFDI(xml);
            Assert.True(cadena.Equals("||4.0|Serie|Folio|2022-01-31T00:18:10|99||CondicionesDePago|200|1|AMD|1|199.16|I|01|PPD|20000|EKU9003173C9|ESCUELA KEMPER URGATE|601|URE180429TM6|UNIVERSIDAD ROBOTICA ESPAÑOLA|65000|601|G01|78101500|1|H87|Pieza|Cigarros|200.00|200.00|1|02|1|002|Tasa|0.160000|0.16|1|001|Tasa|0.100000|0.00|1|002|Tasa|0.106666|0.00|001|0.00|002|0.00|0.00|1|002|Tasa|0.160000|0.16|0.16|2.0|No|2|Origen|OR101010|EKU9003173C9|2021-11-01T00:00:00|calle|211|0347|23|casa blanca 1|004|COA|MEX|25350|Destino|DE202020|AAA010101AAA|2021-11-01T01:00:00|1|calle|214|0347|23|casa blanca 2|004|COA|MEX|25350|Destino|DE202021|AAA010101AAA|2021-11-01T02:00:00|1|calle|220|0347|23|casa blanca 3|004|COA|MEX|25350|2.0|XBX|2|11121900|Productos de perfumería|1.0|XBX|Sí|1266|4H2|1.0|1|OR101010|DE202020|11121900|Productos de perfumería|1.0|XBX|Sí|1266|4H2|1.0|1|OR101010|DE202021|TPAF01|NumPermisoSCT|VL|plac892|2020|SW Seguros|123456789|SW Seguros Ambientales|123456789|SW Seguros|CTR021|ABC123|01|VAAM130719H60|a234567890||"), cadena);
        }

        /// <summary>
        /// Generar cadena original de un CFDI 4.0 de tipo traslado con carta porte especificando la versión
        /// </summary>
        [Fact]
        public void UT_CFDI40_Traslado_CartaPorte()
        {
            string xml = Encoding.UTF8.GetString(File.ReadAllBytes("Resources/CFDI40/CFDI40_Traslado_CartaPorte_Autotransporte.xml"));
            string cadena = CadenaOriginal.CadenaOriginalCFDI(xml, "4.0");
            Assert.True(cadena.Equals("||4.0|Serie|Folio|2022-02-23T00:18:10||CondicionesDePago|0|0|XXX|0|T|01|20000|EKU9003173C9|ESCUELA KEMPER URGATE|601|EKU9003173C9|ESCUELA KEMPER URGATE|26015|601|S01|50211503|UT421511|1|H87|Pieza|Cigarros|0.00|0.00|01|21 47 3807 8003832|50211503|123|1|Pieza|cosas|200.00|200.00|2.0|No|1|Origen|OR101010|EKU9003173C9|2021-11-01T00:00:00|calle|211|0347|23|casa blanca|004|COA|MEX|25350|Destino|DE202020|AAA010101AAA|2021-11-01T01:00:00|1|calle|214|0347|23|casa blanca|004|COA|MEX|25350|1.0|XBX|1|11121900|Accesorios de equipo de telefonía|1.0|XBX|No|1.0|1|OR101010|DE202020|TPAF01|NumPermisoSCT|VL|plac892|2020|SW Seguros|123456789|SW Seguros|CTR004|VL45K98|01|VAAM130719H60|a234567890||"), cadena);
        }
        /// <summary>
        /// Generar cadena original de un CFDI 4.0 de tipo traslado con carta porte 3.0 especificando la versión
        /// </summary>
        [Fact]
        public void UT_CFDI40_Traslado_CartaPorte30()
        {
            string xml = Encoding.UTF8.GetString(File.ReadAllBytes("Resources/CFDI40/cfdicp30.xml"));
            string cadena = CadenaOriginal.CadenaOriginalCFDI(xml, "4.0");
            Assert.True(cadena.Equals("||4.0|Serie|Folio|2023-10-02T11:30:55|01|30001000000500003416|100.00|MXN|100.00|I|01|PUE|20000|EKU9003173C9|ESCUELA KEMPER URGATE|601|URE180429TM6|UNIVERSIDAD ROBOTICA ESPAÑOLA|86991|601|G01|78101800|UT421511|1|H87|Pieza|Transporte de carga por carretera|100.00|100.00|01|3.0|CCC98765-FEDC-5678-4321-ABCDEF098765|No|5|Origen|OR123456|URE180429TM6|2023-10-02T18:00:00|2109|05|057|OAX|MEX|70300|Destino|DE123456|URE180429TM6|2023-10-02T19:00:00|5|2109|05|057|OAX|MEX|70300|1|KGM|1|10101500|Mercancia|1.00|18|01|Medicamento|Medicamento|SW Sapien|2024-01-23|123456|01|03|123456789|1.00|1|OR123456|DE123456|TPAF01|12345|C2|100|ABC123|2023|SW Sapien|12345|01|123456789|Nombre Apellido||"), cadena);
        }
        /// <summary>
        /// Generar cadena original de un CFDI 4.0 de tipo traslado con comercio exterior 2.0 especificando la versión
        /// </summary>
        [Fact]
        public void UT_CFDI40_Traslado_ComercioExterior20()
        {
            string xml = Encoding.UTF8.GetString(File.ReadAllBytes("Resources/CFDI40/CFDI40_cce20.xml"));
            string cadena = CadenaOriginal.CadenaOriginalCFDI(xml, "4.0");
            Assert.True(cadena.Equals("||4.0|Serie|Folio1|2024-01-12T00:00:00|99|30001000000500003416|CondicionesDePago|400|AMD|1|400.06|I|02|PPD|20000|EKU9003173C9|ESCUELA KEMPER URGATE|601|XEXX010101000|U.S. & SW|20000|USA|123456789|616|CP01|50211503|131494-1055|2|H87|Pieza|Cigarros|200.00|400.00|02|1|002|Tasa|0.160000|0.16|1|001|Tasa|0.100000|0.10|001|0.10|0.10|1|002|Tasa|0.160000|0.16|0.16|2.0|A1|0|FOB|16.9912|25.56|CALLE DEL PAPEL|0214|01|014|QUE|MEX|76199|123456789|ST. A|TX|USA|00000|131494-1055|2402200100|117.64|01|12.78|25.56||"), cadena);
        }
    }
}