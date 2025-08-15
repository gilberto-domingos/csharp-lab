using System;

namespace PrintsControl.Application.Dtos.Printing
{
    public sealed record CreatePrintingResponse(Guid Id, Guid StudentId, int QuantityPrinted, DateTimeOffset CreatedAt);
}