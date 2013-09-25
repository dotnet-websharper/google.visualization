// $begin{copyright}
//
// This file is confidential and proprietary.
//
// Copyright (c) IntelliFactory, 2004-2010.
//
// All rights reserved.  Reproduction or use in whole or in part is
// prohibited without the written consent of the copyright holder.
//-----------------------------------------------------------------
// $end{copyright}

namespace IntelliFactory.WebSharper.Google.Visualization.Visualizations

open Microsoft.FSharp.Quotations
open IntelliFactory.WebSharper
open IntelliFactory.WebSharper.Google.Visualization
open IntelliFactory.WebSharper.Google.Visualization.Base
open IntelliFactory.WebSharper.Google.Visualization.Base.Helpers

/// Dummy type to simulate the region enumeration.
type Region =
    [<Inline "$s">]
    static member FromString (s: string) : Region = X

module Countries =

    // ISO 3166-1 alpha-2 Codes.
    module Alpha2Codes =
        /// Afghanistan
        [<Inline "'AF'" >]
        let AF : Region = X

        /// Aland Islands ﻿ Åland Islands
        [<Inline "'AX'" >]
        let AX : Region = X

        /// Albania
        [<Inline "'AL'" >]
        let AL : Region = X

        /// Algeria
        [<Inline "'DZ'" >]
        let DZ : Region = X

        /// American Samoa
        [<Inline "'AS'" >]
        let AS : Region = X

        /// Andorra
        [<Inline "'AD'" >]
        let AD : Region = X

        /// Angola
        [<Inline "'AO'" >]
        let AO : Region = X

        /// Anguilla
        [<Inline "'AI'" >]
        let AI : Region = X

        /// Antarctica
        [<Inline "'AQ'" >]
        let AQ : Region = X

        /// Antigua and Barbuda
        [<Inline "'AG'" >]
        let AG : Region = X

        /// Argentina
        [<Inline "'AR'" >]
        let AR : Region = X

        /// Armenia
        [<Inline "'AM'" >]
        let AM : Region = X

        /// Aruba
        [<Inline "'AW'" >]
        let AW : Region = X

        /// Australia
        [<Inline "'AU'" >]
        let AU : Region = X

        /// Austria
        [<Inline "'AT'" >]
        let AT : Region = X

        /// Azerbaijan
        [<Inline "'AZ'" >]
        let AZ : Region = X

        /// Bahamas
        [<Inline "'BS'" >]
        let BS : Region = X

        /// Bahrain
        [<Inline "'BH'" >]
        let BH : Region = X

        /// Bangladesh
        [<Inline "'BD'" >]
        let BD : Region = X

        /// Barbados
        [<Inline "'BB'" >]
        let BB : Region = X

        /// Belarus
        [<Inline "'BY'" >]
        let BY : Region = X

        /// Belgium
        [<Inline "'BE'" >]
        let BE : Region = X

        /// Belize
        [<Inline "'BZ'" >]
        let BZ : Region = X

        /// Benin
        [<Inline "'BJ'" >]
        let BJ : Region = X

        /// Bermuda
        [<Inline "'BM'" >]
        let BM : Region = X

        /// Bhutan
        [<Inline "'BT'" >]
        let BT : Region = X

        /// Bolivia, Plurinational State of
        [<Inline "'BO'" >]
        let BO : Region = X

        /// Bosnia and Herzegovina
        [<Inline "'BA'" >]
        let BA : Region = X

        /// Botswana
        [<Inline "'BW'" >]
        let BW : Region = X

        /// Bouvet Island
        [<Inline "'BV'" >]
        let BV : Region = X

        /// Brazil
        [<Inline "'BR'" >]
        let BR : Region = X

        /// British Indian Ocean Territory
        [<Inline "'IO'" >]
        let IO : Region = X

        /// Brunei Darussalam
        [<Inline "'BN'" >]
        let BN : Region = X

        /// Bulgaria
        [<Inline "'BG'" >]
        let BG : Region = X

        /// Burkina Faso
        [<Inline "'BF'" >]
        let BF : Region = X

        /// Burundi
        [<Inline "'BI'" >]
        let BI : Region = X

        /// Cambodia
        [<Inline "'KH'" >]
        let KH : Region = X

        /// Cameroon
        [<Inline "'CM'" >]
        let CM : Region = X

        /// Canada
        [<Inline "'CA'" >]
        let CA : Region = X

        /// Cape Verde
        [<Inline "'CV'" >]
        let CV : Region = X

        /// Cayman Islands
        [<Inline "'KY'" >]
        let KY : Region = X

        /// Central African Republic
        [<Inline "'CF'" >]
        let CF : Region = X

        /// Chad
        [<Inline "'TD'" >]
        let TD : Region = X

        /// Chile
        [<Inline "'CL'" >]
        let CL : Region = X

        /// China
        [<Inline "'CN'" >]
        let CN : Region = X

        /// Christmas Island
        [<Inline "'CX'" >]
        let CX : Region = X

        /// Cocos (Keeling) Islands
        [<Inline "'CC'" >]
        let CC : Region = X

        /// Colombia
        [<Inline "'CO'" >]
        let CO : Region = X

        /// Comoros
        [<Inline "'KM'" >]
        let KM : Region = X

        /// Congo
        [<Inline "'CG'" >]
        let CG : Region = X

        /// Congo, the Democratic Republic of the
        [<Inline "'CD'" >]
        let CD : Region = X

        /// Cook Islands
        [<Inline "'CK'" >]
        let CK : Region = X

        /// Costa Rica
        [<Inline "'CR'" >]
        let CR : Region = X

        /// Cote d'Ivoire ﻿ Côte d'Ivoire
        [<Inline "'CI'" >]
        let CI : Region = X

        /// Croatia
        [<Inline "'HR'" >]
        let HR : Region = X

        /// Cuba
        [<Inline "'CU'" >]
        let CU : Region = X

        /// Cyprus
        [<Inline "'CY'" >]
        let CY : Region = X

        /// Czech Republic
        [<Inline "'CZ'" >]
        let CZ : Region = X

        /// Denmark
        [<Inline "'DK'" >]
        let DK : Region = X

        /// Djibouti
        [<Inline "'DJ'" >]
        let DJ : Region = X

        /// Dominica
        [<Inline "'DM'" >]
        let DM : Region = X

        /// Dominican Republic
        [<Inline "'DO'" >]
        let DO : Region = X

        /// Ecuador
        [<Inline "'EC'" >]
        let EC : Region = X

        /// Egypt
        [<Inline "'EG'" >]
        let EG : Region = X

        /// El Salvador
        [<Inline "'SV'" >]
        let SV : Region = X

        /// Equatorial Guinea
        [<Inline "'GQ'" >]
        let GQ : Region = X

        /// Eritrea
        [<Inline "'ER'" >]
        let ER : Region = X

        /// Estonia
        [<Inline "'EE'" >]
        let EE : Region = X

        /// Ethiopia
        [<Inline "'ET'" >]
        let ET : Region = X

        /// Falkland Islands (Malvinas
        [<Inline "'FK'" >]
        let FK : Region = X

        /// Faroe Islands
        [<Inline "'FO'" >]
        let FO : Region = X

        /// Fiji
        [<Inline "'FJ'" >]
        let FJ : Region = X

        /// Finland
        [<Inline "'FI'" >]
        let FI : Region = X

        /// France
        [<Inline "'FR'" >]
        let FR : Region = X

        /// French Guiana
        [<Inline "'GF'" >]
        let GF : Region = X

        /// French Polynesia
        [<Inline "'PF'" >]
        let PF : Region = X

        /// French Southern Territories
        [<Inline "'TF'" >]
        let TF : Region = X

        /// Gabon
        [<Inline "'GA'" >]
        let GA : Region = X

        /// Gambia
        [<Inline "'GM'" >]
        let GM : Region = X

        /// Georgia
        [<Inline "'GE'" >]
        let GE : Region = X

        /// Germany
        [<Inline "'DE'" >]
        let DE : Region = X

        /// Ghana
        [<Inline "'GH'" >]
        let GH : Region = X

        /// Gibraltar
        [<Inline "'GI'" >]
        let GI : Region = X

        /// Greece
        [<Inline "'GR'" >]
        let GR : Region = X

        /// Greenland
        [<Inline "'GL'" >]
        let GL : Region = X

        /// Grenada
        [<Inline "'GD'" >]
        let GD : Region = X

        /// Guadeloupe
        [<Inline "'GP'" >]
        let GP : Region = X

        /// Guam
        [<Inline "'GU'" >]
        let GU : Region = X

        /// Guatemala
        [<Inline "'GT'" >]
        let GT : Region = X

        /// Guernsey
        [<Inline "'GG'" >]
        let GG : Region = X

        /// Guinea
        [<Inline "'GN'" >]
        let GN : Region = X

        /// Guinea-Bissau
        [<Inline "'GW'" >]
        let GW : Region = X

        /// Guyana
        [<Inline "'GY'" >]
        let GY : Region = X

        /// Haiti
        [<Inline "'HT'" >]
        let HT : Region = X

        /// Heard Island and McDonald Islands
        [<Inline "'HM'" >]
        let HM : Region = X

        /// Holy See (Vatican City State
        [<Inline "'VA'" >]
        let VA : Region = X

        /// Honduras
        [<Inline "'HN'" >]
        let HN : Region = X

        /// Hong Kong
        [<Inline "'HK'" >]
        let HK : Region = X

        /// Hungary
        [<Inline "'HU'" >]
        let HU : Region = X

        /// Iceland
        [<Inline "'IS'" >]
        let IS : Region = X

        /// India
        [<Inline "'IN'" >]
        let IN : Region = X

        /// Indonesia
        [<Inline "'ID'" >]
        let ID : Region = X

        /// Iran, Islamic Republic of
        [<Inline "'IR'" >]
        let IR : Region = X

        /// Iraq
        [<Inline "'IQ'" >]
        let IQ : Region = X

        /// Ireland
        [<Inline "'IE'" >]
        let IE : Region = X

        /// Isle of Man
        [<Inline "'IM'" >]
        let IM : Region = X

        /// Israel
        [<Inline "'IL'" >]
        let IL : Region = X

        /// Italy
        [<Inline "'IT'" >]
        let IT : Region = X

        /// Jamaica
        [<Inline "'JM'" >]
        let JM : Region = X

        /// Japan
        [<Inline "'JP'" >]
        let JP : Region = X

        /// Jersey
        [<Inline "'JE'" >]
        let JE : Region = X

        /// Jordan
        [<Inline "'JO'" >]
        let JO : Region = X

        /// Kazakhstan
        [<Inline "'KZ'" >]
        let KZ : Region = X

        /// Kenya
        [<Inline "'KE'" >]
        let KE : Region = X

        /// Kiribati
        [<Inline "'KI'" >]
        let KI : Region = X

        /// Korea, Democratic People's Republic of
        [<Inline "'KP'" >]
        let KP : Region = X

        /// Korea, Republic of
        [<Inline "'KR'" >]
        let KR : Region = X

        /// Kuwait
        [<Inline "'KW'" >]
        let KW : Region = X

        /// Kyrgyzstan
        [<Inline "'KG'" >]
        let KG : Region = X

        /// Lao People's Democratic Republic
        [<Inline "'LA'" >]
        let LA : Region = X

        /// Latvia
        [<Inline "'LV'" >]
        let LV : Region = X

        /// Lebanon
        [<Inline "'LB'" >]
        let LB : Region = X

        /// Lesotho
        [<Inline "'LS'" >]
        let LS : Region = X

        /// Liberia
        [<Inline "'LR'" >]
        let LR : Region = X

        /// Libyan Arab Jamahiriya
        [<Inline "'LY'" >]
        let LY : Region = X

        /// Liechtenstein
        [<Inline "'LI'" >]
        let LI : Region = X

        /// Lithuania
        [<Inline "'LT'" >]
        let LT : Region = X

        /// Luxembourg
        [<Inline "'LU'" >]
        let LU : Region = X

        /// Macao
        [<Inline "'MO'" >]
        let MO : Region = X

        /// Macedonia, the former Yugoslav Republic of
        [<Inline "'MK'" >]
        let MK : Region = X

        /// Madagascar
        [<Inline "'MG'" >]
        let MG : Region = X

        /// Malawi
        [<Inline "'MW'" >]
        let MW : Region = X

        /// Malaysia
        [<Inline "'MY'" >]
        let MY : Region = X

        /// Maldives
        [<Inline "'MV'" >]
        let MV : Region = X

        /// Mali
        [<Inline "'ML'" >]
        let ML : Region = X

        /// Malta
        [<Inline "'MT'" >]
        let MT : Region = X

        /// Marshall Islands
        [<Inline "'MH'" >]
        let MH : Region = X

        /// Martinique
        [<Inline "'MQ'" >]
        let MQ : Region = X

        /// Mauritania
        [<Inline "'MR'" >]
        let MR : Region = X

        /// Mauritius
        [<Inline "'MU'" >]
        let MU : Region = X

        /// Mayotte
        [<Inline "'YT'" >]
        let YT : Region = X

        /// Mexico
        [<Inline "'MX'" >]
        let MX : Region = X

        /// Micronesia, Federated States of
        [<Inline "'FM'" >]
        let FM : Region = X

        /// Moldova, Republic of
        [<Inline "'MD'" >]
        let MD : Region = X

        /// Monaco
        [<Inline "'MC'" >]
        let MC : Region = X

        /// Mongolia
        [<Inline "'MN'" >]
        let MN : Region = X

        /// Montenegro
        [<Inline "'ME'" >]
        let ME : Region = X

        /// Montserrat
        [<Inline "'MS'" >]
        let MS : Region = X

        /// Morocco
        [<Inline "'MA'" >]
        let MA : Region = X

        /// Mozambique
        [<Inline "'MZ'" >]
        let MZ : Region = X

        /// Myanmar
        [<Inline "'MM'" >]
        let MM : Region = X

        /// Namibia
        [<Inline "'NA'" >]
        let NA : Region = X

        /// Nauru
        [<Inline "'NR'" >]
        let NR : Region = X

        /// Nepal
        [<Inline "'NP'" >]
        let NP : Region = X

        /// Netherlands
        [<Inline "'NL'" >]
        let NL : Region = X

        /// Netherlands Antilles
        [<Inline "'AN'" >]
        let AN : Region = X

        /// New Caledonia
        [<Inline "'NC'" >]
        let NC : Region = X

        /// New Zealand
        [<Inline "'NZ'" >]
        let NZ : Region = X

        /// Nicaragua
        [<Inline "'NI'" >]
        let NI : Region = X

        /// Niger
        [<Inline "'NE'" >]
        let NE : Region = X

        /// Nigeria
        [<Inline "'NG'" >]
        let NG : Region = X

        /// Niue
        [<Inline "'NU'" >]
        let NU : Region = X

        /// Norfolk Island
        [<Inline "'NF'" >]
        let NF : Region = X

        /// Northern Mariana Islands
        [<Inline "'MP'" >]
        let MP : Region = X

        /// Norway
        [<Inline "'NO'" >]
        let NO : Region = X

        /// Oman
        [<Inline "'OM'" >]
        let OM : Region = X

        /// Pakistan
        [<Inline "'PK'" >]
        let PK : Region = X

        /// Palau
        [<Inline "'PW'" >]
        let PW : Region = X

        /// Palestinian Territory, Occupied
        [<Inline "'PS'" >]
        let PS : Region = X

        /// Panama
        [<Inline "'PA'" >]
        let PA : Region = X

        /// Papua New Guinea
        [<Inline "'PG'" >]
        let PG : Region = X

        /// Paraguay
        [<Inline "'PY'" >]
        let PY : Region = X

        /// Peru
        [<Inline "'PE'" >]
        let PE : Region = X

        /// Philippines
        [<Inline "'PH'" >]
        let PH : Region = X

        /// Pitcairn
        [<Inline "'PN'" >]
        let PN : Region = X

        /// Poland
        [<Inline "'PL'" >]
        let PL : Region = X

        /// Portugal
        [<Inline "'PT'" >]
        let PT : Region = X

        /// Puerto Rico
        [<Inline "'PR'" >]
        let PR : Region = X

        /// Qatar
        [<Inline "'QA'" >]
        let QA : Region = X

        /// Reunion ﻿ Réunion
        [<Inline "'RE'" >]
        let RE : Region = X

        /// Romania
        [<Inline "'RO'" >]
        let RO : Region = X

        /// Russian Federation
        [<Inline "'RU'" >]
        let RU : Region = X

        /// Rwanda
        [<Inline "'RW'" >]
        let RW : Region = X

        /// Saint Barthélemy
        [<Inline "'BL'" >]
        let BL : Region = X

        /// Saint Helena
        [<Inline "'SH'" >]
        let SH : Region = X

        /// Saint Kitts and Nevis
        [<Inline "'KN'" >]
        let KN : Region = X

        /// Saint Lucia
        [<Inline "'LC'" >]
        let LC : Region = X

        /// Saint Martin (French part)
        [<Inline "'MF'" >]
        let MF : Region = X

        /// Saint Pierre and Miquelon
        [<Inline "'PM'" >]
        let PM : Region = X

        /// Saint Vincent and the Grenadines
        [<Inline "'VC'" >]
        let VC : Region = X

        /// Samoa
        [<Inline "'WS'" >]
        let WS : Region = X

        /// San Marino
        [<Inline "'SM'" >]
        let SM : Region = X

        /// Sao Tome and Principe
        [<Inline "'ST'" >]
        let ST : Region = X

        /// Saudi Arabia
        [<Inline "'SA'" >]
        let SA : Region = X

        /// Senegal
        [<Inline "'SN'" >]
        let SN : Region = X

        /// Serbia
        [<Inline "'RS'" >]
        let RS : Region = X

        /// Seychelles
        [<Inline "'SC'" >]
        let SC : Region = X

        /// Sierra Leone
        [<Inline "'SL'" >]
        let SL : Region = X

        /// Singapore
        [<Inline "'SG'" >]
        let SG : Region = X

        /// Slovakia
        [<Inline "'SK'" >]
        let SK : Region = X

        /// Slovenia
        [<Inline "'SI'" >]
        let SI : Region = X

        /// Solomon Islands
        [<Inline "'SB'" >]
        let SB : Region = X

        /// Somalia
        [<Inline "'SO'" >]
        let SO : Region = X

        /// South Africa
        [<Inline "'ZA'" >]
        let ZA : Region = X

        /// South Georgia and the South Sandwich Islands
        [<Inline "'GS'" >]
        let GS : Region = X

        /// Spain
        [<Inline "'ES'" >]
        let ES : Region = X

        /// Sri Lanka
        [<Inline "'LK'" >]
        let LK : Region = X

        /// Sudan
        [<Inline "'SD'" >]
        let SD : Region = X

        /// Suriname
        [<Inline "'SR'" >]
        let SR : Region = X

        /// Svalbard and Jan Mayen
        [<Inline "'SJ'" >]
        let SJ : Region = X

        /// Swaziland
        [<Inline "'SZ'" >]
        let SZ : Region = X

        /// Sweden
        [<Inline "'SE'" >]
        let SE : Region = X

        /// Switzerland
        [<Inline "'CH'" >]
        let CH : Region = X

        /// Syrian Arab Republic
        [<Inline "'SY'" >]
        let SY : Region = X

        /// Taiwan, Province of China
        [<Inline "'TW'" >]
        let TW : Region = X

        /// Tajikistan
        [<Inline "'TJ'" >]
        let TJ : Region = X

        /// Tanzania, United Republic of
        [<Inline "'TZ'" >]
        let TZ : Region = X

        /// Thailand
        [<Inline "'TH'" >]
        let TH : Region = X

        /// Timor-Leste
        [<Inline "'TL'" >]
        let TL : Region = X

        /// Togo
        [<Inline "'TG'" >]
        let TG : Region = X

        /// Tokelau
        [<Inline "'TK'" >]
        let TK : Region = X

        /// Tonga
        [<Inline "'TO'" >]
        let TO : Region = X

        /// Trinidad and Tobago
        [<Inline "'TT'" >]
        let TT : Region = X

        /// Tunisia
        [<Inline "'TN'" >]
        let TN : Region = X

        /// Turkey
        [<Inline "'TR'" >]
        let TR : Region = X

        /// Turkmenistan
        [<Inline "'TM'" >]
        let TM : Region = X

        /// Turks and Caicos Islands
        [<Inline "'TC'" >]
        let TC : Region = X

        /// Tuvalu
        [<Inline "'TV'" >]
        let TV : Region = X

        /// Uganda
        [<Inline "'UG'" >]
        let UG : Region = X

        /// Ukraine
        [<Inline "'UA'" >]
        let UA : Region = X

        /// United Arab Emirates
        [<Inline "'AE'" >]
        let AE : Region = X

        /// United Kingdom
        [<Inline "'GB'" >]
        let GB : Region = X

        /// United States
        [<Inline "'US'" >]
        let US : Region = X

        /// United States Minor Outlying Islands
        [<Inline "'UM'" >]
        let UM : Region = X

        /// Uruguay
        [<Inline "'UY'" >]
        let UY : Region = X

        /// Uzbekistan
        [<Inline "'UZ'" >]
        let UZ : Region = X

        /// Vanuatu
        [<Inline "'VU'" >]
        let VU : Region = X

        /// Venezuela, Bolivarian Republic of
        [<Inline "'VE'" >]
        let VE : Region = X

        /// Viet Nam
        [<Inline "'VN'" >]
        let VN : Region = X

        /// Virgin Islands, British
        [<Inline "'VG'" >]
        let VG : Region = X

        /// Virgin Islands, U.S
        [<Inline "'VI'" >]
        let VI : Region = X

        /// Wallis and Futuna
        [<Inline "'WF'" >]
        let WF : Region = X

        /// Western Sahara
        [<Inline "'EH'" >]
        let EH : Region = X

        /// Yemen
        [<Inline "'YE'" >]
        let YE : Region = X

        /// Zambia
        [<Inline "'ZM'" >]
        let ZM : Region = X

        /// Zimbabwe
        [<Inline "'ZW'" >]
        let ZW : Region = X

/// Other regions supported by the GeoMap
module Other =
    [<Inline "'world'" >]
    let World : Region = X

    [<Inline "'005'" >]
    let SouthAmerica : Region = X

    [<Inline "'013'" >]
    let CentralAmerica : Region = X

    [<Inline "'021'" >]
    let NorthAmerica : Region = X

    [<Inline "'002'" >]
    let Africa : Region = X

    [<Inline "'017'" >]
    let CentralAfrica : Region = X

    [<Inline "'015'" >]
    let NorthernAfrica : Region = X

    [<Inline "'018'" >]
    let SouthernAfrica : Region = X

    [<Inline "'030'" >]
    let EasternAsia : Region = X

    [<Inline "'034'" >]
    let SouthernAsia : Region = X

    [<Inline "'035'" >]
    let PacificAsia : Region = X

    [<Inline "'143'" >]
    let CentralAsia : Region = X

    [<Inline "'145'" >]
    let MiddleEast : Region = X

    [<Inline "'151'" >]
    let NorthernAsia : Region = X

    [<Inline "'154'" >]
    let NorthernEurope : Region = X

    [<Inline "'155'" >]
    let WesternEurope : Region = X

    [<Inline "'039'" >]
    let SouthernEurope : Region = X

