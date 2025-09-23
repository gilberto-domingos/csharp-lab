using System;

namespace PrintsControl.Application.Dtos.PrintJobs;

public sealed record PrintJobDto(Guid Id, int Quantity, DateTimeOffset PrintDate);
