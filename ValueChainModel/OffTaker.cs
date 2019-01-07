using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueChainModel
{
    public class OffTaker
    {
        public int OffTakerId { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public string NHFNumber { get; set; }
        public string OrganizationName { get; set; }
        public string GradeLevel { get; set; }
        public string HouseChoice { get; set; }
        public string PhoneNumber { get; set; }
        public int Rate { get; set; }
        public decimal LoanApplicable { get; set; }
        public decimal Repayment { get; set; }
        public double DTI { get; set; }
        public decimal NetIncome { get; set; }
        public decimal GrossIncome { get; set; }
        public int Tenor { get; set; }
        public decimal HomeAffordability { get; set; }
        public decimal Equity { get; set; }
        public bool Matched { get; set; }
    }
}
