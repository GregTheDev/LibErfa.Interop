
namespace LibErfa.Interop
{
    public static partial class Erfa
    {
        /// <summary>
        /// Earth position and velocity
        /// </summary>
        /// <param name="date1">TDB date</param>
        /// <param name="date2">TDB date</param>
        /// <param name="pvh">Returned: double[2][3] heliocentric Earth position/velocity</param>
        /// <param name="pvb">Returned: double[2][3] barycentric Earth position/velocity</param>
        /// <returns>0 = OK, +1 = warning: date outside the range 1900-2100 AD</returns>
        /// <seealso href="http://www.iausofa.org/2023_1011_C/sofa/epv00.c"/>
        public static int epv00(double date1, double date2, double[,] pvh, double[,] pvb)
        {
            return NativeMethods.epv00(date1, date2, pvh, pvb);
        }

        /// <summary>
        /// Prepare for ICRS <-> CIRS, space, special
        /// </summary>
        /// <param name="date1">TDB as a 2-part Julian Date</param>
        /// <param name="date2">TDB as a 2-part Julian Date</param>
        /// <param name="pv">double[2][3] observer's geocentric pos/vel (m, m/s)</param>
        /// <param name="ebpv">double[2][3] Earth barycentric PV (au, au/day)</param>
        /// <param name="ehp">double[3]    Earth heliocentric P (au)</param>
        /// <param name="astrom">Returned: star-independent astrometry parameters</param>
        /// <seealso href="http://www.iausofa.org/2023_1011_C/sofa/apcs.c"/>
        public static void apcs(double date1, double date2, double[,] pv, double[,] ebpv, double[] ehp, ref Astrom astrom)
        {
            AstromInternal _astrom = new AstromInternal();

            NativeMethods.apcs(date1, date2, pv, ebpv, ehp, ref _astrom);

            astrom = MarshalFromAstromInternal(_astrom);
        }

        /// <summary>
        /// Quick CIRS -> ICRS
        /// </summary>
        /// <param name="ri">CIRS RA (radians)</param>
        /// <param name="di">CIRS Dec (radians)</param>
        /// <param name="astrom">star-independent astrometry parameters</param>
        /// <param name="rc">Returned: ICRS astrometric RA (radians)</param>
        /// <param name="dc">Returned: ICRS astrometric Dec (radians)</param>
        /// <seealso href="http://www.iausofa.org/2023_1011_C/sofa/aticq.c"/>
        public static void aticq(double ri, double di, ref Astrom astrom, ref double rc, ref double dc)
        {
            AstromInternal _astrom = new AstromInternal();

            NativeMethods.aticq(ri, di, ref _astrom, ref rc, ref dc);

            astrom = MarshalFromAstromInternal(_astrom);
        }

        /// <summary>
        /// Prepare for ICRS <-> CIRS, terrestrial
        /// </summary>
        /// <param name="date1">TDB as a 2-part Julian Date</param>
        /// <param name="date2">TDB as a 2-part Julian Date</param>
        /// <param name="astrom">Returned: star-independent astrometry parameters</param>
        /// <param name="eo">Returned: equation of the origins (ERA-GST, radians)</param>
        /// <seealso href="http://www.iausofa.org/2023_1011_C/sofa/apci13.c"/>
        public static void apci13(double date1, double date2, ref Astrom astrom, ref double eo)
        {
            AstromInternal _astrom = new AstromInternal();

            NativeMethods.apci13(date1, date2, ref _astrom, ref eo);

            astrom = MarshalFromAstromInternal(_astrom);
        }

        /// <summary>
        /// Prepare for ICRS <-> observed, terrestrial, special
        /// </summary>
        /// <param name="date1">TDB as a 2-part Julian Date</param>
        /// <param name="date2">TDB as a 2-part Julian Date</param>
        /// <param name="ebpv">double[2][3] Earth barycentric PV (au, au/day)</param>
        /// <param name="ehp">double[3]    Earth heliocentric P (au)</param>
        /// <param name="x">CIP X (components of unit vector)</param>
        /// <param name="y">CIP Y (components of unit vector)</param>
        /// <param name="s">the CIO locator s (radians)</param>
        /// <param name="theta">Earth rotation angle (radians)</param>
        /// <param name="elong">longitude (radians, east +ve)</param>
        /// <param name="phi">latitude (geodetic, radians)</param>
        /// <param name="hm">height above ellipsoid (m, geodetic)</param>
        /// <param name="xp">polar motion coordinates (radians)</param>
        /// <param name="yp">polar motion coordinates (radians)</param>
        /// <param name="sp">the TIO locator s' (radians)</param>
        /// <param name="refa">refraction constant A (radians)</param>
        /// <param name="refb">refraction constant B (radians)</param>
        /// <param name="astrom">Returned: star-independent astrometry parameters</param>
        /// <seealso href="http://www.iausofa.org/2023_1011_C/sofa/apco.c"/>
        public static void apco(double date1, double date2, double[,] ebpv, double[] ehp, double x, double y, double s, double theta, double elong, double phi, double hm, double xp, double yp, double sp, double refa, double refb, ref Astrom astrom)
        {
            AstromInternal _astrom = new AstromInternal();

            NativeMethods.apco(date1, date2, ebpv, ehp, x, y, s, theta, elong, phi, hm, xp, yp, sp, refa, refb, ref _astrom);

            astrom = MarshalFromAstromInternal(_astrom);
        }

        /// <summary>
        /// Quick astrometric ICRS -> CIRS
        /// </summary>
        /// <param name="rc">ICRS astrometric RA (radians)</param>
        /// <param name="dc">ICRS astrometric Dec (radians)</param>
        /// <param name="astrom">star-independent astrometry parameters</param>
        /// <param name="ri">Returned: CIRS RA (radians)</param>
        /// <param name="di">Returned: CIRS Dec (radians)</param>
        /// <seealso href="http://www.iausofa.org/2023_1011_C/sofa/atciqz.c"/>
        public static void atciqz(double rc, double dc, ref Astrom astrom, ref double ri, ref double di)
        {
            AstromInternal _astrom = MarshalToAstromInternal(astrom);

            NativeMethods.atciqz(rc, dc, ref _astrom, ref ri, ref di);

            astrom = MarshalFromAstromInternal(_astrom);
        }

        /// <summary>
        /// Quick CIRS -> observed
        /// </summary>
        /// <param name="ri">CIRS right ascension</param>
        /// <param name="di">CIRS declination</param>
        /// <param name="astrom">star-independent astrometry parameters</param>
        /// <param name="aob">Returned: observed azimuth (radians: N=0,E=90)</param>
        /// <param name="zob">Returned: observed zenith distance (radians)</param>
        /// <param name="hob">Returned: observed hour angle (radians)</param>
        /// <param name="dob">Returned: observed declination (radians)</param>
        /// <param name="rob">Returned: observed right ascension (CIO-based, radians)</param>
        /// <seealso href="http://www.iausofa.org/2023_1011_C/sofa/atioq.c"/>
        public static void atioq(double ri, double di, ref Astrom astrom, ref double aob, ref double zob, ref double hob, ref double dob, ref double rob)
        {
            AstromInternal _astrom = MarshalToAstromInternal(astrom);

            NativeMethods.atioq(ri, di, ref _astrom, ref aob, ref zob, ref hob, ref dob, ref rob);

            astrom = MarshalFromAstromInternal(_astrom);
        }

        /// <summary>
        /// Prepare for CIRS <-> observed, terrestrial
        /// </summary>
        /// <param name="utc1">UTC as a 2-part quasi Julian Date</param>
        /// <param name="utc2">UTC as a 2-part quasi Julian Date</param>
        /// <param name="dut1">UT1-UTC (seconds)</param>
        /// <param name="elong">longitude (radians, east +ve)</param>
        /// <param name="phi">geodetic latitude (radians)</param>
        /// <param name="hm">height above ellipsoid (m, geodetic)</param>
        /// <param name="xp">polar motion coordinates (radians)</param>
        /// <param name="yp">polar motion coordinates (radians)</param>
        /// <param name="phpa">pressure at the observer (hPa = mB)</param>
        /// <param name="tc">ambient temperature at the observer (deg C)</param>
        /// <param name="rh">relative humidity at the observer (range 0-1)</param>
        /// <param name="wl"> wavelength (micrometers)</param>
        /// <param name="astrom">Returned: star-independent astrometry parameters</param>
        /// <returns>0 = OK, +1 = dubious year, -1 = unacceptable date</returns>
        /// <seealso href="http://www.iausofa.org/2023_1011_C/sofa/apio13.c"/>
        public static int apio13(double utc1, double utc2, double dut1, double elong, double phi, double hm, double xp, double yp, double phpa, double tc, double rh, double wl, ref Astrom astrom)
        {
            AstromInternal _astrom = new AstromInternal();

            int result = NativeMethods.apio13(utc1, utc2, dut1, elong, phi, hm, xp, yp, phpa, tc, rh, wl, ref _astrom);

            astrom = MarshalFromAstromInternal(_astrom);

            return result;
        }

        /// <summary>
        /// Light deflection by a single solar-system body
        /// </summary>
        /// <param name="bm">mass of the gravitating body (solar masses)</param>
        /// <param name="p">double[3] direction from observer to source (unit vector)</param>
        /// <param name="q">double[3] direction from body to source (unit vector)</param>
        /// <param name="e">double[3] direction from body to observer (unit vector)</param>
        /// <param name="em">distance from body to observer (au)</param>
        /// <param name="dlim">deflection limiter</param>
        /// <param name="p1">double[3] observer to deflected source (unit vector)</param>
        /// <seealso href="http://www.iausofa.org/2023_1011_C/sofa/ld.c"/>
        public static void ld(double bm, double[] p, double[] q, double[] e, double em, double dlim, double[] p1)
        {
            NativeMethods.ld(bm, p, q, e, em, dlim, p1);
        }

        /// <summary>
        /// Unit vector to spherical
        /// </summary>
        /// <param name="p">double[3] p-vector</param>
        /// <param name="theta">Returned: longitude angle (radians)</param>
        /// <param name="phi">Returned: latitude angle (radians)</param>
        /// <seealso href="http://www.iausofa.org/2023_1011_C/sofa/c2s.c"/>
        public static void c2s(double[] p, ref double theta, ref double phi)
        {
            NativeMethods.c2s(p, ref theta, ref phi);
        }

        /// <summary>
        /// Spherical to unit vector
        /// </summary>
        /// <param name="theta">longitude angle (radians)</param>
        /// <param name="phi">latitude angle (radians)</param>
        /// <param name="c">Returned: double[3] direction cosines</param>
        public static void s2c(double theta, double phi, double[] c)
        {
            NativeMethods.s2c(theta, phi, c);
        }

        /// <summary>
        /// Product of transpose of r-matrix and p-vector
        /// </summary>
        /// <param name="r">double[3][3] r-matrix</param>
        /// <param name="p">double[3] p-vector</param>
        /// <param name="trp">double[3] r^T * p</param>
        /// <seealso href="http://www.iausofa.org/2023_1011_C/sofa/trxp.c"/>
        public static void trxp(double[,] r, double[] p, double[] trp)
        {
            NativeMethods.trxp(r, p, trp);
        }

        /// <summary>
        /// Apply stellar aberration
        /// </summary>
        /// <param name="pnat">double[3] natural direction to the source (unit vector)</param>
        /// <param name="v">double[3] observer barycentric velocity in units of c</param>
        /// <param name="s">distance between the Sun and the observer (au)</param>
        /// <param name="bm1">sqrt(1-|v|^2): reciprocal of Lorenz factor</param>
        /// <param name="ppr">Returned: double[3] proper direction to source (unit vector)</param>
        /// <seealso href="http://www.iausofa.org/2023_1011_C/sofa/ab.c"/>
        public static void ab(double[] pnat, double[] v, double s, double bm1, double[] ppr)
        {
            NativeMethods.ab(pnat, v, s, bm1, ppr);
        }

        /// <summary>
        /// Normalize p-vector returning modulus
        /// </summary>
        /// <param name="p">double[3] p-vector</param>
        /// <param name="r">Returned: modulus</param>
        /// <param name="u">Returned: double[3] unit vector</param>
        /// <seealso href="http://www.iausofa.org/2023_1011_C/sofa/pn.c"/>
        public static void pn(double[] p, ref double r, double[] u)
        {
            NativeMethods.pn(p, ref r, u);
        }

        private static Astrom MarshalFromAstromInternal(AstromInternal astromInternal)
        {
            Astrom retVal = new Astrom();
            retVal.eb = new double[3];
            retVal.eh = new double[3];
            retVal.v = new double[3];
            retVal.bpn = new double[3, 3];

            retVal.pmt = astromInternal.pmt;
            retVal.eb = astromInternal.eb;
            retVal.eh = astromInternal.eh;
            retVal.em = astromInternal.em;
            retVal.v = astromInternal.v;
            retVal.bm1 = astromInternal.bm1;

            retVal.bpn[0, 0] = astromInternal.bpn[0];
            retVal.bpn[0, 1] = astromInternal.bpn[1];
            retVal.bpn[0, 2] = astromInternal.bpn[2];

            retVal.bpn[1, 0] = astromInternal.bpn[3];
            retVal.bpn[1, 1] = astromInternal.bpn[4];
            retVal.bpn[1, 2] = astromInternal.bpn[5];

            retVal.bpn[2, 0] = astromInternal.bpn[6];
            retVal.bpn[2, 1] = astromInternal.bpn[7];
            retVal.bpn[2, 2] = astromInternal.bpn[8];

            retVal.along = astromInternal.along;
            retVal.phi = astromInternal.phi;
            retVal.xpl = astromInternal.xpl;
            retVal.ypl = astromInternal.ypl;
            retVal.sphi = astromInternal.sphi;
            retVal.cphi = astromInternal.cphi;
            retVal.diurab = astromInternal.diurab;
            retVal.eral = astromInternal.eral;
            retVal.refa = astromInternal.refa;
            retVal.refb = astromInternal.refb;

            return retVal;
        }

        private static AstromInternal MarshalToAstromInternal(Astrom astrom)
        {
            AstromInternal retVal = new AstromInternal();
            retVal.eb = new double[3];
            retVal.eh = new double[3];
            retVal.v = new double[3];
            retVal.bpn = new double[9];

            retVal.pmt = astrom.pmt;
            retVal.eb = astrom.eb;
            retVal.eh = astrom.eh;
            retVal.em = astrom.em;
            retVal.v = astrom.v;
            retVal.bm1 = astrom.bm1;

            retVal.bpn[0] = astrom.bpn[0, 0];
            retVal.bpn[1] = astrom.bpn[0, 1];
            retVal.bpn[2] = astrom.bpn[0, 2];

            retVal.bpn[3] = astrom.bpn[1, 0];
            retVal.bpn[4] = astrom.bpn[1, 1];
            retVal.bpn[5] = astrom.bpn[1, 2];

            retVal.bpn[6] = astrom.bpn[2, 0];
            retVal.bpn[7] = astrom.bpn[2, 1];
            retVal.bpn[8] = astrom.bpn[2, 2];

            retVal.along = astrom.along;
            retVal.phi = astrom.phi;
            retVal.xpl = astrom.xpl;
            retVal.ypl = astrom.ypl;
            retVal.sphi = astrom.sphi;
            retVal.cphi = astrom.cphi;
            retVal.diurab = astrom.diurab;
            retVal.eral = astrom.eral;
            retVal.refa = astrom.refa;
            retVal.refb = astrom.refb;

            return retVal;
        }
    }
}
