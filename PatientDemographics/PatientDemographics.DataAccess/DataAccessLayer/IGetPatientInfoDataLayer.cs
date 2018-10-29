using System.Collections.Generic;
using PatientDemographics.Models;

namespace PatientDemographics.DataAccessLayer
{
    public interface IGetPatientInfoDataLayer
    {
        List<PatientInfo> getPatientInfo();
    }
}
