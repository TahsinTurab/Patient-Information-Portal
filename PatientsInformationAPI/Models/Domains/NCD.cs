﻿using PatientsInformationAPI.Models.RelationshipModel;

namespace PatientsInformationAPI.Models.Domains
{
    public class NCD
    {
        public Guid ID { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public ICollection<NCD_Details> Patients { get; set; }
    }
}
