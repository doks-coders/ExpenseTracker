ALTER PROCEDURE [dbo].[DeleteExpense]
@expenseId INT
AS
BEGIN
	DELETE FROM [expenseTracker].[dbo].[Expenses]
	WHERE ID=@expenseId
END;