using System;

namespace Healthcare
{
    public class Patient
    { 

        public int Id { get; set; }
        
        public string Name { get; set; }

        public string HospitalAdmitted { get; set; }
        public string Benefits { get; set; }

        public string Insurance { get; set; }
        public string Summary { get; set; }
    }
}
