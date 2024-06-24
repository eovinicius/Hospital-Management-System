using Hospital.Domain.Entities;
using Hospital.Domain.Enums;


namespace Hospital.Test.Domain.Entities;

public class AppointmentTest
{
    [Fact]
    public void Should_make_a_consultation()
    {
        var date = DateTime.Now;
        var price = 100;
        var description = "Consultation";
        var patientId = Guid.NewGuid();
        var doctorId = Guid.NewGuid();

        var appointment = new Appointment(date, price, description, patientId, doctorId);

        Assert.Equal(date, appointment.Date);
        Assert.Equal(price, appointment.Price);
        Assert.Equal(description, appointment.Description);
        Assert.Equal(patientId, appointment.PatientId);
        Assert.Equal(doctorId, appointment.DoctorId);
        Assert.Empty(appointment.MedicalReports);
        Assert.Null(appointment.Prescription);
    }

    [Fact]
    public void Should_add_medical_report()
    {
        var date = DateTime.Now;
        var price = 100;
        var description = "Consultation";
        var patientId = Guid.NewGuid();
        var doctorId = Guid.NewGuid();

        var appointment = new Appointment(date, price, description, patientId, doctorId);

        var diagnosis = "Diagnosis";
        var treatment = "Treatment";
        var recommendations = "Recommendations";

        appointment.AddMedicalReport(diagnosis, treatment, recommendations);

        Assert.Single(appointment.MedicalReports);
        Assert.Equal(diagnosis, appointment.MedicalReports.First().Diagnosis);
        Assert.Equal(treatment, appointment.MedicalReports.First().Treatment);
        Assert.Equal(recommendations, appointment.MedicalReports.First().Recommendations);
    }

    [Fact]
    public void Should_not_add_medical_report_if_the_appointment_is_finished()
    {
        var date = DateTime.Now;
        var price = 100;
        var description = "Consultation";
        var patientId = Guid.NewGuid();
        var doctorId = Guid.NewGuid();

        var appointment = new Appointment(date, price, description, patientId, doctorId);

        appointment.Finish();

        var exceptionMessage = Assert.Throws<InvalidOperationException>(() => appointment.AddMedicalReport("Diagnosis", "Treatment", "Recommendations"));
        Assert.Equal("Cannot reschedule a finished or canceled appointment", exceptionMessage.Message);
    }

    [Fact]
    public void Should_not_add_medical_report_if_the_appointment_is_canceled()
    {
        var date = DateTime.Now;
        var price = 100;
        var description = "Consultation";
        var patientId = Guid.NewGuid();
        var doctorId = Guid.NewGuid();

        var appointment = new Appointment(date, price, description, patientId, doctorId);

        appointment.Cancel();

        var exceptionMessage = Assert.Throws<InvalidOperationException>(() => appointment.AddMedicalReport("Diagnosis", "Treatment", "Recommendations"));
        Assert.Equal("Cannot reschedule a finished or canceled appointment", exceptionMessage.Message);
    }

    [Fact]
    public void Should_add_prescription()
    {
        var date = DateTime.Now;
        var price = 100;
        var description = "Consultation";
        var patientId = Guid.NewGuid();
        var doctorId = Guid.NewGuid();

        var appointment = new Appointment(date, price, description, patientId, doctorId);

        appointment.AddPrescription("Medicine", "Dosage", "Duration");

        Assert.NotNull(appointment.Prescription);
        Assert.Single(appointment.Prescription.Medications);
    }

    [Fact]
    public void Should_change_status_to_canceled()
    {
        var date = DateTime.Now;
        var price = 100;
        var description = "Consultation";
        var patientId = Guid.NewGuid();
        var doctorId = Guid.NewGuid();

        var appointment = new Appointment(date, price, description, patientId, doctorId);

        appointment.Cancel();

        Assert.Equal(AppointmentStatus.Canceled, appointment.Status);
    }

    [Fact]
    public void Should_change_status_to_finished()
    {
        var date = DateTime.Now;
        var price = 100;
        var description = "Consultation";
        var patientId = Guid.NewGuid();
        var doctorId = Guid.NewGuid();

        var appointment = new Appointment(date, price, description, patientId, doctorId);

        appointment.Finish();

        Assert.Equal(AppointmentStatus.Finished, appointment.Status);
    }

    [Fact]
    public void Should_not_change_status_to_finished_if_the_status_is_canceled()
    {
        var date = DateTime.Now;
        var price = 100;
        var description = "Consultation";
        var patientId = Guid.NewGuid();
        var doctorId = Guid.NewGuid();

        var appointment = new Appointment(date, price, description, patientId, doctorId);

        appointment.Cancel();

        var exceptionMessage = Assert.Throws<InvalidOperationException>(() => appointment.Finish());
        Assert.Equal("Cannot finish a canceled appointment", exceptionMessage.Message);
    }

    [Fact]
    public void Should_not_change_status_to_canceled_if_the_status_is_finished()
    {
        var date = DateTime.Now;
        var price = 100;
        var description = "Consultation";
        var patientId = Guid.NewGuid();
        var doctorId = Guid.NewGuid();

        var appointment = new Appointment(date, price, description, patientId, doctorId);

        appointment.Finish();

        var exceptionMessage = Assert.Throws<InvalidOperationException>(() => appointment.Cancel());
        Assert.Equal("Cannot cancel a finished appointment", exceptionMessage.Message);
    }
}
