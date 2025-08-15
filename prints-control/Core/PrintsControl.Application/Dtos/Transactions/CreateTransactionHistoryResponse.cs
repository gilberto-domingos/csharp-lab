namespace PrintsControl.Application.Dtos.Transactions;

public sealed record CreateTransactionHistoryResponse(Guid Id, Guid StudentId, string TransactionType, int Quantity, int BalanceBefore, int BalanceAfter, DateTimeOffset CreatedAt);