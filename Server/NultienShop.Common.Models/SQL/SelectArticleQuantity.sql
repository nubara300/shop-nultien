
USE[NultienShopDB]
GO
/****** Object:  StoredProcedure [dbo].[SelectArticleQuantity]    Script Date: 12/17/2021 12:38:37 AM ******/
    SET ANSI_NULLS ON
GO
    SET QUOTED_IDENTIFIER ON
GO
    CREATE PROCEDURE [dbo].[SelectArticleQuantity]
@ArticleId int, 
@ArticleQuantity int
    --Add the parameters for the stored procedure here
AS
    BEGIN
SELECT
  *
FROM (
    SELECT
      i.*,
      RunningSum = SUM(convert(bigint,i.ArticleQuantity)) 
      OVER (PARTITION BY i.ArticleId ORDER BY i.InventoryArticleId ROWS UNBOUNDED PRECEDING)
    FROM InventoryArticle i
    INNER JOIN Article a ON i.ArticleId = a.ArticleId
    WHERE i.ArticleId = @ArticleId and i.ArticleQuantity > 0
) i
WHERE i.RunningSum - i.ArticleQuantity < @ArticleQuantity;
END