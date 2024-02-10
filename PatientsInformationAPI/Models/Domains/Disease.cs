﻿using PatientsInformationAPI.Models.RelationshipModel;
using System.ComponentModel.DataAnnotations;

namespace PatientsInformationAPI.Models.Domains
{
    public class Disease
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
    }
}
