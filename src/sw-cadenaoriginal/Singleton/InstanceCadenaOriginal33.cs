
namespace sw_cadenaoriginal.Singleton
{
    internal class InstanceCadenaOriginal33
    {
        private static CadenaOriginal33 cadenaOriginal33 = null;

        public static CadenaOriginal33 getInstance()
        {
            if (cadenaOriginal33 == null)
                cadenaOriginal33 = new CadenaOriginal33();

            return cadenaOriginal33;
        }
    }
}
