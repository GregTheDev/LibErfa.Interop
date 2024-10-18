using LibErfa.Interop;

namespace SampleClassLibrary
{
    public class ErfaLib
    {
        public static (double theta, double phi) c2s()
        {
            double[] p = new double[3];
            double theta = 0;
            double phi = 0;

            p[0] = 100.0;
            p[1] = -50.0;
            p[2] = 25.0;

            Erfa.c2s(p, ref theta, ref phi);

            return (theta, phi);
        }
    }
}
