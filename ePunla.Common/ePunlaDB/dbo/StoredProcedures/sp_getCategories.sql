CREATE PROCEDURE [dbo].[sp_getCategories]

AS
BEGIN
  SELECT CategoryId,[Category]=[Name] FROM Categories
END
