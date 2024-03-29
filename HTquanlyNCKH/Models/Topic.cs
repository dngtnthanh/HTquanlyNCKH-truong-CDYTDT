//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HTquanlyNCKH.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Topic
    {
        public int topicID { get; set; }
        public int scientistID { get; set; }
        public int classifiID { get; set; }
        public int statusID { get; set; }
        public Nullable<int> acceptsID { get; set; }
        public int fieldID { get; set; }
        public string tpcYear { get; set; }
        public string tpcName { get; set; }
        public string tpcSummary { get; set; }
        public string tpcCode { get; set; }
        public Nullable<System.DateTime> tpcStartDate { get; set; }
        public Nullable<System.DateTime> tpcEndDate { get; set; }
        public Nullable<System.DateTime> tpcDateOfAcceptance { get; set; }
        public string tpcProofFile { get; set; }
        public string tpcReviewBoard { get; set; }
        public Nullable<System.DateTime> tpcCreateData { get; set; }
        public Nullable<System.DateTime> tpcModifierData { get; set; }
        public Nullable<int> tpcCreateUser { get; set; }
        public Nullable<int> tpcModifierUser { get; set; }
        public Nullable<System.DateTime> tpcDeleteData { get; set; }
        public Nullable<int> tpcDeleteUser { get; set; }
        public string tpcImage { get; set; }
        public string tpcAcceptance { get; set; }
        public string tpcFile { get; set; }

        public string scientistIDs { get; set; }
        [NotMapped]
        public IEnumerable<ScientistFull> ScientistsCollection { get; set; }

        [NotMapped]
        public string[] ScientistIDArray { get; set; }
    }
}
