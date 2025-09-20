using System;

namespace PrintsControl.Application.Dtos.PrintJobs;

public sealed record PrintJobDto(Guid Id, Guid StudentId, int Quantity, DateTimeOffset PrintDate);
