using System.Runtime.InteropServices;

namespace LibErfa.Interop
{
    public struct Astrom
    {
        public double pmt { get; set; }        /* PM time interval (SSB, Julian years) */
        public double[] eb { get; set; }      /* SSB to observer (vector, au) */
        public double[] eh { get; set; }      /* Sun to observer (unit vector) */
        public double em { get; set; }         /* distance from Sun to observer (au) */
        public double[] v { get; set; }       /* barycentric observer velocity (vector, c) */
        public double bm1 { get; set; }        /* sqrt(1-|v|^2): reciprocal of Lorenz factor */
        // 3 * 3
        public double[,] bpn { get; set; }    /* bias-precession-nutation matrix */
        public double along { get; set; }      /* longitude + s' + dERA(DUT) (radians) */
        public double phi { get; set; }        /* geodetic latitude (radians) */
        public double xpl { get; set; }        /* polar motion xp wrt local meridian (radians) */
        public double ypl { get; set; }        /* polar motion yp wrt local meridian (radians) */
        public double sphi { get; set; }       /* sine of geodetic latitude */
        public double cphi { get; set; }       /* cosine of geodetic latitude */
        public double diurab { get; set; }     /* magnitude of diurnal aberration vector */
        public double eral { get; set; }       /* "local" Earth rotation angle (radians) */
        public double refa { get; set; }       /* refraction constant A (radians) */
        public double refb { get; set; }       /* refraction constant B (radians) */
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct AstromInternal
    {
        public double pmt;        /* PM time interval (SSB, Julian years) */
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.R8, SizeConst = 3)]
        public double[] eb;      /* SSB to observer (vector, au) */
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.R8, SizeConst = 3)]
        public double[] eh;      /* Sun to observer (unit vector) */
        public double em;         /* distance from Sun to observer (au) */
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.R8, SizeConst = 3)]
        public double[] v;       /* barycentric observer velocity (vector, c) */
        public double bm1;        /* sqrt(1-|v|^2): reciprocal of Lorenz factor */
        // 3 * 3
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.R8, SizeConst = 9)]
        public double[] bpn;  /* bias-precession-nutation matrix */
        public double along;      /* longitude + s' + dERA(DUT) (radians) */
        public double phi;        /* geodetic latitude (radians) */
        public double xpl;        /* polar motion xp wrt local meridian (radians) */
        public double ypl;        /* polar motion yp wrt local meridian (radians) */
        public double sphi;       /* sine of geodetic latitude */
        public double cphi;       /* cosine of geodetic latitude */
        public double diurab;     /* magnitude of diurnal aberration vector */
        public double eral;       /* "local" Earth rotation angle (radians) */
        public double refa;       /* refraction constant A (radians) */
        public double refb;       /* refraction constant B (radians) */
    }
}