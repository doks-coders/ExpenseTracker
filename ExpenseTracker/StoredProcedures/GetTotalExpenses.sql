ALTER PROCEDURE [dbo].[GetTotalUserExpenses]
@username varchar(255)=NULL
AS
BEGIN
	IF @username IS NOT NULL
	SELECT COUNT(ID) AS 'TotalExpenses' FROM Expenses 
	WHERE UserID=(SELECT ID FROM Users WHERE Username=@username)
	ELSE
	SELECT COUNT(ID) AS 'TotalExpenses' FROM Expenses 
END