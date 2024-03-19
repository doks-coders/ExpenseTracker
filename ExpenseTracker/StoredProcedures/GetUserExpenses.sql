ALTER PROCEDURE [dbo].[GetUserExpenses]
@username VARCHAR(255),
@pagesize INT=4,
@pagenumber INT
AS
BEGIN
	SELECT * FROM [expenseTracker].[dbo].[Expenses]
	WHERE UserID=(SELECT ID FROM [expenseTracker].[dbo].[Users] WHERE Username=@username)
	ORDER BY ID DESC
	OFFSET (@pageNumber-1)*@pagesize ROWS
	FETCH NEXT @pagesize ROWS ONLY
END