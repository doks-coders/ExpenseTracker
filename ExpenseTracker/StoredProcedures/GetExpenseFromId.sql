ALTER PROCEDURE [dbo].[GetExpenseFromId]
@expenseid INT
AS
BEGIN
	SELECT E.ID, E.Title,E.Description, E.AmountPaid, E.DateCreated, E.CategoryID, C.Name	as 'CategoryName' 
	FROM [expenseTracker].[dbo].[Expenses] as E
	LEFT JOIN [expenseTracker].[dbo].[Categories]  as C ON E.CategoryID=C.ID
	WHERE E.ID=@expenseid
END
