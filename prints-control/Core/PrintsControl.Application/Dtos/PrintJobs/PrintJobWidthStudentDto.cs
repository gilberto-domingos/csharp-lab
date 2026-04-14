namespace PrintsControl.Application.Dtos.PrintJobs;

public sealed record PrintJobWidthStudentDto(Guid Id, int Quantity, string StudentName, DateTimeOffset PrintDate);