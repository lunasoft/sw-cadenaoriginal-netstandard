
namespace sw_cadenaoriginal.Singleton
{
    internal class InstanceCadenaOriginal32
    {
        private static CadenaOriginal32 cadenaOriginal32 = null;

        public static CadenaOriginal32 getInstance()
        {
            if (cadenaOriginal32 == null)
                cadenaOriginal32 = new CadenaOriginal32();

            return cadenaOriginal32;
        }
    }
}
