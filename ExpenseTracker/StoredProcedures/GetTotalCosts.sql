  ALTER PROCEDURE [dbo].[GetTotalCosts]
  @username VARCHAR(255)
  AS
  BEGIN
	  SELECT SUM (CAST(AmountPaid AS float)) as 'TotalCosts'
	  FROM [expenseTracker].[dbo].[Expenses]
	  WHERE UserID=(SELECT ID FROM Users WHERE Username=@username)
  END
