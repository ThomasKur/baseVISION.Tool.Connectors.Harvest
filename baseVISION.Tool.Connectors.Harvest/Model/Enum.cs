﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace baseVISION.Tool.Connectors.Harvest.Model
{

    public enum Currency {
            USD,
            EUR,
            GBP,
            AUD,
            CAD,
            JPY,
            AED,
            AFN,
            ALL,
            AMD,
            ANG,
            AOA,
            ARS,
            AWG,
            AZN,
            BAM,
            BBD,
            BDT,
            BGN,
            BHD,
            BIF,
            BMD,
            BND,
            BOB,
            BRL,
            BSD,
            BTN,
            BWP,
            BYN,
            BYR,
            BZD,
            CDF,
            CHF,
            CLF,
            CLP,
            CNY,
            COP,
            CRC,
            CUC,
            CUP,
            CVE,
            CZK,
            DJF,
            DKK,
            DOP,
            DZD,
            EGP,
            ERN,
            ETB,
            FJD,
            FKP,
            GEL,
            GHS,
            GIP,
            GMD,
            GNF,
            GTQ,
            GYD,
            HKD,
            HNL,
            HRK,
            HTG,
            HUF,
            IDR,
            ILS,
            INR,
            IQD,
            IRR,
            ISK,
            JMD,
            JOD,
            KES,
            KGS,
            KHR,
            KMF,
            KPW,
            KRW,
            KWD,
            KYD,
            KZT,
            LAK,
            LBP,
            LKR,
            LRD,
            LSL,
            LTL,
            LVL,
            LYD,
            MAD,
            MDL,
            MGA,
            MKD,
            MMK,
            MNT,
            MOP,
            MRO,
            MUR,
            MVR,
            MWK,
            MXN,
            MYR,
            MZN,
            NAD,
            NGN,
            NIO,
            NOK,
            NPR,
            NZD,
            OMR,
            PAB,
            PEN,
            PGK,
            PHP,
            PKR,
            PLN,
            PYG,
            QAR,
            RON,
            RSD,
            RUB,
            RWF,
            SAR,
            SBD,
            SCR,
            SDG,
            SEK,
            SGD,
            SHP,
            SKK,
            SLL,
            SOS,
            SRD,
            SSP,
            STD,
            SVC,
            SYP,
            SZL,
            THB,
            TJS,
            TMT,
            TND,
            TOP,
            TRY,
            TTD,
            TWD,
            TZS,
            UAH,
            UGX,
            UYU,
            UZS,
            VEF,
            VND,
            VUV,
            WST,
            XAF,
            XAG,
            XAU,
            XBA,
            XBB,
            XBC,
            XBD,
            XCD,
            XDR,
            XOF,
            XPD,
            XPF,
            XPT,
            YER,
            ZAR,
            ZMK,
            ZMW,
        }
    public enum BillBy { Project, Tasks, People, none }
    public enum BudgetBy { project, project_cost, task, task_fees, person, none }
    public enum EstimateState { draft, sent, accepted, declined }
    public enum HarvestTimezone
    {
        [EnumMember(Value = "Pago_Pago")] Pacific_Pago_Pago,
        [EnumMember(Value = "Midway")] Pacific_Midway,
        [EnumMember(Value = "Honolulu")] Pacific_Honolulu,
        [EnumMember(Value = "Juneau")] America_Juneau,
        [EnumMember(Value = "Los_Angeles")] America_Los_Angeles,
        [EnumMember(Value = "Tijuana")] America_Tijuana,
        [EnumMember(Value = "Phoenix")] America_Phoenix,
        [EnumMember(Value = "Chihuahua")] America_Chihuahua,
        [EnumMember(Value = "Mazatlan")] America_Mazatlan,
        [EnumMember(Value = "Denver")] America_Denver,
        [EnumMember(Value = "Guatemala")] America_Guatemala,
        [EnumMember(Value = "Chicago")] America_Chicago,
        [EnumMember(Value = "Mexico_City")] America_Mexico_City,
        [EnumMember(Value = "Monterrey")] America_Monterrey,
        [EnumMember(Value = "Regina")] America_Regina,
        [EnumMember(Value = "Bogota")] America_Bogota,
        [EnumMember(Value = "New_York")] America_New_York,
        [EnumMember(Value = "Indiana/Indianapolis")] America_Indiana_Indianapolis,
        [EnumMember(Value = "Lima")] America_Lima,
        [EnumMember(Value = "Halifax")] America_Halifax,
        [EnumMember(Value = "Caracas")] America_Caracas,
        [EnumMember(Value = "Guyana")] America_Guyana,
        [EnumMember(Value = "La_Paz")] America_La_Paz,
        [EnumMember(Value = "Santiago")] America_Santiago,
        [EnumMember(Value = "St_Johns")] America_St_Johns,
        [EnumMember(Value = "Sao_Paulo")] America_Sao_Paulo,
        [EnumMember(Value = "Argentina/Buenos_Aires")] America_Argentina_Buenos_Aires,
        [EnumMember(Value = "Godthab")] America_Godthab,
        [EnumMember(Value = "Montevideo")] America_Montevideo,
        [EnumMember(Value = "Atlantic/South_Georgia")] Atlantic_South_Georgia,
        [EnumMember(Value = "Atlantic/Azores")] Atlantic_Azores,
        [EnumMember(Value = "Atlantic/Cape_Verde")] Atlantic_Cape_Verde,
        [EnumMember(Value = "Casablanca")] Africa_Casablanca,
        [EnumMember(Value = "Dublin")] Europe_Dublin,
        [EnumMember(Value = "London")] Europe_London,
        [EnumMember(Value = "Lisbon")] Europe_Lisbon,
        [EnumMember(Value = "Monrovia")] Africa_Monrovia,
        [EnumMember(Value = "UTC")] Etc_UTC,
        [EnumMember(Value = "Amsterdam")] Europe_Amsterdam,
        [EnumMember(Value = "Belgrade")] Europe_Belgrade,
        [EnumMember(Value = "Berlin")] Europe_Berlin,
        [EnumMember(Value = "Zurich")] Europe_Zurich,
        [EnumMember(Value = "Bern")] Europe_Bern,
        [EnumMember(Value = "Bratislava")] Europe_Bratislava,
        [EnumMember(Value = "Brussels")] Europe_Brussels,
        [EnumMember(Value = "Budapest")] Europe_Budapest,
        [EnumMember(Value = "Copenhagen")] Europe_Copenhagen,
        [EnumMember(Value = "Ljubljana")] Europe_Ljubljana,
        [EnumMember(Value = "Madrid")] Europe_Madrid,
        [EnumMember(Value = "Paris")] Europe_Paris,
        [EnumMember(Value = "Prague")] Europe_Prague,
        [EnumMember(Value = "Rome")] Europe_Rome,
        [EnumMember(Value = "Sarajevo")] Europe_Sarajevo,
        [EnumMember(Value = "Skopje")] Europe_Skopje,
        [EnumMember(Value = "Stockholm")] Europe_Stockholm,
        [EnumMember(Value = "Vienna")] Europe_Vienna,
        [EnumMember(Value = "Warsaw")] Europe_Warsaw,
        [EnumMember(Value = "Algiers")] Africa_Algiers,
        [EnumMember(Value = "Zagreb")] Europe_Zagreb,
        [EnumMember(Value = "Athens")] Europe_Athens,
        [EnumMember(Value = "Bucharest")] Europe_Bucharest,
        [EnumMember(Value = "Cairo")] Africa_Cairo,
        [EnumMember(Value = "Harare")] Africa_Harare,
        [EnumMember(Value = "Helsinki")] Europe_Helsinki,
        [EnumMember(Value = "Jerusalem")] Asia_Jerusalem,
        [EnumMember(Value = "Kaliningrad")] Europe_Kaliningrad,
        [EnumMember(Value = "Kiev")] Europe_Kiev,
        [EnumMember(Value = "Johannesburg")] Africa_Johannesburg,
        [EnumMember(Value = "Riga")] Europe_Riga,
        [EnumMember(Value = "Sofia")] Europe_Sofia,
        [EnumMember(Value = "Tallinn")] Europe_Tallinn,
        [EnumMember(Value = "Vilnius")] Europe_Vilnius,
        [EnumMember(Value = "Baghdad")] Asia_Baghdad,
        [EnumMember(Value = "Istanbul")] Europe_Istanbul,
        [EnumMember(Value = "Kuwait")] Asia_Kuwait,
        [EnumMember(Value = "Minsk")] Europe_Minsk,
        [EnumMember(Value = "Moscow")] Europe_Moscow,
        [EnumMember(Value = "Nairobi")] Africa_Nairobi,
        [EnumMember(Value = "Riyadh")] Asia_Riyadh,
        [EnumMember(Value = "Volgograd")] Europe_Volgograd,
        [EnumMember(Value = "Tehran")] Asia_Tehran,
        [EnumMember(Value = "Muscat")] Asia_Muscat,
        [EnumMember(Value = "Baku")] Asia_Baku,
        [EnumMember(Value = "Samara")] Europe_Samara,
        [EnumMember(Value = "Tbilisi")] Asia_Tbilisi,
        [EnumMember(Value = "Yerevan")] Asia_Yerevan,
        [EnumMember(Value = "Kabul")] Asia_Kabul,
        [EnumMember(Value = "Yekaterinburg")] Asia_Yekaterinburg,
        [EnumMember(Value = "Karachi")] Asia_Karachi,
        [EnumMember(Value = "Tashkent")] Asia_Tashkent,
        [EnumMember(Value = "Kolkata")] Asia_Kolkata,
        [EnumMember(Value = "Colombo")] Asia_Colombo,
        [EnumMember(Value = "Kathmandu")] Asia_Kathmandu,
        [EnumMember(Value = "Almaty")] Asia_Almaty,
        [EnumMember(Value = "Urumqi")] Asia_Urumqi,
        [EnumMember(Value = "Rangoon")] Asia_Rangoon,
        [EnumMember(Value = "Bangkok")] Asia_Bangkok,
        [EnumMember(Value = "Jakarta")] Asia_Jakarta,
        [EnumMember(Value = "Krasnoyarsk")] Asia_Krasnoyarsk,
        [EnumMember(Value = "Novosibirsk")] Asia_Novosibirsk,
        [EnumMember(Value = "Shanghai")] Asia_Shanghai,
        [EnumMember(Value = "Chongqing")] Asia_Chongqing,
        [EnumMember(Value = "Hong_Kong")] Asia_Hong_Kong,
        [EnumMember(Value = "Irkutsk")] Asia_Irkutsk,
        [EnumMember(Value = "Kuala_Lumpur")] Asia_Kuala_Lumpur,
        [EnumMember(Value = "Perth")] Australia_Perth,
        [EnumMember(Value = "Singapore")] Asia_Singapore,
        [EnumMember(Value = "Taipei")] Asia_Taipei,
        [EnumMember(Value = "Ulaanbaatar")] Asia_Ulaanbaatar,
        [EnumMember(Value = "Tokyo")] Asia_Tokyo,
        [EnumMember(Value = "Seoul")] Asia_Seoul,
        [EnumMember(Value = "Yakutsk")] Asia_Yakutsk,
        [EnumMember(Value = "Adelaide")] Australia_Adelaide,
        [EnumMember(Value = "Darwin")] Australia_Darwin,
        [EnumMember(Value = "Brisbane")] Australia_Brisbane,
        [EnumMember(Value = "Melbourne")] Australia_Melbourne,
        [EnumMember(Value = "Guam")] Pacific_Guam,
        [EnumMember(Value = "Hobart")] Australia_Hobart,
        [EnumMember(Value = "Port_Moresby")] Pacific_Port_Moresby,
        [EnumMember(Value = "Sydney")] Australia_Sydney,
        [EnumMember(Value = "Vladivostok")] Asia_Vladivostok,
        [EnumMember(Value = "Magadan")] Asia_Magadan,
        [EnumMember(Value = "Noumea")] Pacific_Noumea,
        [EnumMember(Value = "Guadalcanal")] Pacific_Guadalcanal,
        [EnumMember(Value = "Srednekolymsk")] Asia_Srednekolymsk,
        [EnumMember(Value = "Auckland")] Pacific_Auckland,
        [EnumMember(Value = "Fiji")] Pacific_Fiji,
        [EnumMember(Value = "Kamchatka")] Asia_Kamchatka,
        [EnumMember(Value = "Majuro")] Pacific_Majuro,
        [EnumMember(Value = "Chatham")] Pacific_Chatham,
        [EnumMember(Value = "Tongatapu")] Pacific_Tongatapu,
        [EnumMember(Value = "Apia")] Pacific_Apia,
        [EnumMember(Value = "Fakaofo")] Pacific_Fakaofo,
    }
}