﻿using Domain.entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Models
{
    public enum PaysVm
    {
    Afghanistan,
    Albania,
        Algeria,
        America,
        Andorra,
        Angola,
        Antigua,
        Argentina,
        Armenia,
        Australia,
        Austria,
        Azerbaijan,
        Bahamas,
        Bahrain,
        Bangladesh,
        Barbados,
        Belarus,
        Belgium,
        Belize,
        Benin,
        Bhutan,
        Bissau,
        Bolivia,
        Bosnia,
        Botswana,
        Brazil,
        British,
        Brunei,
        Bulgaria,
        Burkina,
        Burma,
        Burundi,
        Cambodia,
        Cameroon,
        Canada,
        Cape_Verde,
        Central_African_Republic,
        Chad,
        Chile,
        China,
        Colombia,
        Comoros,
        Congo,
        Costa_Rica,
        Croatia,
        Cuba,
        Cyprus,
        Czech,
        Denmark,
        Djibouti,
        Dominica,
        East_Timor,
        Ecuador,
        Egypt,
        El_Salvador,
        Emirate,
        England,
        Eritrea,
        Estonia,
        Ethiopia,
        Fiji,
        Finland,
        France,
        Gabon,
        Gambia,
        Georgia,
        Germany,
        Ghana,
        Great_Britain,
        Greece,
        Grenada,
        Grenadines,
        Guatemala,
        Guinea,
        Guyana,
        Haiti,
        Herzegovina,
        Holland,
        Honduras,
        Hungary,
        Iceland,
        India,
        Indonesia,
        Iran,
        Iraq,
        Ireland,
        Israel,
        Italy,
        IvoryCoast,
        Jamaica,
        Japan,
        Jordan,
        Kazakhstan,
        Kenya,
        Kiribati,
        Korea,
        Kosovo,
        Kuwait,
        Kyrgyzstan,
        Laos,
        Latvia,
        Lebanon,
        Lesotho,
        Liberia,
        Libya,
        Liechtenstein,
        Lithuania,
        Luxembourg,
        Macedonia,
        Madagascar,
        Malawi,
        Malaysia,
        Maldives,
        Mali,
        Malta,
        Marshall,
        Mauritania,
        Mauritius,
        Mexico,
        Micronesia,
        Moldova,
        Monaco,
        Mongolia,
        Montenegro,
        Morocco,
        Mozambique,
        Myanmar,
        Namibia,
        Nauru,
        Nepal,
        Netherlands,
        New_Zealand,
        Nicaragua,
        Niger,
        Nigeria,
        Norway,
        Oman,
        Pakistan,
        Palau,
        Panama,
        Papua,
        Paraguay,
        Peru,
        Philippines,
        Poland,
        Portugal,
        Qatar,
        Romania,
        Russia,
        Rwanda,
        Samoa,
        San_Marino,
        Sao_Tome,
        Saudi_Arabia,
        Scotland,
        Scottish,
        Senegal,
        Serbia,
        Seychelles,
        Sierra_Leone,
        Singapore,
        Slovakia,
        Slovenia,
        Solomon,
        Somalia,
        South_Africa,
        South_Sudan,
        Spain,
        Sri_Lanka,
        St_Kitts,
        St_Lucia,
        Sudan,
        Suriname,
        Swaziland,
        Sweden,
        Switzerland,
        Syria,
        Taiwan,
        Tajikistan,
        Tanzania,
        Thailand,
        Tobago,
        Togo,
        Tonga,
        Trinidad,
        Tunisia,
        Turkey,
        Turkmenistan,
        Tuvalu,
        Uganda,
        Ukraine,
        United_Kingdom,
        United_States,
        Uruguay,
        USA,
        Uzbekistan,
        Vanuatu,
        Vatican,
        Venezuela,
        Vietnam,
        Wales,
        Welsh,
        Yemen,
        Zambia,
        Zimbabwe,
    }
    public class ApplicantVm : UserVm
    {
        public ApplicantVm()
        {
            this.tests = new Collection<TestVm>();
            this.testpassed = new Collection<TestVm>();
        }
        [Required(ErrorMessage ="this field is required")]
        [Range(18,100)]
        public int age { get; set; }

        [StringLength(255)]
        public string applicantState { get; set; }

        public int chanceOfSuccess { get; set; }

        [Required(ErrorMessage = "this field is required")]
        public PaysVm country { get; set; }
        /*public int? idArrival { get; set; }
        public int? idDemand { get; set; }*/
        public virtual arrival arrival { get; set; }
        public virtual demand demand { get; set; }
        public virtual Collection<TestVm> tests { get; set; }
        public virtual Collection<TestVm> testpassed { get; set; }
        public ArrivalVm arrivalvm { get; set; }
    }
}