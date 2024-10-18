using System.Runtime.InteropServices;

namespace LibErfa.Interop
{
    internal sealed class NativeMethods
    {
        [DllImport("liberfa", EntryPoint = "eraEpv00")]
        internal static extern int epv00(double date1, double date2, double[,] pvh, double[,] pvb);

        [DllImport("liberfa", EntryPoint = "eraApcs")]
        internal static extern void apcs(double date1, double date2, double[,] pv, double[,] ebpv, double[] ehp, ref AstromInternal astrom);

        [DllImport("liberfa", EntryPoint = "eraAticq")]
        internal static extern void aticq(double ri, double di, ref AstromInternal astrom, ref double rc, ref double dc);

        [DllImport("liberfa", EntryPoint = "eraApci13")]
        internal static extern void apci13(double date1, double date2, ref AstromInternal astrom, ref double eo);

        [DllImport("liberfa", EntryPoint = "eraApco")]
        internal static extern void apco(double date1, double date2, double[,] ebpv, double[] ehp, double x, double y, double s, double theta, double elong, double phi, double hm, double xp, double yp, double sp, double refa, double refb, ref AstromInternal astrom);

        [DllImport("liberfa", EntryPoint = "eraAtciqz")]
        internal static extern void atciqz(double rc, double dc, ref AstromInternal astrom, ref double ri, ref double di);

        [DllImport("liberfa", EntryPoint = "eraAtioq")]
        internal static extern void atioq(double ri, double di, ref AstromInternal astrom, ref double aob, ref double zob, ref double hob, ref double dob, ref double rob);

        [DllImport("liberfa", EntryPoint = "eraApio13")]
        internal static extern int apio13(double utc1, double utc2, double dut1, double elong, double phi, double hm, double xp, double yp, double phpa, double tc, double rh, double wl, ref AstromInternal astrom);

        [DllImport("liberfa", EntryPoint = "eraLd")]
        internal static extern void ld(double bm, double[] p, double[] q, double[] e, double em, double dlim, double[] p1);

        [DllImport("liberfa", EntryPoint = "eraC2s")]
        internal static extern void c2s(double[] p, ref double theta, ref double phi);

        [DllImport("liberfa", EntryPoint = "eraS2c")]
        internal static extern void s2c(double theta, double phi, double[] c);

        [DllImport("liberfa", EntryPoint = "eraTrxp")]
        internal static extern void trxp(double[,] r, double[] p, double[] trp);

        [DllImport("liberfa", EntryPoint = "eraAb")]
        internal static extern void ab(double[] pnat, double[] v, double s, double bm1, double[] ppr);

        [DllImport("liberfa", EntryPoint = "eraPn")]
        internal static extern void pn(double[] p, ref double r, double[] u);
    }
}
