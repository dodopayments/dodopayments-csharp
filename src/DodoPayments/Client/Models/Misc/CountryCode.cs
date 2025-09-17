using System;
using System.Text.Json.Serialization;
using Client = DodoPayments.Client;

namespace DodoPayments.Client.Models.Misc;

/// <summary>
/// ISO country code alpha2 variant
/// </summary>
[JsonConverter(typeof(Client::EnumConverter<CountryCode, string>))]
public sealed record class CountryCode(string value) : Client::IEnum<CountryCode, string>
{
    public static readonly CountryCode Af = new("AF");

    public static readonly CountryCode Ax = new("AX");

    public static readonly CountryCode Al = new("AL");

    public static readonly CountryCode Dz = new("DZ");

    public static readonly CountryCode As = new("AS");

    public static readonly CountryCode Ad = new("AD");

    public static readonly CountryCode Ao = new("AO");

    public static readonly CountryCode AI = new("AI");

    public static readonly CountryCode Aq = new("AQ");

    public static readonly CountryCode Ag = new("AG");

    public static readonly CountryCode Ar = new("AR");

    public static readonly CountryCode Am = new("AM");

    public static readonly CountryCode Aw = new("AW");

    public static readonly CountryCode Au = new("AU");

    public static readonly CountryCode At = new("AT");

    public static readonly CountryCode Az = new("AZ");

    public static readonly CountryCode Bs = new("BS");

    public static readonly CountryCode Bh = new("BH");

    public static readonly CountryCode Bd = new("BD");

    public static readonly CountryCode Bb = new("BB");

    public static readonly CountryCode By = new("BY");

    public static readonly CountryCode Be = new("BE");

    public static readonly CountryCode Bz = new("BZ");

    public static readonly CountryCode Bj = new("BJ");

    public static readonly CountryCode Bm = new("BM");

    public static readonly CountryCode Bt = new("BT");

    public static readonly CountryCode Bo = new("BO");

    public static readonly CountryCode Bq = new("BQ");

    public static readonly CountryCode Ba = new("BA");

    public static readonly CountryCode Bw = new("BW");

    public static readonly CountryCode Bv = new("BV");

    public static readonly CountryCode Br = new("BR");

    public static readonly CountryCode Io = new("IO");

    public static readonly CountryCode Bn = new("BN");

    public static readonly CountryCode Bg = new("BG");

    public static readonly CountryCode Bf = new("BF");

    public static readonly CountryCode Bi = new("BI");

    public static readonly CountryCode Kh = new("KH");

    public static readonly CountryCode Cm = new("CM");

    public static readonly CountryCode Ca = new("CA");

    public static readonly CountryCode Cv = new("CV");

    public static readonly CountryCode Ky = new("KY");

    public static readonly CountryCode Cf = new("CF");

    public static readonly CountryCode Td = new("TD");

    public static readonly CountryCode Cl = new("CL");

    public static readonly CountryCode Cn = new("CN");

    public static readonly CountryCode Cx = new("CX");

    public static readonly CountryCode Cc = new("CC");

    public static readonly CountryCode Co = new("CO");

    public static readonly CountryCode Km = new("KM");

    public static readonly CountryCode Cg = new("CG");

    public static readonly CountryCode Cd = new("CD");

    public static readonly CountryCode Ck = new("CK");

    public static readonly CountryCode Cr = new("CR");

    public static readonly CountryCode Ci = new("CI");

    public static readonly CountryCode Hr = new("HR");

    public static readonly CountryCode Cu = new("CU");

    public static readonly CountryCode Cw = new("CW");

    public static readonly CountryCode Cy = new("CY");

    public static readonly CountryCode Cz = new("CZ");

    public static readonly CountryCode Dk = new("DK");

    public static readonly CountryCode Dj = new("DJ");

    public static readonly CountryCode Dm = new("DM");

    public static readonly CountryCode Do = new("DO");

    public static readonly CountryCode Ec = new("EC");

    public static readonly CountryCode Eg = new("EG");

    public static readonly CountryCode Sv = new("SV");

    public static readonly CountryCode Gq = new("GQ");

    public static readonly CountryCode Er = new("ER");

    public static readonly CountryCode Ee = new("EE");

    public static readonly CountryCode Et = new("ET");

    public static readonly CountryCode Fk = new("FK");

    public static readonly CountryCode Fo = new("FO");

    public static readonly CountryCode Fj = new("FJ");

    public static readonly CountryCode Fi = new("FI");

    public static readonly CountryCode Fr = new("FR");

    public static readonly CountryCode Gf = new("GF");

    public static readonly CountryCode Pf = new("PF");

    public static readonly CountryCode Tf = new("TF");

    public static readonly CountryCode Ga = new("GA");

    public static readonly CountryCode Gm = new("GM");

    public static readonly CountryCode Ge = new("GE");

    public static readonly CountryCode De = new("DE");

    public static readonly CountryCode Gh = new("GH");

    public static readonly CountryCode Gi = new("GI");

    public static readonly CountryCode Gr = new("GR");

    public static readonly CountryCode Gl = new("GL");

    public static readonly CountryCode Gd = new("GD");

    public static readonly CountryCode Gp = new("GP");

    public static readonly CountryCode Gu = new("GU");

    public static readonly CountryCode Gt = new("GT");

    public static readonly CountryCode Gg = new("GG");

    public static readonly CountryCode Gn = new("GN");

    public static readonly CountryCode Gw = new("GW");

    public static readonly CountryCode Gy = new("GY");

    public static readonly CountryCode Ht = new("HT");

    public static readonly CountryCode Hm = new("HM");

    public static readonly CountryCode Va = new("VA");

    public static readonly CountryCode Hn = new("HN");

    public static readonly CountryCode Hk = new("HK");

    public static readonly CountryCode Hu = new("HU");

    public static readonly CountryCode Is = new("IS");

    public static readonly CountryCode In = new("IN");

    public static readonly CountryCode ID = new("ID");

    public static readonly CountryCode Ir = new("IR");

    public static readonly CountryCode Iq = new("IQ");

    public static readonly CountryCode Ie = new("IE");

    public static readonly CountryCode Im = new("IM");

    public static readonly CountryCode Il = new("IL");

    public static readonly CountryCode It = new("IT");

    public static readonly CountryCode Jm = new("JM");

    public static readonly CountryCode Jp = new("JP");

    public static readonly CountryCode Je = new("JE");

    public static readonly CountryCode Jo = new("JO");

    public static readonly CountryCode Kz = new("KZ");

    public static readonly CountryCode Ke = new("KE");

    public static readonly CountryCode Ki = new("KI");

    public static readonly CountryCode Kp = new("KP");

    public static readonly CountryCode Kr = new("KR");

    public static readonly CountryCode Kw = new("KW");

    public static readonly CountryCode Kg = new("KG");

    public static readonly CountryCode La = new("LA");

    public static readonly CountryCode Lv = new("LV");

    public static readonly CountryCode Lb = new("LB");

    public static readonly CountryCode Ls = new("LS");

    public static readonly CountryCode Lr = new("LR");

    public static readonly CountryCode Ly = new("LY");

    public static readonly CountryCode Li = new("LI");

    public static readonly CountryCode Lt = new("LT");

    public static readonly CountryCode Lu = new("LU");

    public static readonly CountryCode Mo = new("MO");

    public static readonly CountryCode Mk = new("MK");

    public static readonly CountryCode Mg = new("MG");

    public static readonly CountryCode Mw = new("MW");

    public static readonly CountryCode My = new("MY");

    public static readonly CountryCode Mv = new("MV");

    public static readonly CountryCode Ml = new("ML");

    public static readonly CountryCode Mt = new("MT");

    public static readonly CountryCode Mh = new("MH");

    public static readonly CountryCode Mq = new("MQ");

    public static readonly CountryCode Mr = new("MR");

    public static readonly CountryCode Mu = new("MU");

    public static readonly CountryCode Yt = new("YT");

    public static readonly CountryCode Mx = new("MX");

    public static readonly CountryCode Fm = new("FM");

    public static readonly CountryCode Md = new("MD");

    public static readonly CountryCode Mc = new("MC");

    public static readonly CountryCode Mn = new("MN");

    public static readonly CountryCode Me = new("ME");

    public static readonly CountryCode Ms = new("MS");

    public static readonly CountryCode Ma = new("MA");

    public static readonly CountryCode Mz = new("MZ");

    public static readonly CountryCode Mm = new("MM");

    public static readonly CountryCode Na = new("NA");

    public static readonly CountryCode Nr = new("NR");

    public static readonly CountryCode Np = new("NP");

    public static readonly CountryCode Nl = new("NL");

    public static readonly CountryCode Nc = new("NC");

    public static readonly CountryCode Nz = new("NZ");

    public static readonly CountryCode Ni = new("NI");

    public static readonly CountryCode Ne = new("NE");

    public static readonly CountryCode Ng = new("NG");

    public static readonly CountryCode Nu = new("NU");

    public static readonly CountryCode Nf = new("NF");

    public static readonly CountryCode Mp = new("MP");

    public static readonly CountryCode No = new("NO");

    public static readonly CountryCode Om = new("OM");

    public static readonly CountryCode Pk = new("PK");

    public static readonly CountryCode Pw = new("PW");

    public static readonly CountryCode Ps = new("PS");

    public static readonly CountryCode Pa = new("PA");

    public static readonly CountryCode Pg = new("PG");

    public static readonly CountryCode Py = new("PY");

    public static readonly CountryCode Pe = new("PE");

    public static readonly CountryCode Ph = new("PH");

    public static readonly CountryCode Pn = new("PN");

    public static readonly CountryCode Pl = new("PL");

    public static readonly CountryCode Pt = new("PT");

    public static readonly CountryCode Pr = new("PR");

    public static readonly CountryCode Qa = new("QA");

    public static readonly CountryCode Re = new("RE");

    public static readonly CountryCode Ro = new("RO");

    public static readonly CountryCode Ru = new("RU");

    public static readonly CountryCode Rw = new("RW");

    public static readonly CountryCode Bl = new("BL");

    public static readonly CountryCode Sh = new("SH");

    public static readonly CountryCode Kn = new("KN");

    public static readonly CountryCode Lc = new("LC");

    public static readonly CountryCode Mf = new("MF");

    public static readonly CountryCode Pm = new("PM");

    public static readonly CountryCode Vc = new("VC");

    public static readonly CountryCode Ws = new("WS");

    public static readonly CountryCode Sm = new("SM");

    public static readonly CountryCode St = new("ST");

    public static readonly CountryCode Sa = new("SA");

    public static readonly CountryCode Sn = new("SN");

    public static readonly CountryCode Rs = new("RS");

    public static readonly CountryCode Sc = new("SC");

    public static readonly CountryCode Sl = new("SL");

    public static readonly CountryCode Sg = new("SG");

    public static readonly CountryCode Sx = new("SX");

    public static readonly CountryCode Sk = new("SK");

    public static readonly CountryCode Si = new("SI");

    public static readonly CountryCode Sb = new("SB");

    public static readonly CountryCode So = new("SO");

    public static readonly CountryCode Za = new("ZA");

    public static readonly CountryCode Gs = new("GS");

    public static readonly CountryCode SS = new("SS");

    public static readonly CountryCode Es = new("ES");

    public static readonly CountryCode Lk = new("LK");

    public static readonly CountryCode Sd = new("SD");

    public static readonly CountryCode Sr = new("SR");

    public static readonly CountryCode Sj = new("SJ");

    public static readonly CountryCode Sz = new("SZ");

    public static readonly CountryCode Se = new("SE");

    public static readonly CountryCode Ch = new("CH");

    public static readonly CountryCode Sy = new("SY");

    public static readonly CountryCode Tw = new("TW");

    public static readonly CountryCode Tj = new("TJ");

    public static readonly CountryCode Tz = new("TZ");

    public static readonly CountryCode Th = new("TH");

    public static readonly CountryCode Tl = new("TL");

    public static readonly CountryCode Tg = new("TG");

    public static readonly CountryCode Tk = new("TK");

    public static readonly CountryCode To = new("TO");

    public static readonly CountryCode Tt = new("TT");

    public static readonly CountryCode Tn = new("TN");

    public static readonly CountryCode Tr = new("TR");

    public static readonly CountryCode Tm = new("TM");

    public static readonly CountryCode Tc = new("TC");

    public static readonly CountryCode Tv = new("TV");

    public static readonly CountryCode Ug = new("UG");

    public static readonly CountryCode Ua = new("UA");

    public static readonly CountryCode Ae = new("AE");

    public static readonly CountryCode GB = new("GB");

    public static readonly CountryCode Um = new("UM");

    public static readonly CountryCode Us = new("US");

    public static readonly CountryCode Uy = new("UY");

    public static readonly CountryCode Uz = new("UZ");

    public static readonly CountryCode Vu = new("VU");

    public static readonly CountryCode Ve = new("VE");

    public static readonly CountryCode Vn = new("VN");

    public static readonly CountryCode Vg = new("VG");

    public static readonly CountryCode Vi = new("VI");

    public static readonly CountryCode Wf = new("WF");

    public static readonly CountryCode Eh = new("EH");

    public static readonly CountryCode Ye = new("YE");

    public static readonly CountryCode Zm = new("ZM");

    public static readonly CountryCode Zw = new("ZW");

    readonly string _value = value;

    public enum Value
    {
        Af,
        Ax,
        Al,
        Dz,
        As,
        Ad,
        Ao,
        AI,
        Aq,
        Ag,
        Ar,
        Am,
        Aw,
        Au,
        At,
        Az,
        Bs,
        Bh,
        Bd,
        Bb,
        By,
        Be,
        Bz,
        Bj,
        Bm,
        Bt,
        Bo,
        Bq,
        Ba,
        Bw,
        Bv,
        Br,
        Io,
        Bn,
        Bg,
        Bf,
        Bi,
        Kh,
        Cm,
        Ca,
        Cv,
        Ky,
        Cf,
        Td,
        Cl,
        Cn,
        Cx,
        Cc,
        Co,
        Km,
        Cg,
        Cd,
        Ck,
        Cr,
        Ci,
        Hr,
        Cu,
        Cw,
        Cy,
        Cz,
        Dk,
        Dj,
        Dm,
        Do,
        Ec,
        Eg,
        Sv,
        Gq,
        Er,
        Ee,
        Et,
        Fk,
        Fo,
        Fj,
        Fi,
        Fr,
        Gf,
        Pf,
        Tf,
        Ga,
        Gm,
        Ge,
        De,
        Gh,
        Gi,
        Gr,
        Gl,
        Gd,
        Gp,
        Gu,
        Gt,
        Gg,
        Gn,
        Gw,
        Gy,
        Ht,
        Hm,
        Va,
        Hn,
        Hk,
        Hu,
        Is,
        In,
        ID,
        Ir,
        Iq,
        Ie,
        Im,
        Il,
        It,
        Jm,
        Jp,
        Je,
        Jo,
        Kz,
        Ke,
        Ki,
        Kp,
        Kr,
        Kw,
        Kg,
        La,
        Lv,
        Lb,
        Ls,
        Lr,
        Ly,
        Li,
        Lt,
        Lu,
        Mo,
        Mk,
        Mg,
        Mw,
        My,
        Mv,
        Ml,
        Mt,
        Mh,
        Mq,
        Mr,
        Mu,
        Yt,
        Mx,
        Fm,
        Md,
        Mc,
        Mn,
        Me,
        Ms,
        Ma,
        Mz,
        Mm,
        Na,
        Nr,
        Np,
        Nl,
        Nc,
        Nz,
        Ni,
        Ne,
        Ng,
        Nu,
        Nf,
        Mp,
        No,
        Om,
        Pk,
        Pw,
        Ps,
        Pa,
        Pg,
        Py,
        Pe,
        Ph,
        Pn,
        Pl,
        Pt,
        Pr,
        Qa,
        Re,
        Ro,
        Ru,
        Rw,
        Bl,
        Sh,
        Kn,
        Lc,
        Mf,
        Pm,
        Vc,
        Ws,
        Sm,
        St,
        Sa,
        Sn,
        Rs,
        Sc,
        Sl,
        Sg,
        Sx,
        Sk,
        Si,
        Sb,
        So,
        Za,
        Gs,
        SS,
        Es,
        Lk,
        Sd,
        Sr,
        Sj,
        Sz,
        Se,
        Ch,
        Sy,
        Tw,
        Tj,
        Tz,
        Th,
        Tl,
        Tg,
        Tk,
        To,
        Tt,
        Tn,
        Tr,
        Tm,
        Tc,
        Tv,
        Ug,
        Ua,
        Ae,
        GB,
        Um,
        Us,
        Uy,
        Uz,
        Vu,
        Ve,
        Vn,
        Vg,
        Vi,
        Wf,
        Eh,
        Ye,
        Zm,
        Zw,
    }

    public Value Known() =>
        _value switch
        {
            "AF" => Value.Af,
            "AX" => Value.Ax,
            "AL" => Value.Al,
            "DZ" => Value.Dz,
            "AS" => Value.As,
            "AD" => Value.Ad,
            "AO" => Value.Ao,
            "AI" => Value.AI,
            "AQ" => Value.Aq,
            "AG" => Value.Ag,
            "AR" => Value.Ar,
            "AM" => Value.Am,
            "AW" => Value.Aw,
            "AU" => Value.Au,
            "AT" => Value.At,
            "AZ" => Value.Az,
            "BS" => Value.Bs,
            "BH" => Value.Bh,
            "BD" => Value.Bd,
            "BB" => Value.Bb,
            "BY" => Value.By,
            "BE" => Value.Be,
            "BZ" => Value.Bz,
            "BJ" => Value.Bj,
            "BM" => Value.Bm,
            "BT" => Value.Bt,
            "BO" => Value.Bo,
            "BQ" => Value.Bq,
            "BA" => Value.Ba,
            "BW" => Value.Bw,
            "BV" => Value.Bv,
            "BR" => Value.Br,
            "IO" => Value.Io,
            "BN" => Value.Bn,
            "BG" => Value.Bg,
            "BF" => Value.Bf,
            "BI" => Value.Bi,
            "KH" => Value.Kh,
            "CM" => Value.Cm,
            "CA" => Value.Ca,
            "CV" => Value.Cv,
            "KY" => Value.Ky,
            "CF" => Value.Cf,
            "TD" => Value.Td,
            "CL" => Value.Cl,
            "CN" => Value.Cn,
            "CX" => Value.Cx,
            "CC" => Value.Cc,
            "CO" => Value.Co,
            "KM" => Value.Km,
            "CG" => Value.Cg,
            "CD" => Value.Cd,
            "CK" => Value.Ck,
            "CR" => Value.Cr,
            "CI" => Value.Ci,
            "HR" => Value.Hr,
            "CU" => Value.Cu,
            "CW" => Value.Cw,
            "CY" => Value.Cy,
            "CZ" => Value.Cz,
            "DK" => Value.Dk,
            "DJ" => Value.Dj,
            "DM" => Value.Dm,
            "DO" => Value.Do,
            "EC" => Value.Ec,
            "EG" => Value.Eg,
            "SV" => Value.Sv,
            "GQ" => Value.Gq,
            "ER" => Value.Er,
            "EE" => Value.Ee,
            "ET" => Value.Et,
            "FK" => Value.Fk,
            "FO" => Value.Fo,
            "FJ" => Value.Fj,
            "FI" => Value.Fi,
            "FR" => Value.Fr,
            "GF" => Value.Gf,
            "PF" => Value.Pf,
            "TF" => Value.Tf,
            "GA" => Value.Ga,
            "GM" => Value.Gm,
            "GE" => Value.Ge,
            "DE" => Value.De,
            "GH" => Value.Gh,
            "GI" => Value.Gi,
            "GR" => Value.Gr,
            "GL" => Value.Gl,
            "GD" => Value.Gd,
            "GP" => Value.Gp,
            "GU" => Value.Gu,
            "GT" => Value.Gt,
            "GG" => Value.Gg,
            "GN" => Value.Gn,
            "GW" => Value.Gw,
            "GY" => Value.Gy,
            "HT" => Value.Ht,
            "HM" => Value.Hm,
            "VA" => Value.Va,
            "HN" => Value.Hn,
            "HK" => Value.Hk,
            "HU" => Value.Hu,
            "IS" => Value.Is,
            "IN" => Value.In,
            "ID" => Value.ID,
            "IR" => Value.Ir,
            "IQ" => Value.Iq,
            "IE" => Value.Ie,
            "IM" => Value.Im,
            "IL" => Value.Il,
            "IT" => Value.It,
            "JM" => Value.Jm,
            "JP" => Value.Jp,
            "JE" => Value.Je,
            "JO" => Value.Jo,
            "KZ" => Value.Kz,
            "KE" => Value.Ke,
            "KI" => Value.Ki,
            "KP" => Value.Kp,
            "KR" => Value.Kr,
            "KW" => Value.Kw,
            "KG" => Value.Kg,
            "LA" => Value.La,
            "LV" => Value.Lv,
            "LB" => Value.Lb,
            "LS" => Value.Ls,
            "LR" => Value.Lr,
            "LY" => Value.Ly,
            "LI" => Value.Li,
            "LT" => Value.Lt,
            "LU" => Value.Lu,
            "MO" => Value.Mo,
            "MK" => Value.Mk,
            "MG" => Value.Mg,
            "MW" => Value.Mw,
            "MY" => Value.My,
            "MV" => Value.Mv,
            "ML" => Value.Ml,
            "MT" => Value.Mt,
            "MH" => Value.Mh,
            "MQ" => Value.Mq,
            "MR" => Value.Mr,
            "MU" => Value.Mu,
            "YT" => Value.Yt,
            "MX" => Value.Mx,
            "FM" => Value.Fm,
            "MD" => Value.Md,
            "MC" => Value.Mc,
            "MN" => Value.Mn,
            "ME" => Value.Me,
            "MS" => Value.Ms,
            "MA" => Value.Ma,
            "MZ" => Value.Mz,
            "MM" => Value.Mm,
            "NA" => Value.Na,
            "NR" => Value.Nr,
            "NP" => Value.Np,
            "NL" => Value.Nl,
            "NC" => Value.Nc,
            "NZ" => Value.Nz,
            "NI" => Value.Ni,
            "NE" => Value.Ne,
            "NG" => Value.Ng,
            "NU" => Value.Nu,
            "NF" => Value.Nf,
            "MP" => Value.Mp,
            "NO" => Value.No,
            "OM" => Value.Om,
            "PK" => Value.Pk,
            "PW" => Value.Pw,
            "PS" => Value.Ps,
            "PA" => Value.Pa,
            "PG" => Value.Pg,
            "PY" => Value.Py,
            "PE" => Value.Pe,
            "PH" => Value.Ph,
            "PN" => Value.Pn,
            "PL" => Value.Pl,
            "PT" => Value.Pt,
            "PR" => Value.Pr,
            "QA" => Value.Qa,
            "RE" => Value.Re,
            "RO" => Value.Ro,
            "RU" => Value.Ru,
            "RW" => Value.Rw,
            "BL" => Value.Bl,
            "SH" => Value.Sh,
            "KN" => Value.Kn,
            "LC" => Value.Lc,
            "MF" => Value.Mf,
            "PM" => Value.Pm,
            "VC" => Value.Vc,
            "WS" => Value.Ws,
            "SM" => Value.Sm,
            "ST" => Value.St,
            "SA" => Value.Sa,
            "SN" => Value.Sn,
            "RS" => Value.Rs,
            "SC" => Value.Sc,
            "SL" => Value.Sl,
            "SG" => Value.Sg,
            "SX" => Value.Sx,
            "SK" => Value.Sk,
            "SI" => Value.Si,
            "SB" => Value.Sb,
            "SO" => Value.So,
            "ZA" => Value.Za,
            "GS" => Value.Gs,
            "SS" => Value.SS,
            "ES" => Value.Es,
            "LK" => Value.Lk,
            "SD" => Value.Sd,
            "SR" => Value.Sr,
            "SJ" => Value.Sj,
            "SZ" => Value.Sz,
            "SE" => Value.Se,
            "CH" => Value.Ch,
            "SY" => Value.Sy,
            "TW" => Value.Tw,
            "TJ" => Value.Tj,
            "TZ" => Value.Tz,
            "TH" => Value.Th,
            "TL" => Value.Tl,
            "TG" => Value.Tg,
            "TK" => Value.Tk,
            "TO" => Value.To,
            "TT" => Value.Tt,
            "TN" => Value.Tn,
            "TR" => Value.Tr,
            "TM" => Value.Tm,
            "TC" => Value.Tc,
            "TV" => Value.Tv,
            "UG" => Value.Ug,
            "UA" => Value.Ua,
            "AE" => Value.Ae,
            "GB" => Value.GB,
            "UM" => Value.Um,
            "US" => Value.Us,
            "UY" => Value.Uy,
            "UZ" => Value.Uz,
            "VU" => Value.Vu,
            "VE" => Value.Ve,
            "VN" => Value.Vn,
            "VG" => Value.Vg,
            "VI" => Value.Vi,
            "WF" => Value.Wf,
            "EH" => Value.Eh,
            "YE" => Value.Ye,
            "ZM" => Value.Zm,
            "ZW" => Value.Zw,
            _ => throw new ArgumentOutOfRangeException(nameof(_value)),
        };

    public string Raw()
    {
        return _value;
    }

    public void Validate()
    {
        Known();
    }

    public static CountryCode FromRaw(string value)
    {
        return new(value);
    }
}
