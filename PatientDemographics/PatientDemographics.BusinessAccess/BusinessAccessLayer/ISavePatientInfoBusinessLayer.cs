using PatientDemographics.Models;

namespace PatientDemographics.BusinessAccessLayer
{
    public interface ISavePatientInfoBusinessLayer
    {
        void savePatientData(PatientInfo patientData);
    }
}
