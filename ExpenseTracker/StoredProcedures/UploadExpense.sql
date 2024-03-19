ALTER PROCEDURE [dbo].[UploadExpense]
@title VARCHAR(255),
@description VARCHAR(255)='',
@amountpaid VARCHAR(255),
@username VARCHAR(255),
@CategoryName VARCHAR(255)
AS
BEGIN
		INSERT INTO [expenseTracker].[dbo].[Expenses](Title,Description,AmountPaid,UserID,CategoryID)
		VALUES(@title,@description,@amountpaid,
		(SELECT ID FROM [expenseTracker].[dbo].[Users] WHERE Username=@username),
		(SELECT ID FROM [expenseTracker].[dbo].[Categories] WHERE Name=@CategoryName))
END