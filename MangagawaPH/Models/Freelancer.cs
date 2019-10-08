using System;
using System.Collections.Generic;
using System.Text;

namespace MangagawaPH.Models
{
    class Freelancer
    {
        public int FreelancerId { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public DateTime Birthday { get; set; }
        public string Email { get; set; }
        public Contact ContactInfo { get; set; }
        public LocationInfo Location { get; set; }
        public List<ExpHistory> Experience { get; set; }
        public int JobType { get; set; }
        public int DailyRate { get; set; }
        public List<RevHistory> Reviews { get; set; }
        public string Password { get; set; }
    }
    class LocationInfo
    {
        public string Barangay { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
    }
    class Contact
    {
        public string CellphoneNo { get; set; }
        public string LandlineNo { get; set; }        
    }
    class ExpHistory
    {
        public string ClientName { get; set; }
        public string ClientContact { get; set; }
    }
    class RevHistory
    {
        public int RevId { get; set; }
        public int RevType { get; set; }
        public string RevDesc { get; set; }
    }
}
