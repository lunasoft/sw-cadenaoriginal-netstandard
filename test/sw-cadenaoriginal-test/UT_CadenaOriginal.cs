using Xunit;
using System.IO;
using System.Text;
using sw_cadenaoriginal;

namespace sw_cadenaoriginal_test
{
    public class UT_CadenaOriginal
    {
        /// <summary>
        /// Generar cadena original de un CFDI 3.2, 3.3 y 4.0 de tipo ingreso sin especificar la versión
        /// </summary>
        [Fact]
        public void UT_CadenaOriginal_SinVersion()
        {
            string xml32 = Encoding.UTF8.GetString(File.ReadAllBytes("Resources/CFDI32/CFDI32.xml"));
            string cadena32 = CadenaOriginal.CadenaOriginalCFDI(xml32);

            string xml33 = Encoding.UTF8.GetString(File.ReadAllBytes("Resources/CFDI33/CFDI33.xml"));
            string cadena33 = CadenaOriginal.CadenaOriginalCFDI(xml33);

            string xml44 = Encoding.UTF8.GetString(File.ReadAllBytes("Resources/CFDI40/CFDI40_Ingreso.xml"));
            string cadena44 = CadenaOriginal.CadenaOriginalCFDI(xml44);

            Assert.True(cadena32.Equals("||3.2|2017-11-07T23:35:52|ingreso|Pago en una sola exhibición|1333.00|1.0000|MXN|1546.28|NA|ZAPOPAN, JALISCO|No Identificado|IIA040805DZ4|MI SUPER CUENTA DE DESSARROLLO|AV WASHINGTON|4921|12345|JARDINES VALLARTA|ZAPOPAN|ZAPOPAN|JALISCO|MÉXICO|45110|GENERAL DE LEY PERSONAS MORALES|GENERAL DE LEY PERSONAS MORALES DOBLE REGIMEN|CACX7605101P8|PUBLICO GENERAL|CALLE|1|GUADALAJARA|GUADALAJARA|GUADALAJARA|JALISCO|MEX|45100|1|No Aplica|UT421511|123|1333|1333.000000|IVA|16|213.28||"), cadena32);
            Assert.True(cadena33.Equals("||3.3|RogueOne|HNFK231|2018-07-06T12:17:59|01|20001000000300022816|200.00|MXN|1|603.20|I|PUE|06300|LAN8507268IA|MB IDEAS DIGITALES SC|601|AAA010101AAA|SW SMARTERWEB|G03|50211503|UT421511|1|H87|Pieza|Cigarros|200.00|200.00|200.00|002|Tasa|0.160000|32.00|232.00|003|Tasa|1.600000|371.20|002|Tasa|0.160000|32.00|003|Tasa|1.600000|371.20|403.20||"), cadena33);
            Assert.True(cadena44.Equals("||4.0|Serie|Folio|2021-12-14T00:18:10|99||CondicionesDePago|200|1|AMD|1|199.16|I|01|PPD|20000|EKU9003173C9|ESCUELA KEMPER URGATE|601|URE180429TM6|UNIVERSIDAD ROBOTICA ESPAÑOLA|65000|601|G01|50211503|1|H87|Pieza|Cigarros|200.00|200.00|1|02|1|002|Tasa|0.160000|0.16|1|001|Tasa|0.100000|0.00|1|002|Tasa|0.106666|0.00|001|0.00|002|0.00|0.00|1|002|Tasa|0.160000|0.16|0.16||"), cadena44);
        }

        /// <summary>
        /// Generar cadena original de un CFDI 3.2, 3.3 y 4.0 de tipo ingreso especificando la versión
        /// </summary>
        [Fact]
        public void UT_CadenaOriginal_ConVersion()
        {
            string xml32 = Encoding.UTF8.GetString(File.ReadAllBytes("Resources/CFDI32/CFDI32.xml"));
            string cadena32 = CadenaOriginal.CadenaOriginalCFDI(xml32, "3.2");

            string xml33 = Encoding.UTF8.GetString(File.ReadAllBytes("Resources/CFDI33/CFDI33.xml"));
            string cadena33 = CadenaOriginal.CadenaOriginalCFDI(xml33, "3.3");

            string xml44 = Encoding.UTF8.GetString(File.ReadAllBytes("Resources/CFDI40/CFDI40_Ingreso.xml"));
            string cadena44 = CadenaOriginal.CadenaOriginalCFDI(xml44, "4.0");

            Assert.True(cadena32.Equals("||3.2|2017-11-07T23:35:52|ingreso|Pago en una sola exhibición|1333.00|1.0000|MXN|1546.28|NA|ZAPOPAN, JALISCO|No Identificado|IIA040805DZ4|MI SUPER CUENTA DE DESSARROLLO|AV WASHINGTON|4921|12345|JARDINES VALLARTA|ZAPOPAN|ZAPOPAN|JALISCO|MÉXICO|45110|GENERAL DE LEY PERSONAS MORALES|GENERAL DE LEY PERSONAS MORALES DOBLE REGIMEN|CACX7605101P8|PUBLICO GENERAL|CALLE|1|GUADALAJARA|GUADALAJARA|GUADALAJARA|JALISCO|MEX|45100|1|No Aplica|UT421511|123|1333|1333.000000|IVA|16|213.28||"), cadena32);
            Assert.True(cadena33.Equals("||3.3|RogueOne|HNFK231|2018-07-06T12:17:59|01|20001000000300022816|200.00|MXN|1|603.20|I|PUE|06300|LAN8507268IA|MB IDEAS DIGITALES SC|601|AAA010101AAA|SW SMARTERWEB|G03|50211503|UT421511|1|H87|Pieza|Cigarros|200.00|200.00|200.00|002|Tasa|0.160000|32.00|232.00|003|Tasa|1.600000|371.20|002|Tasa|0.160000|32.00|003|Tasa|1.600000|371.20|403.20||"), cadena33);
            Assert.True(cadena44.Equals("||4.0|Serie|Folio|2021-12-14T00:18:10|99||CondicionesDePago|200|1|AMD|1|199.16|I|01|PPD|20000|EKU9003173C9|ESCUELA KEMPER URGATE|601|URE180429TM6|UNIVERSIDAD ROBOTICA ESPAÑOLA|65000|601|G01|50211503|1|H87|Pieza|Cigarros|200.00|200.00|1|02|1|002|Tasa|0.160000|0.16|1|001|Tasa|0.100000|0.00|1|002|Tasa|0.106666|0.00|001|0.00|002|0.00|0.00|1|002|Tasa|0.160000|0.16|0.16||"), cadena44);
        }

        /// <summary>
        /// Generar cadena original de varios CFDI 4.0 sin especificar la versión
        /// </summary>
        [Fact]
        public void UT_CadenaOriginal_CFDI40_SinVersion()
        {
            string xmlIngreso = Encoding.UTF8.GetString(File.ReadAllBytes("Resources/CFDI40/CFDI40_Ingreso.xml"));
            string cadenaIngreso = CadenaOriginal.CadenaOriginalCFDI(xmlIngreso);
                       
            string xmlEgreso = Encoding.UTF8.GetString(File.ReadAllBytes("Resources/CFDI40/CFDI40_Egreso.xml"));
            string cadenaEgreso = CadenaOriginal.CadenaOriginalCFDI(xmlEgreso);
                        
            string xmlPago = Encoding.UTF8.GetString(File.ReadAllBytes("Resources/CFDI40/CFDI40_Pago.xml"));
            string cadenaPago = CadenaOriginal.CadenaOriginalCFDI(xmlPago);
           
            string xmlTraslado = Encoding.UTF8.GetString(File.ReadAllBytes("Resources/CFDI40/CFDI40_Traslado.xml"));
            string cadenaTraslado = CadenaOriginal.CadenaOriginalCFDI(xmlTraslado);
            
            string xmlNomina = Encoding.UTF8.GetString(File.ReadAllBytes("Resources/CFDI40/CFDI40_Nomina.xml"));
            string cadenaNomina = CadenaOriginal.CadenaOriginalCFDI(xmlNomina);
            
            string xmlComercioExterior = Encoding.UTF8.GetString(File.ReadAllBytes("Resources/CFDI40/CFDI40_ComercioExterior.xml"));
            string cadenaComercioExterior = CadenaOriginal.CadenaOriginalCFDI(xmlComercioExterior);
           
            string xmlIngresoCartaPorte = Encoding.UTF8.GetString(File.ReadAllBytes("Resources/CFDI40/CFDI40_Ingreso_CartaPorte_Autotransporte.xml"));
            string cadenaIngresoCartaPorte = CadenaOriginal.CadenaOriginalCFDI(xmlIngresoCartaPorte);
           
            string xmlTrasladoCartaPorte = Encoding.UTF8.GetString(File.ReadAllBytes("Resources/CFDI40/CFDI40_Traslado_CartaPorte_Autotransporte.xml"));
            string cadenaTrasladoCartaPorte = CadenaOriginal.CadenaOriginalCFDI(xmlTrasladoCartaPorte);

            Assert.True(cadenaIngreso.Equals("||4.0|Serie|Folio|2021-12-14T00:18:10|99||CondicionesDePago|200|1|AMD|1|199.16|I|01|PPD|20000|EKU9003173C9|ESCUELA KEMPER URGATE|601|URE180429TM6|UNIVERSIDAD ROBOTICA ESPAÑOLA|65000|601|G01|50211503|1|H87|Pieza|Cigarros|200.00|200.00|1|02|1|002|Tasa|0.160000|0.16|1|001|Tasa|0.100000|0.00|1|002|Tasa|0.106666|0.00|001|0.00|002|0.00|0.00|1|002|Tasa|0.160000|0.16|0.16||"), cadenaIngreso);
            Assert.True(cadenaEgreso.Equals("||4.0|Serie|Folio|2022-01-30T00:18:10||CondicionesDePago|10.00|0|AMD|1|11.60|E|01|20000|01|1fac4464-1111-0000-1111-cd37179db12e|EKU9003173C9|ESCUELA KEMPER URGATE|601|URE180429TM6|UNIVERSIDAD ROBOTICA ESPAÑOLA|65000|601|P01|84111506|1.0|ACT|NC por devolucion|10.00|10.00|0.00|02|10.00|002|Tasa|0.160000|1.6|10.00|002|Tasa|0.160000|1.6|1.6||"), cadenaEgreso);
            Assert.True(cadenaPago.Equals("||4.0|Serie|Folio|2022-03-29T00:18:10||0|XXX|0.00|P|01|20000|EKU9003173C9|ESCUELA KEMPER URGATE|601|URE180429TM6|UNIVERSIDAD ROBOTICA ESPAÑOLA|65000|601|CP01|84111506|1|ACT|Pago|0|0|01|2.0|200.00|2021-12-15T00:00:00|01|MXN|1|200.00|bfc36522-4b8e-45c4-8f14-d11b289f9eb7|MXN|1|1|200.00|200.00|0.00|01||"), cadenaPago);
            Assert.True(cadenaTraslado.Equals("||4.0|Serie|Folio|2022-02-23T00:18:10||CondicionesDePago|0|0|AMD|1|0|T|01|20000|EKU9003173C9|ESCUELA KEMPER URGATE|601|EKU9003173C9|ESCUELA KEMPER URGATE|26015|601|G01|50211503|UT421511|1|H87|Pieza|Cigarros|0.00|0.00|01|21 47 3807 8003832|50211503|123|1|Pieza|cosas|200.00|200.00||"), cadenaTraslado);
            Assert.True(cadenaNomina.Equals("||4.0|Serie|Folio|2022-03-28T00:00:00|30001000000400002444|CondicionesDePago|5000|300|MXN|1|4700|N|01|PPD|20000|EKU9003173C9|ESCUELA KEMPER URGATE|601|XOJI740919U48|INGRID XODAR JIMENEZ|88965|605|CN01|84111505|1|ACT|Pago de nómina|5000.00|5000.00|300|01|1.2|O|2021-12-24|2021-12-09|2021-12-24|15|5000.0|300|B5510768108|URE180429TM6|BADD110313HCMLNS09|000000|2015-01-01|P364W|01|01|03|120|Desarrollo|Ingeniero de Software|1|04|072320002084170154|490.22|146.47|JAL|5000.0|2808.8|2191.2|001|00500|Sueldos, Salarios Rayas y Jornales|2808.8|2191.2|200|100|001|00301|Seguridad Social|200|002|00302|ISR|100||"), cadenaNomina);
            Assert.True(cadenaComercioExterior.Equals("||4.0|Serie|Folio|2022-02-14T00:18:00|99|30001000000400002434|CondicionesDePago|400|1|AMD|1|399.16|I|02|PPD|20000|EKU9003173C9|ESCUELA KEMPER URGATE|601|URE180429TM6|UNIVERSIDAD ROBOTICA ESPAÑOLA|65000|601|G01|50211503|131494-1055|2|H87|Pieza|Cigarros|200.00|400.00|1|02|1|002|Tasa|0.160000|0.16|1|001|Tasa|0.100000|0.00|1|002|Tasa|0.106666|0.00|001|0.00|002|0.00|0.00|1|002|Tasa|0.160000|0.16|0.16|1.1|2|A1|0|FOB|0|15.6446|25.56|CALLE DEL PAPEL|0214|01|014|QUE|MEX|76199|CALLE DEL PAPEL|0214|01|014|QUE|MEX|76199|131494-1055|2402200100|117.64|01|12.78|25.56||"), cadenaComercioExterior);
            Assert.True(cadenaIngresoCartaPorte.Equals("||4.0|Serie|Folio|2022-01-31T00:18:10|99||CondicionesDePago|200|1|AMD|1|199.16|I|01|PPD|20000|EKU9003173C9|ESCUELA KEMPER URGATE|601|URE180429TM6|UNIVERSIDAD ROBOTICA ESPAÑOLA|65000|601|G01|78101500|1|H87|Pieza|Cigarros|200.00|200.00|1|02|1|002|Tasa|0.160000|0.16|1|001|Tasa|0.100000|0.00|1|002|Tasa|0.106666|0.00|001|0.00|002|0.00|0.00|1|002|Tasa|0.160000|0.16|0.16|2.0|No|2|Origen|OR101010|EKU9003173C9|2021-11-01T00:00:00|calle|211|0347|23|casa blanca 1|004|COA|MEX|25350|Destino|DE202020|AAA010101AAA|2021-11-01T01:00:00|1|calle|214|0347|23|casa blanca 2|004|COA|MEX|25350|Destino|DE202021|AAA010101AAA|2021-11-01T02:00:00|1|calle|220|0347|23|casa blanca 3|004|COA|MEX|25350|2.0|XBX|2|11121900|Productos de perfumería|1.0|XBX|Sí|1266|4H2|1.0|1|OR101010|DE202020|11121900|Productos de perfumería|1.0|XBX|Sí|1266|4H2|1.0|1|OR101010|DE202021|TPAF01|NumPermisoSCT|VL|plac892|2020|SW Seguros|123456789|SW Seguros Ambientales|123456789|SW Seguros|CTR021|ABC123|01|VAAM130719H60|a234567890||"), cadenaIngresoCartaPorte);
            Assert.True(cadenaTrasladoCartaPorte.Equals("||4.0|Serie|Folio|2022-02-23T00:18:10||CondicionesDePago|0|0|XXX|0|T|01|20000|EKU9003173C9|ESCUELA KEMPER URGATE|601|EKU9003173C9|ESCUELA KEMPER URGATE|26015|601|S01|50211503|UT421511|1|H87|Pieza|Cigarros|0.00|0.00|01|21 47 3807 8003832|50211503|123|1|Pieza|cosas|200.00|200.00|2.0|No|1|Origen|OR101010|EKU9003173C9|2021-11-01T00:00:00|calle|211|0347|23|casa blanca|004|COA|MEX|25350|Destino|DE202020|AAA010101AAA|2021-11-01T01:00:00|1|calle|214|0347|23|casa blanca|004|COA|MEX|25350|1.0|XBX|1|11121900|Accesorios de equipo de telefonía|1.0|XBX|No|1.0|1|OR101010|DE202020|TPAF01|NumPermisoSCT|VL|plac892|2020|SW Seguros|123456789|SW Seguros|CTR004|VL45K98|01|VAAM130719H60|a234567890||"), cadenaTrasladoCartaPorte);
        }

        /// <summary>
        /// Generar cadena original de varios CFDI 4.0 especificando la versión
        /// </summary>
        [Fact]
        public void UT_CadenaOriginal_CFDI40_ConVersion()
        {
            string xmlIngreso = Encoding.UTF8.GetString(File.ReadAllBytes("Resources/CFDI40/CFDI40_Ingreso.xml"));
            string cadenaIngreso = CadenaOriginal.CadenaOriginalCFDI(xmlIngreso, "4.0");

            string xmlEgreso = Encoding.UTF8.GetString(File.ReadAllBytes("Resources/CFDI40/CFDI40_Egreso.xml"));
            string cadenaEgreso = CadenaOriginal.CadenaOriginalCFDI(xmlEgreso, "4.0");

            string xmlPago = Encoding.UTF8.GetString(File.ReadAllBytes("Resources/CFDI40/CFDI40_Pago.xml"));
            string cadenaPago = CadenaOriginal.CadenaOriginalCFDI(xmlPago, "4.0");

            string xmlTraslado = Encoding.UTF8.GetString(File.ReadAllBytes("Resources/CFDI40/CFDI40_Traslado.xml"));
            string cadenaTraslado = CadenaOriginal.CadenaOriginalCFDI(xmlTraslado, "4.0");

            string xmlNomina = Encoding.UTF8.GetString(File.ReadAllBytes("Resources/CFDI40/CFDI40_Nomina.xml"));
            string cadenaNomina = CadenaOriginal.CadenaOriginalCFDI(xmlNomina, "4.0");

            string xmlComercioExterior = Encoding.UTF8.GetString(File.ReadAllBytes("Resources/CFDI40/CFDI40_ComercioExterior.xml"));
            string cadenaComercioExterior = CadenaOriginal.CadenaOriginalCFDI(xmlComercioExterior, "4.0");

            string xmlIngresoCartaPorte = Encoding.UTF8.GetString(File.ReadAllBytes("Resources/CFDI40/CFDI40_Ingreso_CartaPorte_Autotransporte.xml"));
            string cadenaIngresoCartaPorte = CadenaOriginal.CadenaOriginalCFDI(xmlIngresoCartaPorte, "4.0");

            string xmlTrasladoCartaPorte = Encoding.UTF8.GetString(File.ReadAllBytes("Resources/CFDI40/CFDI40_Traslado_CartaPorte_Autotransporte.xml"));
            string cadenaTrasladoCartaPorte = CadenaOriginal.CadenaOriginalCFDI(xmlTrasladoCartaPorte, "4.0");

            Assert.True(cadenaIngreso.Equals("||4.0|Serie|Folio|2021-12-14T00:18:10|99||CondicionesDePago|200|1|AMD|1|199.16|I|01|PPD|20000|EKU9003173C9|ESCUELA KEMPER URGATE|601|URE180429TM6|UNIVERSIDAD ROBOTICA ESPAÑOLA|65000|601|G01|50211503|1|H87|Pieza|Cigarros|200.00|200.00|1|02|1|002|Tasa|0.160000|0.16|1|001|Tasa|0.100000|0.00|1|002|Tasa|0.106666|0.00|001|0.00|002|0.00|0.00|1|002|Tasa|0.160000|0.16|0.16||"), cadenaIngreso);
            Assert.True(cadenaEgreso.Equals("||4.0|Serie|Folio|2022-01-30T00:18:10||CondicionesDePago|10.00|0|AMD|1|11.60|E|01|20000|01|1fac4464-1111-0000-1111-cd37179db12e|EKU9003173C9|ESCUELA KEMPER URGATE|601|URE180429TM6|UNIVERSIDAD ROBOTICA ESPAÑOLA|65000|601|P01|84111506|1.0|ACT|NC por devolucion|10.00|10.00|0.00|02|10.00|002|Tasa|0.160000|1.6|10.00|002|Tasa|0.160000|1.6|1.6||"), cadenaEgreso);
            Assert.True(cadenaPago.Equals("||4.0|Serie|Folio|2022-03-29T00:18:10||0|XXX|0.00|P|01|20000|EKU9003173C9|ESCUELA KEMPER URGATE|601|URE180429TM6|UNIVERSIDAD ROBOTICA ESPAÑOLA|65000|601|CP01|84111506|1|ACT|Pago|0|0|01|2.0|200.00|2021-12-15T00:00:00|01|MXN|1|200.00|bfc36522-4b8e-45c4-8f14-d11b289f9eb7|MXN|1|1|200.00|200.00|0.00|01||"), cadenaPago);
            Assert.True(cadenaTraslado.Equals("||4.0|Serie|Folio|2022-02-23T00:18:10||CondicionesDePago|0|0|AMD|1|0|T|01|20000|EKU9003173C9|ESCUELA KEMPER URGATE|601|EKU9003173C9|ESCUELA KEMPER URGATE|26015|601|G01|50211503|UT421511|1|H87|Pieza|Cigarros|0.00|0.00|01|21 47 3807 8003832|50211503|123|1|Pieza|cosas|200.00|200.00||"), cadenaTraslado);
            Assert.True(cadenaNomina.Equals("||4.0|Serie|Folio|2022-03-28T00:00:00|30001000000400002444|CondicionesDePago|5000|300|MXN|1|4700|N|01|PPD|20000|EKU9003173C9|ESCUELA KEMPER URGATE|601|XOJI740919U48|INGRID XODAR JIMENEZ|88965|605|CN01|84111505|1|ACT|Pago de nómina|5000.00|5000.00|300|01|1.2|O|2021-12-24|2021-12-09|2021-12-24|15|5000.0|300|B5510768108|URE180429TM6|BADD110313HCMLNS09|000000|2015-01-01|P364W|01|01|03|120|Desarrollo|Ingeniero de Software|1|04|072320002084170154|490.22|146.47|JAL|5000.0|2808.8|2191.2|001|00500|Sueldos, Salarios Rayas y Jornales|2808.8|2191.2|200|100|001|00301|Seguridad Social|200|002|00302|ISR|100||"), cadenaNomina);
            Assert.True(cadenaComercioExterior.Equals("||4.0|Serie|Folio|2022-02-14T00:18:00|99|30001000000400002434|CondicionesDePago|400|1|AMD|1|399.16|I|02|PPD|20000|EKU9003173C9|ESCUELA KEMPER URGATE|601|URE180429TM6|UNIVERSIDAD ROBOTICA ESPAÑOLA|65000|601|G01|50211503|131494-1055|2|H87|Pieza|Cigarros|200.00|400.00|1|02|1|002|Tasa|0.160000|0.16|1|001|Tasa|0.100000|0.00|1|002|Tasa|0.106666|0.00|001|0.00|002|0.00|0.00|1|002|Tasa|0.160000|0.16|0.16|1.1|2|A1|0|FOB|0|15.6446|25.56|CALLE DEL PAPEL|0214|01|014|QUE|MEX|76199|CALLE DEL PAPEL|0214|01|014|QUE|MEX|76199|131494-1055|2402200100|117.64|01|12.78|25.56||"), cadenaComercioExterior);
            Assert.True(cadenaIngresoCartaPorte.Equals("||4.0|Serie|Folio|2022-01-31T00:18:10|99||CondicionesDePago|200|1|AMD|1|199.16|I|01|PPD|20000|EKU9003173C9|ESCUELA KEMPER URGATE|601|URE180429TM6|UNIVERSIDAD ROBOTICA ESPAÑOLA|65000|601|G01|78101500|1|H87|Pieza|Cigarros|200.00|200.00|1|02|1|002|Tasa|0.160000|0.16|1|001|Tasa|0.100000|0.00|1|002|Tasa|0.106666|0.00|001|0.00|002|0.00|0.00|1|002|Tasa|0.160000|0.16|0.16|2.0|No|2|Origen|OR101010|EKU9003173C9|2021-11-01T00:00:00|calle|211|0347|23|casa blanca 1|004|COA|MEX|25350|Destino|DE202020|AAA010101AAA|2021-11-01T01:00:00|1|calle|214|0347|23|casa blanca 2|004|COA|MEX|25350|Destino|DE202021|AAA010101AAA|2021-11-01T02:00:00|1|calle|220|0347|23|casa blanca 3|004|COA|MEX|25350|2.0|XBX|2|11121900|Productos de perfumería|1.0|XBX|Sí|1266|4H2|1.0|1|OR101010|DE202020|11121900|Productos de perfumería|1.0|XBX|Sí|1266|4H2|1.0|1|OR101010|DE202021|TPAF01|NumPermisoSCT|VL|plac892|2020|SW Seguros|123456789|SW Seguros Ambientales|123456789|SW Seguros|CTR021|ABC123|01|VAAM130719H60|a234567890||"), cadenaIngresoCartaPorte);
            Assert.True(cadenaTrasladoCartaPorte.Equals("||4.0|Serie|Folio|2022-02-23T00:18:10||CondicionesDePago|0|0|XXX|0|T|01|20000|EKU9003173C9|ESCUELA KEMPER URGATE|601|EKU9003173C9|ESCUELA KEMPER URGATE|26015|601|S01|50211503|UT421511|1|H87|Pieza|Cigarros|0.00|0.00|01|21 47 3807 8003832|50211503|123|1|Pieza|cosas|200.00|200.00|2.0|No|1|Origen|OR101010|EKU9003173C9|2021-11-01T00:00:00|calle|211|0347|23|casa blanca|004|COA|MEX|25350|Destino|DE202020|AAA010101AAA|2021-11-01T01:00:00|1|calle|214|0347|23|casa blanca|004|COA|MEX|25350|1.0|XBX|1|11121900|Accesorios de equipo de telefonía|1.0|XBX|No|1.0|1|OR101010|DE202020|TPAF01|NumPermisoSCT|VL|plac892|2020|SW Seguros|123456789|SW Seguros|CTR004|VL45K98|01|VAAM130719H60|a234567890||"), cadenaTrasladoCartaPorte);
        }

        /// <summary>
        /// Generar cadena original de varios CFDI 4.0 sin especificar la versión y especificando la versión
        /// </summary>
        [Fact]
        public void UT_CadenaOriginal_CFDI40_Versiones()
        {
            string xmlIngreso = Encoding.UTF8.GetString(File.ReadAllBytes("Resources/CFDI40/CFDI40_Ingreso.xml"));
            string cadenaIngreso = CadenaOriginal.CadenaOriginalCFDI(xmlIngreso);

            string xmlEgreso = Encoding.UTF8.GetString(File.ReadAllBytes("Resources/CFDI40/CFDI40_Egreso.xml"));
            string cadenaEgreso = CadenaOriginal.CadenaOriginalCFDI(xmlEgreso, "4.0");

            string xmlPago = Encoding.UTF8.GetString(File.ReadAllBytes("Resources/CFDI40/CFDI40_Pago.xml"));
            string cadenaPago = CadenaOriginal.CadenaOriginalCFDI(xmlPago);

            string xmlTraslado = Encoding.UTF8.GetString(File.ReadAllBytes("Resources/CFDI40/CFDI40_Traslado.xml"));
            string cadenaTraslado = CadenaOriginal.CadenaOriginalCFDI(xmlTraslado, "4.0");

            string xmlNomina = Encoding.UTF8.GetString(File.ReadAllBytes("Resources/CFDI40/CFDI40_Nomina.xml"));
            string cadenaNomina = CadenaOriginal.CadenaOriginalCFDI(xmlNomina);

            string xmlComercioExterior = Encoding.UTF8.GetString(File.ReadAllBytes("Resources/CFDI40/CFDI40_ComercioExterior.xml"));
            string cadenaComercioExterior = CadenaOriginal.CadenaOriginalCFDI(xmlComercioExterior, "4.0");

            string xmlIngresoCartaPorte = Encoding.UTF8.GetString(File.ReadAllBytes("Resources/CFDI40/CFDI40_Ingreso_CartaPorte_Autotransporte.xml"));
            string cadenaIngresoCartaPorte = CadenaOriginal.CadenaOriginalCFDI(xmlIngresoCartaPorte);

            string xmlTrasladoCartaPorte = Encoding.UTF8.GetString(File.ReadAllBytes("Resources/CFDI40/CFDI40_Traslado_CartaPorte_Autotransporte.xml"));
            string cadenaTrasladoCartaPorte = CadenaOriginal.CadenaOriginalCFDI(xmlTrasladoCartaPorte, "4.0");

            Assert.True(cadenaIngreso.Equals("||4.0|Serie|Folio|2021-12-14T00:18:10|99||CondicionesDePago|200|1|AMD|1|199.16|I|01|PPD|20000|EKU9003173C9|ESCUELA KEMPER URGATE|601|URE180429TM6|UNIVERSIDAD ROBOTICA ESPAÑOLA|65000|601|G01|50211503|1|H87|Pieza|Cigarros|200.00|200.00|1|02|1|002|Tasa|0.160000|0.16|1|001|Tasa|0.100000|0.00|1|002|Tasa|0.106666|0.00|001|0.00|002|0.00|0.00|1|002|Tasa|0.160000|0.16|0.16||"), cadenaIngreso);
            Assert.True(cadenaEgreso.Equals("||4.0|Serie|Folio|2022-01-30T00:18:10||CondicionesDePago|10.00|0|AMD|1|11.60|E|01|20000|01|1fac4464-1111-0000-1111-cd37179db12e|EKU9003173C9|ESCUELA KEMPER URGATE|601|URE180429TM6|UNIVERSIDAD ROBOTICA ESPAÑOLA|65000|601|P01|84111506|1.0|ACT|NC por devolucion|10.00|10.00|0.00|02|10.00|002|Tasa|0.160000|1.6|10.00|002|Tasa|0.160000|1.6|1.6||"), cadenaEgreso);
            Assert.True(cadenaPago.Equals("||4.0|Serie|Folio|2022-03-29T00:18:10||0|XXX|0.00|P|01|20000|EKU9003173C9|ESCUELA KEMPER URGATE|601|URE180429TM6|UNIVERSIDAD ROBOTICA ESPAÑOLA|65000|601|CP01|84111506|1|ACT|Pago|0|0|01|2.0|200.00|2021-12-15T00:00:00|01|MXN|1|200.00|bfc36522-4b8e-45c4-8f14-d11b289f9eb7|MXN|1|1|200.00|200.00|0.00|01||"), cadenaPago);
            Assert.True(cadenaTraslado.Equals("||4.0|Serie|Folio|2022-02-23T00:18:10||CondicionesDePago|0|0|AMD|1|0|T|01|20000|EKU9003173C9|ESCUELA KEMPER URGATE|601|EKU9003173C9|ESCUELA KEMPER URGATE|26015|601|G01|50211503|UT421511|1|H87|Pieza|Cigarros|0.00|0.00|01|21 47 3807 8003832|50211503|123|1|Pieza|cosas|200.00|200.00||"), cadenaTraslado);
            Assert.True(cadenaNomina.Equals("||4.0|Serie|Folio|2022-03-28T00:00:00|30001000000400002444|CondicionesDePago|5000|300|MXN|1|4700|N|01|PPD|20000|EKU9003173C9|ESCUELA KEMPER URGATE|601|XOJI740919U48|INGRID XODAR JIMENEZ|88965|605|CN01|84111505|1|ACT|Pago de nómina|5000.00|5000.00|300|01|1.2|O|2021-12-24|2021-12-09|2021-12-24|15|5000.0|300|B5510768108|URE180429TM6|BADD110313HCMLNS09|000000|2015-01-01|P364W|01|01|03|120|Desarrollo|Ingeniero de Software|1|04|072320002084170154|490.22|146.47|JAL|5000.0|2808.8|2191.2|001|00500|Sueldos, Salarios Rayas y Jornales|2808.8|2191.2|200|100|001|00301|Seguridad Social|200|002|00302|ISR|100||"), cadenaNomina);
            Assert.True(cadenaComercioExterior.Equals("||4.0|Serie|Folio|2022-02-14T00:18:00|99|30001000000400002434|CondicionesDePago|400|1|AMD|1|399.16|I|02|PPD|20000|EKU9003173C9|ESCUELA KEMPER URGATE|601|URE180429TM6|UNIVERSIDAD ROBOTICA ESPAÑOLA|65000|601|G01|50211503|131494-1055|2|H87|Pieza|Cigarros|200.00|400.00|1|02|1|002|Tasa|0.160000|0.16|1|001|Tasa|0.100000|0.00|1|002|Tasa|0.106666|0.00|001|0.00|002|0.00|0.00|1|002|Tasa|0.160000|0.16|0.16|1.1|2|A1|0|FOB|0|15.6446|25.56|CALLE DEL PAPEL|0214|01|014|QUE|MEX|76199|CALLE DEL PAPEL|0214|01|014|QUE|MEX|76199|131494-1055|2402200100|117.64|01|12.78|25.56||"), cadenaComercioExterior);
            Assert.True(cadenaIngresoCartaPorte.Equals("||4.0|Serie|Folio|2022-01-31T00:18:10|99||CondicionesDePago|200|1|AMD|1|199.16|I|01|PPD|20000|EKU9003173C9|ESCUELA KEMPER URGATE|601|URE180429TM6|UNIVERSIDAD ROBOTICA ESPAÑOLA|65000|601|G01|78101500|1|H87|Pieza|Cigarros|200.00|200.00|1|02|1|002|Tasa|0.160000|0.16|1|001|Tasa|0.100000|0.00|1|002|Tasa|0.106666|0.00|001|0.00|002|0.00|0.00|1|002|Tasa|0.160000|0.16|0.16|2.0|No|2|Origen|OR101010|EKU9003173C9|2021-11-01T00:00:00|calle|211|0347|23|casa blanca 1|004|COA|MEX|25350|Destino|DE202020|AAA010101AAA|2021-11-01T01:00:00|1|calle|214|0347|23|casa blanca 2|004|COA|MEX|25350|Destino|DE202021|AAA010101AAA|2021-11-01T02:00:00|1|calle|220|0347|23|casa blanca 3|004|COA|MEX|25350|2.0|XBX|2|11121900|Productos de perfumería|1.0|XBX|Sí|1266|4H2|1.0|1|OR101010|DE202020|11121900|Productos de perfumería|1.0|XBX|Sí|1266|4H2|1.0|1|OR101010|DE202021|TPAF01|NumPermisoSCT|VL|plac892|2020|SW Seguros|123456789|SW Seguros Ambientales|123456789|SW Seguros|CTR021|ABC123|01|VAAM130719H60|a234567890||"), cadenaIngresoCartaPorte);
            Assert.True(cadenaTrasladoCartaPorte.Equals("||4.0|Serie|Folio|2022-02-23T00:18:10||CondicionesDePago|0|0|XXX|0|T|01|20000|EKU9003173C9|ESCUELA KEMPER URGATE|601|EKU9003173C9|ESCUELA KEMPER URGATE|26015|601|S01|50211503|UT421511|1|H87|Pieza|Cigarros|0.00|0.00|01|21 47 3807 8003832|50211503|123|1|Pieza|cosas|200.00|200.00|2.0|No|1|Origen|OR101010|EKU9003173C9|2021-11-01T00:00:00|calle|211|0347|23|casa blanca|004|COA|MEX|25350|Destino|DE202020|AAA010101AAA|2021-11-01T01:00:00|1|calle|214|0347|23|casa blanca|004|COA|MEX|25350|1.0|XBX|1|11121900|Accesorios de equipo de telefonía|1.0|XBX|No|1.0|1|OR101010|DE202020|TPAF01|NumPermisoSCT|VL|plac892|2020|SW Seguros|123456789|SW Seguros|CTR004|VL45K98|01|VAAM130719H60|a234567890||"), cadenaTrasladoCartaPorte);
        }
    }
}