using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ValueChain.ViewModels
{
    public class OffTakersAnalysisVm
    {
        public string OrganizationCode { get; set; }
        public string OrganizationName { get; set; }
        public int StudioAptEquityCount { get; set; }
        public int StudioAptCount { get; set; }
        public int OneBedRmCount { get; set; }
        public int TwoBedRmCount { get; set; }
        public int ThreeBedRmCount { get; set; }
        public int FourBedRmDuplexCount { get; set; }
        public int PQStudioAptEquityCount { get; set; }
        public int PQStudioAptCount { get; set; }
        public int PQOneBedRmCount { get; set; }
        public int PQTwoBedRmCount { get; set; }
        public int PQThreeBedRmCount { get; set; }
        public int PQFourBedRmDuplexCount { get; set; }
        public int ChoiceAffordabilityMatchStudioAptEquityCount { get; set; }
        public int ChoiceAffordabilityMatchStudioAptCount { get; set; }
        public int ChoiceAffordabilityMatchOneBedRmCount { get; set; }
        public int ChoiceAffordabilityMatchTwoBedRmCount { get; set; }
        public int ChoiceAffordabilityMatchThreeBedRmCount { get; set; }
        public int ChoiceAffordabilityMatchFourBedDuplexCount { get; set; }
        public int ChoiceAffordabilityMatchTotalCount { get; set; }
        public int TotalCount { get; set; }
    }          
}              
