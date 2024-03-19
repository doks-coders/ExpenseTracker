ALTER PROCEDURE [dbo].[EditExpense]
--id
@expenseId INT,
--body
@title VARCHAR(255)=NULL,
@description VARCHAR(255)=NULL,
@amountpaid VARCHAR(255)=NULL,
@userid VARCHAR(255)=NULL,
@CategoryName VARCHAR(255)=NULL
AS

BEGIN
	UPDATE [expenseTracker].[dbo].[Expenses]
	SET
		Title = ISNULL(@title,Title),
		Description = ISNULL(@description,Description),
		AmountPaid = ISNULL(@amountpaid,AmountPaid),
		CategoryID = ISNULL((SELECT ID FROM  [expenseTracker].[dbo].[Categories] WHERE Name=@CategoryName),CategoryID)
	WHERE ID = @expenseId
END
