using System.Collections.Generic;
using PatientDemographics.BusinessAccessLayer;
using PatientDemographics.Models;

namespace PatientDemographics.BusinessAccessLayer
{
    public interface IGetPatientInfoBusinessLayer
    {
       List<PatientInfo> getPatientData();
    }
}
