using System;

namespace PrintsControl.Application.Dtos.PrintJobs;

public sealed record PrintJobDto(Guid StudentId, int Quantity, DateTimeOffset PrintDate);
