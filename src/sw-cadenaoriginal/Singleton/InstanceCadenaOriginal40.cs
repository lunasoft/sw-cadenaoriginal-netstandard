
namespace sw_cadenaoriginal.Singleton
{
    internal class InstanceCadenaOriginal40
    {
        private static CadenaOriginal40 cadenaOriginal40 = null;

        public static CadenaOriginal40 getInstance()
        {
            if (cadenaOriginal40 == null)
                cadenaOriginal40 = new CadenaOriginal40();

            return cadenaOriginal40;
        }
    }
}
