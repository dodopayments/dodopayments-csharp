using System;
using System.Text.Json.Serialization;
using Client = DodoPayments.Client;

namespace DodoPayments.Client.Models.Misc;

[JsonConverter(typeof(Client::EnumConverter<Currency, string>))]
public sealed record class Currency(string value) : Client::IEnum<Currency, string>
{
    public static readonly Currency Aed = new("AED");

    public static readonly Currency All = new("ALL");

    public static readonly Currency Amd = new("AMD");

    public static readonly Currency Ang = new("ANG");

    public static readonly Currency Aoa = new("AOA");

    public static readonly Currency Ars = new("ARS");

    public static readonly Currency Aud = new("AUD");

    public static readonly Currency Awg = new("AWG");

    public static readonly Currency Azn = new("AZN");

    public static readonly Currency Bam = new("BAM");

    public static readonly Currency Bbd = new("BBD");

    public static readonly Currency Bdt = new("BDT");

    public static readonly Currency Bgn = new("BGN");

    public static readonly Currency Bhd = new("BHD");

    public static readonly Currency Bif = new("BIF");

    public static readonly Currency Bmd = new("BMD");

    public static readonly Currency Bnd = new("BND");

    public static readonly Currency Bob = new("BOB");

    public static readonly Currency Brl = new("BRL");

    public static readonly Currency Bsd = new("BSD");

    public static readonly Currency Bwp = new("BWP");

    public static readonly Currency Byn = new("BYN");

    public static readonly Currency Bzd = new("BZD");

    public static readonly Currency Cad = new("CAD");

    public static readonly Currency Chf = new("CHF");

    public static readonly Currency Clp = new("CLP");

    public static readonly Currency Cny = new("CNY");

    public static readonly Currency Cop = new("COP");

    public static readonly Currency Crc = new("CRC");

    public static readonly Currency Cup = new("CUP");

    public static readonly Currency Cve = new("CVE");

    public static readonly Currency Czk = new("CZK");

    public static readonly Currency Djf = new("DJF");

    public static readonly Currency Dkk = new("DKK");

    public static readonly Currency Dop = new("DOP");

    public static readonly Currency Dzd = new("DZD");

    public static readonly Currency Egp = new("EGP");

    public static readonly Currency Etb = new("ETB");

    public static readonly Currency Eur = new("EUR");

    public static readonly Currency Fjd = new("FJD");

    public static readonly Currency Fkp = new("FKP");

    public static readonly Currency Gbp = new("GBP");

    public static readonly Currency Gel = new("GEL");

    public static readonly Currency Ghs = new("GHS");

    public static readonly Currency Gip = new("GIP");

    public static readonly Currency Gmd = new("GMD");

    public static readonly Currency Gnf = new("GNF");

    public static readonly Currency Gtq = new("GTQ");

    public static readonly Currency Gyd = new("GYD");

    public static readonly Currency Hkd = new("HKD");

    public static readonly Currency Hnl = new("HNL");

    public static readonly Currency Hrk = new("HRK");

    public static readonly Currency Htg = new("HTG");

    public static readonly Currency Huf = new("HUF");

    public static readonly Currency Idr = new("IDR");

    public static readonly Currency Ils = new("ILS");

    public static readonly Currency Inr = new("INR");

    public static readonly Currency Iqd = new("IQD");

    public static readonly Currency Jmd = new("JMD");

    public static readonly Currency Jod = new("JOD");

    public static readonly Currency Jpy = new("JPY");

    public static readonly Currency Kes = new("KES");

    public static readonly Currency Kgs = new("KGS");

    public static readonly Currency Khr = new("KHR");

    public static readonly Currency Kmf = new("KMF");

    public static readonly Currency Krw = new("KRW");

    public static readonly Currency Kwd = new("KWD");

    public static readonly Currency Kyd = new("KYD");

    public static readonly Currency Kzt = new("KZT");

    public static readonly Currency Lak = new("LAK");

    public static readonly Currency Lbp = new("LBP");

    public static readonly Currency Lkr = new("LKR");

    public static readonly Currency Lrd = new("LRD");

    public static readonly Currency Lsl = new("LSL");

    public static readonly Currency Lyd = new("LYD");

    public static readonly Currency Mad = new("MAD");

    public static readonly Currency Mdl = new("MDL");

    public static readonly Currency Mga = new("MGA");

    public static readonly Currency Mkd = new("MKD");

    public static readonly Currency Mmk = new("MMK");

    public static readonly Currency Mnt = new("MNT");

    public static readonly Currency Mop = new("MOP");

    public static readonly Currency Mru = new("MRU");

    public static readonly Currency Mur = new("MUR");

    public static readonly Currency Mvr = new("MVR");

    public static readonly Currency Mwk = new("MWK");

    public static readonly Currency Mxn = new("MXN");

    public static readonly Currency Myr = new("MYR");

    public static readonly Currency Mzn = new("MZN");

    public static readonly Currency Nad = new("NAD");

    public static readonly Currency Ngn = new("NGN");

    public static readonly Currency Nio = new("NIO");

    public static readonly Currency Nok = new("NOK");

    public static readonly Currency Npr = new("NPR");

    public static readonly Currency Nzd = new("NZD");

    public static readonly Currency Omr = new("OMR");

    public static readonly Currency Pab = new("PAB");

    public static readonly Currency Pen = new("PEN");

    public static readonly Currency Pgk = new("PGK");

    public static readonly Currency Php = new("PHP");

    public static readonly Currency Pkr = new("PKR");

    public static readonly Currency Pln = new("PLN");

    public static readonly Currency Pyg = new("PYG");

    public static readonly Currency Qar = new("QAR");

    public static readonly Currency Ron = new("RON");

    public static readonly Currency Rsd = new("RSD");

    public static readonly Currency Rub = new("RUB");

    public static readonly Currency Rwf = new("RWF");

    public static readonly Currency Sar = new("SAR");

    public static readonly Currency Sbd = new("SBD");

    public static readonly Currency Scr = new("SCR");

    public static readonly Currency Sek = new("SEK");

    public static readonly Currency Sgd = new("SGD");

    public static readonly Currency Shp = new("SHP");

    public static readonly Currency Sle = new("SLE");

    public static readonly Currency Sll = new("SLL");

    public static readonly Currency Sos = new("SOS");

    public static readonly Currency Srd = new("SRD");

    public static readonly Currency Ssp = new("SSP");

    public static readonly Currency Stn = new("STN");

    public static readonly Currency Svc = new("SVC");

    public static readonly Currency Szl = new("SZL");

    public static readonly Currency Thb = new("THB");

    public static readonly Currency Tnd = new("TND");

    public static readonly Currency Top = new("TOP");

    public static readonly Currency Try = new("TRY");

    public static readonly Currency Ttd = new("TTD");

    public static readonly Currency Twd = new("TWD");

    public static readonly Currency Tzs = new("TZS");

    public static readonly Currency Uah = new("UAH");

    public static readonly Currency Ugx = new("UGX");

    public static readonly Currency Usd = new("USD");

    public static readonly Currency Uyu = new("UYU");

    public static readonly Currency Uzs = new("UZS");

    public static readonly Currency Ves = new("VES");

    public static readonly Currency Vnd = new("VND");

    public static readonly Currency Vuv = new("VUV");

    public static readonly Currency Wst = new("WST");

    public static readonly Currency Xaf = new("XAF");

    public static readonly Currency Xcd = new("XCD");

    public static readonly Currency Xof = new("XOF");

    public static readonly Currency Xpf = new("XPF");

    public static readonly Currency Yer = new("YER");

    public static readonly Currency Zar = new("ZAR");

    public static readonly Currency Zmw = new("ZMW");

    readonly string _value = value;

    public enum Value
    {
        Aed,
        All,
        Amd,
        Ang,
        Aoa,
        Ars,
        Aud,
        Awg,
        Azn,
        Bam,
        Bbd,
        Bdt,
        Bgn,
        Bhd,
        Bif,
        Bmd,
        Bnd,
        Bob,
        Brl,
        Bsd,
        Bwp,
        Byn,
        Bzd,
        Cad,
        Chf,
        Clp,
        Cny,
        Cop,
        Crc,
        Cup,
        Cve,
        Czk,
        Djf,
        Dkk,
        Dop,
        Dzd,
        Egp,
        Etb,
        Eur,
        Fjd,
        Fkp,
        Gbp,
        Gel,
        Ghs,
        Gip,
        Gmd,
        Gnf,
        Gtq,
        Gyd,
        Hkd,
        Hnl,
        Hrk,
        Htg,
        Huf,
        Idr,
        Ils,
        Inr,
        Iqd,
        Jmd,
        Jod,
        Jpy,
        Kes,
        Kgs,
        Khr,
        Kmf,
        Krw,
        Kwd,
        Kyd,
        Kzt,
        Lak,
        Lbp,
        Lkr,
        Lrd,
        Lsl,
        Lyd,
        Mad,
        Mdl,
        Mga,
        Mkd,
        Mmk,
        Mnt,
        Mop,
        Mru,
        Mur,
        Mvr,
        Mwk,
        Mxn,
        Myr,
        Mzn,
        Nad,
        Ngn,
        Nio,
        Nok,
        Npr,
        Nzd,
        Omr,
        Pab,
        Pen,
        Pgk,
        Php,
        Pkr,
        Pln,
        Pyg,
        Qar,
        Ron,
        Rsd,
        Rub,
        Rwf,
        Sar,
        Sbd,
        Scr,
        Sek,
        Sgd,
        Shp,
        Sle,
        Sll,
        Sos,
        Srd,
        Ssp,
        Stn,
        Svc,
        Szl,
        Thb,
        Tnd,
        Top,
        Try,
        Ttd,
        Twd,
        Tzs,
        Uah,
        Ugx,
        Usd,
        Uyu,
        Uzs,
        Ves,
        Vnd,
        Vuv,
        Wst,
        Xaf,
        Xcd,
        Xof,
        Xpf,
        Yer,
        Zar,
        Zmw,
    }

    public Value Known() =>
        _value switch
        {
            "AED" => Value.Aed,
            "ALL" => Value.All,
            "AMD" => Value.Amd,
            "ANG" => Value.Ang,
            "AOA" => Value.Aoa,
            "ARS" => Value.Ars,
            "AUD" => Value.Aud,
            "AWG" => Value.Awg,
            "AZN" => Value.Azn,
            "BAM" => Value.Bam,
            "BBD" => Value.Bbd,
            "BDT" => Value.Bdt,
            "BGN" => Value.Bgn,
            "BHD" => Value.Bhd,
            "BIF" => Value.Bif,
            "BMD" => Value.Bmd,
            "BND" => Value.Bnd,
            "BOB" => Value.Bob,
            "BRL" => Value.Brl,
            "BSD" => Value.Bsd,
            "BWP" => Value.Bwp,
            "BYN" => Value.Byn,
            "BZD" => Value.Bzd,
            "CAD" => Value.Cad,
            "CHF" => Value.Chf,
            "CLP" => Value.Clp,
            "CNY" => Value.Cny,
            "COP" => Value.Cop,
            "CRC" => Value.Crc,
            "CUP" => Value.Cup,
            "CVE" => Value.Cve,
            "CZK" => Value.Czk,
            "DJF" => Value.Djf,
            "DKK" => Value.Dkk,
            "DOP" => Value.Dop,
            "DZD" => Value.Dzd,
            "EGP" => Value.Egp,
            "ETB" => Value.Etb,
            "EUR" => Value.Eur,
            "FJD" => Value.Fjd,
            "FKP" => Value.Fkp,
            "GBP" => Value.Gbp,
            "GEL" => Value.Gel,
            "GHS" => Value.Ghs,
            "GIP" => Value.Gip,
            "GMD" => Value.Gmd,
            "GNF" => Value.Gnf,
            "GTQ" => Value.Gtq,
            "GYD" => Value.Gyd,
            "HKD" => Value.Hkd,
            "HNL" => Value.Hnl,
            "HRK" => Value.Hrk,
            "HTG" => Value.Htg,
            "HUF" => Value.Huf,
            "IDR" => Value.Idr,
            "ILS" => Value.Ils,
            "INR" => Value.Inr,
            "IQD" => Value.Iqd,
            "JMD" => Value.Jmd,
            "JOD" => Value.Jod,
            "JPY" => Value.Jpy,
            "KES" => Value.Kes,
            "KGS" => Value.Kgs,
            "KHR" => Value.Khr,
            "KMF" => Value.Kmf,
            "KRW" => Value.Krw,
            "KWD" => Value.Kwd,
            "KYD" => Value.Kyd,
            "KZT" => Value.Kzt,
            "LAK" => Value.Lak,
            "LBP" => Value.Lbp,
            "LKR" => Value.Lkr,
            "LRD" => Value.Lrd,
            "LSL" => Value.Lsl,
            "LYD" => Value.Lyd,
            "MAD" => Value.Mad,
            "MDL" => Value.Mdl,
            "MGA" => Value.Mga,
            "MKD" => Value.Mkd,
            "MMK" => Value.Mmk,
            "MNT" => Value.Mnt,
            "MOP" => Value.Mop,
            "MRU" => Value.Mru,
            "MUR" => Value.Mur,
            "MVR" => Value.Mvr,
            "MWK" => Value.Mwk,
            "MXN" => Value.Mxn,
            "MYR" => Value.Myr,
            "MZN" => Value.Mzn,
            "NAD" => Value.Nad,
            "NGN" => Value.Ngn,
            "NIO" => Value.Nio,
            "NOK" => Value.Nok,
            "NPR" => Value.Npr,
            "NZD" => Value.Nzd,
            "OMR" => Value.Omr,
            "PAB" => Value.Pab,
            "PEN" => Value.Pen,
            "PGK" => Value.Pgk,
            "PHP" => Value.Php,
            "PKR" => Value.Pkr,
            "PLN" => Value.Pln,
            "PYG" => Value.Pyg,
            "QAR" => Value.Qar,
            "RON" => Value.Ron,
            "RSD" => Value.Rsd,
            "RUB" => Value.Rub,
            "RWF" => Value.Rwf,
            "SAR" => Value.Sar,
            "SBD" => Value.Sbd,
            "SCR" => Value.Scr,
            "SEK" => Value.Sek,
            "SGD" => Value.Sgd,
            "SHP" => Value.Shp,
            "SLE" => Value.Sle,
            "SLL" => Value.Sll,
            "SOS" => Value.Sos,
            "SRD" => Value.Srd,
            "SSP" => Value.Ssp,
            "STN" => Value.Stn,
            "SVC" => Value.Svc,
            "SZL" => Value.Szl,
            "THB" => Value.Thb,
            "TND" => Value.Tnd,
            "TOP" => Value.Top,
            "TRY" => Value.Try,
            "TTD" => Value.Ttd,
            "TWD" => Value.Twd,
            "TZS" => Value.Tzs,
            "UAH" => Value.Uah,
            "UGX" => Value.Ugx,
            "USD" => Value.Usd,
            "UYU" => Value.Uyu,
            "UZS" => Value.Uzs,
            "VES" => Value.Ves,
            "VND" => Value.Vnd,
            "VUV" => Value.Vuv,
            "WST" => Value.Wst,
            "XAF" => Value.Xaf,
            "XCD" => Value.Xcd,
            "XOF" => Value.Xof,
            "XPF" => Value.Xpf,
            "YER" => Value.Yer,
            "ZAR" => Value.Zar,
            "ZMW" => Value.Zmw,
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

    public static Currency FromRaw(string value)
    {
        return new(value);
    }
}
