namespace SSH.Core.Enum
{
    public enum AppointmentStatus
    {
        None,
        Pending,    // At first time when appointment is placed it comes in pending.
        Cancel,     // User can cancel the appnt. when patient told to cancel.
        Completed   // User can completed, when Dr. completed to see the patient.
    }
}
