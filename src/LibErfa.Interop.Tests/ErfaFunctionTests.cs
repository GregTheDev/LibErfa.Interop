using NUnit.Framework;
using NUnit.Framework.Internal;
using System;

namespace LibErfa.Interop.Tests
{
    [TestFixture]
    public class ErfaFunctionTests
    {
        private int status = 0;

        [Test] 
        public void epv00() 
        {
            double[,] pvh = new double[2, 3];
            double[,] pvb = new double[2, 3];
            int j;

            j = Erfa.epv00(2400000.5, 53411.52501161, pvh, pvb);

            vvd(pvh[0, 0], -0.7757238809297706813, 1e-14,
                "eraEpv00", "ph(x)", status);
            vvd(pvh[0, 1], 0.5598052241363340596, 1e-14,
                "eraEpv00", "ph(y)", status);
            vvd(pvh[0, 2], 0.2426998466481686993, 1e-14,
                "eraEpv00", "ph(z)", status);

            vvd(pvh[1, 0], -0.1091891824147313846e-1, 1e-15,
                "eraEpv00", "vh(x)", status);
            vvd(pvh[1, 1], -0.1247187268440845008e-1, 1e-15,
                "eraEpv00", "vh(y)", status);
            vvd(pvh[1, 2], -0.5407569418065039061e-2, 1e-15,
                "eraEpv00", "vh(z)", status);

            vvd(pvb[0, 0], -0.7714104440491111971, 1e-14,
                  "eraEpv00", "pb(x)", status);
            vvd(pvb[0, 1], 0.5598412061824171323, 1e-14,
                "eraEpv00", "pb(y)", status);
            vvd(pvb[0, 2], 0.2425996277722452400, 1e-14,
                "eraEpv00", "pb(z)", status);

            vvd(pvb[1, 0], -0.1091874268116823295e-1, 1e-15,
                "eraEpv00", "vb(x)", status);
            vvd(pvb[1, 1], -0.1246525461732861538e-1, 1e-15,
                "eraEpv00", "vb(y)", status);
            vvd(pvb[1, 2], -0.5404773180966231279e-2, 1e-15,
                "eraEpv00", "vb(z)", status);

            //viv(j, 0, "eraEpv00", "j", status);

            Assert.Pass();
        }

        [Test]
        public void apcs()
        {
            double date1, date2;
            double[,] pv = new double[2, 3];
            double[,] ebpv = new double[2, 3];
            double[] ehp = new double[3];
            Astrom astrom = new();
            astrom.eb = new double[3];
            astrom.eh = new double[3];
            astrom.v = new double[3];
            astrom.bpn = new double[3, 3];

            date1 = 2456384.5;
            date2 = 0.970031644;
            pv[0, 0] = -1836024.09;
            pv[0, 1] = 1056607.72;
            pv[0, 2] = -5998795.26;
            pv[1, 0] = -77.0361767;
            pv[1, 1] = -133.310856;
            pv[1, 2] = 0.0971855934;
            ebpv[0, 0] = -0.974170438;
            ebpv[0, 1] = -0.211520082;
            ebpv[0, 2] = -0.0917583024;
            ebpv[1, 0] = 0.00364365824;
            ebpv[1, 1] = -0.0154287319;
            ebpv[1, 2] = -0.00668922024;
            ehp[0] = -0.973458265;
            ehp[1] = -0.209215307;
            ehp[2] = -0.0906996477;

            Erfa.apcs(date1, date2, pv, ebpv, ehp, ref astrom);

            vvd(astrom.pmt, 13.25248468622587269, 1e-11,
                              "eraApcs", "pmt", status);
            vvd(astrom.eb[0], -0.9741827110629881886, 1e-12,
                              "eraApcs", "eb(1)", status);
            vvd(astrom.eb[1], -0.2115130190136415986, 1e-12,
                              "eraApcs", "eb(2)", status);
            vvd(astrom.eb[2], -0.09179840186954412099, 1e-12,
                              "eraApcs", "eb(3)", status);
            vvd(astrom.eh[0], -0.9736425571689454706, 1e-12,
                              "eraApcs", "eh(1)", status);
            vvd(astrom.eh[1], -0.2092452125850435930, 1e-12,
                              "eraApcs", "eh(2)", status);
            vvd(astrom.eh[2], -0.09075578152248299218, 1e-12,
                              "eraApcs", "eh(3)", status);
            vvd(astrom.em, 0.9998233241709796859, 1e-12,
                           "eraApcs", "em", status);
            vvd(astrom.v[0], 0.2078704993282685510e-4, 1e-16,
                             "eraApcs", "v(1)", status);
            vvd(astrom.v[1], -0.8955360106989405683e-4, 1e-16,
                             "eraApcs", "v(2)", status);
            vvd(astrom.v[2], -0.3863338994289409097e-4, 1e-16,
                             "eraApcs", "v(3)", status);
            vvd(astrom.bm1, 0.9999999950277561237, 1e-12,
                            "eraApcs", "bm1", status);
            vvd(astrom.bpn[0, 0], 1, 0,
                                  "eraApcs", "bpn(1,1)", status);
            vvd(astrom.bpn[1, 0], 0, 0,
                                  "eraApcs", "bpn(2,1)", status);
            vvd(astrom.bpn[2, 0], 0, 0,
                                  "eraApcs", "bpn(3,1)", status);
            vvd(astrom.bpn[0, 1], 0, 0,
                                  "eraApcs", "bpn(1,2)", status);
            vvd(astrom.bpn[1, 1], 1, 0,
                                  "eraApcs", "bpn(2,2)", status);
            vvd(astrom.bpn[2, 1], 0, 0,
                                  "eraApcs", "bpn(3,2)", status);
            vvd(astrom.bpn[0, 2], 0, 0,
                                  "eraApcs", "bpn(1,3)", status);
            vvd(astrom.bpn[1, 2], 0, 0,
                                  "eraApcs", "bpn(2,3)", status);
            vvd(astrom.bpn[2, 2], 1, 0,
                                  "eraApcs", "bpn(3,3)", status);

            Assert.Pass();
        }

        [Test]
        public void aticq()
        {
            double date1, date2, ri, di;
            double rc = 0;
            double dc = 0;
            double eo = 0;
            Astrom astrom = new();


            date1 = 2456165.5;
            date2 = 0.401182685;
            Erfa.apci13(date1, date2, ref astrom, ref eo);
            ri = 2.710121572969038991;
            di = 0.1729371367218230438;

            Erfa.aticq(ri, di, ref astrom, ref rc, ref dc);

            vvd(rc, 2.710126504531716819, 1e-12, "eraAticq", "rc", status);
            vvd(dc, 0.1740632537627034482, 1e-12, "eraAticq", "dc", status);

            Assert.Pass();
        }

        [Test]
        public void apco()
        {
            double date1, date2;
            double[,] ebpv = new double[2, 3];
            double[] ehp = new double[3];
            double x, y, s;
            double theta, elong, phi, hm, xp, yp, sp, refa, refb;
            Astrom astrom = new();


            date1 = 2456384.5;
            date2 = 0.970031644;
            ebpv[0, 0] = -0.974170438;
            ebpv[0, 1] = -0.211520082;
            ebpv[0, 2] = -0.0917583024;
            ebpv[1, 0] = 0.00364365824;
            ebpv[1, 1] = -0.0154287319;
            ebpv[1, 2] = -0.00668922024;
            ehp[0] = -0.973458265;
            ehp[1] = -0.209215307;
            ehp[2] = -0.0906996477;
            x = 0.0013122272;
            y = -2.92808623e-5;
            s = 3.05749468e-8;
            theta = 3.14540971;
            elong = -0.527800806;
            phi = -1.2345856;
            hm = 2738.0;
            xp = 2.47230737e-7;
            yp = 1.82640464e-6;
            sp = -3.01974337e-11;
            refa = 0.000201418779;
            refb = -2.36140831e-7;

            Erfa.apco(date1, date2, ebpv, ehp, x, y, s,
                    theta, elong, phi, hm, xp, yp, sp,
                    refa, refb, ref astrom);

            vvd(astrom.pmt, 13.25248468622587269, 1e-11,
                            "eraApco", "pmt", status);
            vvd(astrom.eb[0], -0.9741827110630322720, 1e-12,
                              "eraApco", "eb(1)", status);
            vvd(astrom.eb[1], -0.2115130190135344832, 1e-12,
                              "eraApco", "eb(2)", status);
            vvd(astrom.eb[2], -0.09179840186949532298, 1e-12,
                              "eraApco", "eb(3)", status);
            vvd(astrom.eh[0], -0.9736425571689739035, 1e-12,
                              "eraApco", "eh(1)", status);
            vvd(astrom.eh[1], -0.2092452125849330936, 1e-12,
                              "eraApco", "eh(2)", status);
            vvd(astrom.eh[2], -0.09075578152243272599, 1e-12,
                              "eraApco", "eh(3)", status);
            vvd(astrom.em, 0.9998233241709957653, 1e-12,
                           "eraApco", "em", status);
            vvd(astrom.v[0], 0.2078704992916728762e-4, 1e-16,
                             "eraApco", "v(1)", status);
            vvd(astrom.v[1], -0.8955360107151952319e-4, 1e-16,
                             "eraApco", "v(2)", status);
            vvd(astrom.v[2], -0.3863338994288951082e-4, 1e-16,
                             "eraApco", "v(3)", status);
            vvd(astrom.bm1, 0.9999999950277561236, 1e-12,
                            "eraApco", "bm1", status);
            vvd(astrom.bpn[0, 0], 0.9999991390295159156, 1e-12,
                                  "eraApco", "bpn(1,1)", status);
            vvd(astrom.bpn[1, 0], 0.4978650072505016932e-7, 1e-12,
                                  "eraApco", "bpn(2,1)", status);
            vvd(astrom.bpn[2, 0], 0.1312227200000000000e-2, 1e-12,
                                  "eraApco", "bpn(3,1)", status);
            vvd(astrom.bpn[0, 1], -0.1136336653771609630e-7, 1e-12,
                                  "eraApco", "bpn(1,2)", status);
            vvd(astrom.bpn[1, 1], 0.9999999995713154868, 1e-12,
                                  "eraApco", "bpn(2,2)", status);
            vvd(astrom.bpn[2, 1], -0.2928086230000000000e-4, 1e-12,
                                  "eraApco", "bpn(3,2)", status);
            vvd(astrom.bpn[0, 2], -0.1312227200895260194e-2, 1e-12,
                                  "eraApco", "bpn(1,3)", status);
            vvd(astrom.bpn[1, 2], 0.2928082217872315680e-4, 1e-12,
                                  "eraApco", "bpn(2,3)", status);
            vvd(astrom.bpn[2, 2], 0.9999991386008323373, 1e-12,
                                  "eraApco", "bpn(3,3)", status);
            vvd(astrom.along, -0.5278008060295995734, 1e-12,
                              "eraApco", "along", status);
            vvd(astrom.xpl, 0.1133427418130752958e-5, 1e-17,
                            "eraApco", "xpl", status);
            vvd(astrom.ypl, 0.1453347595780646207e-5, 1e-17,
                            "eraApco", "ypl", status);
            vvd(astrom.sphi, -0.9440115679003211329, 1e-12,
                             "eraApco", "sphi", status);
            vvd(astrom.cphi, 0.3299123514971474711, 1e-12,
                             "eraApco", "cphi", status);
            vvd(astrom.diurab, 0, 0,
                               "eraApco", "diurab", status);
            vvd(astrom.eral, 2.617608903970400427, 1e-12,
                             "eraApco", "eral", status);
            vvd(astrom.refa, 0.2014187790000000000e-3, 1e-15,
                             "eraApco", "refa", status);
            vvd(astrom.refb, -0.2361408310000000000e-6, 1e-18,
                             "eraApco", "refb", status);

            Assert.Pass();
        }

        [Test]
        public void atciqz()
        {
            double date1, date2, rc, dc;
            double ri = 0;
            double di = 0;
            double eo = 0;
            Astrom astrom = new();


            date1 = 2456165.5;
            date2 = 0.401182685;
            Erfa.apci13(date1, date2, ref astrom, ref eo);
            rc = 2.71;
            dc = 0.174;

            Erfa.atciqz(rc, dc, ref astrom, ref ri, ref di);

            vvd(ri, 2.709994899247256984, 1e-12, "eraAtciqz", "ri", status);
            vvd(di, 0.1728740720984931891, 1e-12, "eraAtciqz", "di", status);

            Assert.Pass();
        }

        [Test]
        public void atioq()
        {
            double utc1, utc2, dut1, elong, phi, hm, xp, yp,
                     phpa, tc, rh, wl, ri, di;
            double aob = 0;
            double zob = 0;
            double hob = 0;
            double dob = 0;
            double rob = 0;
            Astrom astrom = new();


            utc1 = 2456384.5;
            utc2 = 0.969254051;
            dut1 = 0.1550675;
            elong = -0.527800806;
            phi = -1.2345856;
            hm = 2738.0;
            xp = 2.47230737e-7;
            yp = 1.82640464e-6;
            phpa = 731.0;
            tc = 12.8;
            rh = 0.59;
            wl = 0.55;
            
            Erfa.apio13(utc1, utc2, dut1, elong, phi, hm, xp, yp,
                             phpa, tc, rh, wl, ref astrom);
            ri = 2.710121572969038991;
            di = 0.1729371367218230438;

            Erfa.atioq(ri, di, ref astrom, ref aob, ref zob, ref hob, ref dob, ref rob);

            vvd(aob, 0.9233952224895122499e-1, 1e-12, "eraAtioq", "aob", status);
            vvd(zob, 1.407758704513549991, 1e-12, "eraAtioq", "zob", status);
            vvd(hob, -0.9247619879881698140e-1, 1e-12, "eraAtioq", "hob", status);
            vvd(dob, 0.1717653435756234676, 1e-12, "eraAtioq", "dob", status);
            vvd(rob, 2.710085107988480746, 1e-12, "eraAtioq", "rob", status);

            Assert.Pass();
        }

        [Test]
        public void apio13()
        {
            double utc1, utc2, dut1, elong, phi, hm, xp, yp, phpa, tc, rh, wl;
            int j;
            Astrom astrom = new();


            utc1 = 2456384.5;
            utc2 = 0.969254051;
            dut1 = 0.1550675;
            elong = -0.527800806;
            phi = -1.2345856;
            hm = 2738.0;
            xp = 2.47230737e-7;
            yp = 1.82640464e-6;
            phpa = 731.0;
            tc = 12.8;
            rh = 0.59;
            wl = 0.55;

            j = Erfa.apio13(utc1, utc2, dut1, elong, phi, hm, xp, yp,
                          phpa, tc, rh, wl, ref astrom);

            vvd(astrom.along, -0.5278008060295995733, 1e-12,
                              "eraApio13", "along", status);
            vvd(astrom.xpl, 0.1133427418130752958e-5, 1e-17,
                            "eraApio13", "xpl", status);
            vvd(astrom.ypl, 0.1453347595780646207e-5, 1e-17,
                            "eraApio13", "ypl", status);
            vvd(astrom.sphi, -0.9440115679003211329, 1e-12,
                             "eraApio13", "sphi", status);
            vvd(astrom.cphi, 0.3299123514971474711, 1e-12,
                             "eraApio13", "cphi", status);
            vvd(astrom.diurab, 0.5135843661699913529e-6, 1e-12,
                               "eraApio13", "diurab", status);
            vvd(astrom.eral, 2.617608909189664000, 1e-12,
                             "eraApio13", "eral", status);
            vvd(astrom.refa, 0.2014187785940396921e-3, 1e-15,
                             "eraApio13", "refa", status);
            vvd(astrom.refb, -0.2361408314943696227e-6, 1e-18,
                             "eraApio13", "refb", status);
            //viv(j, 0, "eraApio13", "j", status);

            Assert.Pass();
        }

        [Test]
        public void ld()
        {
            double bm;
            double[] p = new double[3];
            double[] q = new double[3];
            double[] e = new double[3];
            double em, dlim;
            double[] p1 = new double[3];


            bm = 0.00028574;
            p[0] = -0.763276255;
            p[1] = -0.608633767;
            p[2] = -0.216735543;
            q[0] = -0.763276255;
            q[1] = -0.608633767;
            q[2] = -0.216735543;
            e[0] = 0.76700421;
            e[1] = 0.605629598;
            e[2] = 0.211937094;
            em = 8.91276983;
            dlim = 3e-10;

            Erfa.ld(bm, p, q, e, em, dlim, p1);

            vvd(p1[0], -0.7632762548968159627, 1e-12,
                        "eraLd", "1", status);
            vvd(p1[1], -0.6086337670823762701, 1e-12,
                        "eraLd", "2", status);
            vvd(p1[2], -0.2167355431320546947, 1e-12,
                        "eraLd", "3", status);

            Assert.Pass();
        }

        [Test]
        public void c2s()
        {
            double[] p = new double[3];
            double theta = 0;
            double phi = 0;


            p[0] = 100.0;
            p[1] = -50.0;
            p[2] = 25.0;

            Erfa.c2s(p, ref theta, ref phi);

            vvd(theta, -0.4636476090008061162, 1e-14, "eraC2s", "theta", status);
            vvd(phi, 0.2199879773954594463, 1e-14, "eraC2s", "phi", status);

            Assert.Pass();
        }

        [Test]
        public void s2c()
        {
            double[] c = new double[3];


            Erfa.s2c(3.0123, -0.999, c);

            vvd(c[0], -0.5366267667260523906, 1e-12, "eraS2c", "1", status);
            vvd(c[1], 0.0697711109765145365, 1e-12, "eraS2c", "2", status);
            vvd(c[2], -0.8409302618566214041, 1e-12, "eraS2c", "3", status);
        }

        [Test]
        public void trxp()
        {
            double[,] r = new double[3, 3];
            double[] p = new double[3];
            double[] trp = new double[3];


            r[0, 0] = 2.0;
            r[0, 1] = 3.0;
            r[0, 2] = 2.0;

            r[1, 0] = 3.0;
            r[1, 1] = 2.0;
            r[1, 2] = 3.0;

            r[2, 0] = 3.0;
            r[2, 1] = 4.0;
            r[2, 2] = 5.0;

            p[0] = 0.2;
            p[1] = 1.5;
            p[2] = 0.1;

            Erfa.trxp(r, p, trp);

            vvd(trp[0], 5.2, 1e-12, "eraTrxp", "1", status);
            vvd(trp[1], 4.0, 1e-12, "eraTrxp", "2", status);
            vvd(trp[2], 5.4, 1e-12, "eraTrxp", "3", status);
        }

        [Test]
        public void ab()
        {
            double[] pnat = new double[3];
            double[] v = new double[3];
            double s, bm1;
            double[] ppr = new double[3];


            pnat[0] = -0.76321968546737951;
            pnat[1] = -0.60869453983060384;
            pnat[2] = -0.21676408580639883;
            v[0] = 2.1044018893653786e-5;
            v[1] = -8.9108923304429319e-5;
            v[2] = -3.8633714797716569e-5;
            s = 0.99980921395708788;
            bm1 = 0.99999999506209258;

            Erfa.ab(pnat, v, s, bm1, ppr);

            vvd(ppr[0], -0.7631631094219556269, 1e-12, "eraAb", "1", status);
            vvd(ppr[1], -0.6087553082505590832, 1e-12, "eraAb", "2", status);
            vvd(ppr[2], -0.2167926269368471279, 1e-12, "eraAb", "3", status);
        }

        [Test]
        public void pn()
        {
            double[] p = new double[3];
            double r = 0;
            double[] u = new double[3];


            p[0] = 0.3;
            p[1] = 1.2;
            p[2] = -2.5;

            Erfa.pn(p, ref r, u);

            vvd(r, 2.789265136196270604, 1e-12, "eraPn", "r", status);

            vvd(u[0], 0.1075552109073112058, 1e-12, "eraPn", "u1", status);
            vvd(u[1], 0.4302208436292448232, 1e-12, "eraPn", "u2", status);
            vvd(u[2], -0.8962934242275933816, 1e-12, "eraPn", "u3", status);
        }

        /*
        **  - - - -
        **   v v d
        **  - - - -
        **
        **  Validate a double result.
        **
        **  Internal function used by t_erfa_c program.
        **
        **  Given:
        **     val      double       value computed by function under test
        **     valok    double       expected value
        **     dval     double       maximum allowable error
        **     func     char[]       name of function under test
        **     test     char[]       name of individual test
        **
        **  Given and returned:
        **     status   int          set to TRUE if test fails
        **
        **  This revision:  2016 April 21
        */
        private static void vvd(double val, double valok, double dval,
                string func, string test, int status)
        {
            double a, f;   /* absolute and fractional error */

            a = val - valok;

            if (a != 0.0 && double.Abs(a) > double.Abs(dval))
            {
                f = Double.Abs(valok / a);
                //*status = 1;
                Assert.Fail($"{func} failed: {test} want {valok:g20} got {val:g20} (1/{f:g3})");
            }
            else
            {
                Console.WriteLine($"{func} passed: {test} want {valok:g20} got {val:g20}");
            }
        }
    }
}
