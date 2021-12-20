
USE[NultienShopDBTest]
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
SELECT *
FROM (
    SELECT *,
    SUM(ArticleQuantity) OVER (ORDER BY ArticleQuantity ASC) as total_qty,
    SUM(ArticleQuantity) OVER(ORDER BY ArticleQuantity ASC
rows between unbounded preceding and 1 preceding) as prev_total_qty
    FROM InventoryArticle 
WHERE ArticleId = @ArticleId
    ) AS o 
WHERE 
coalesce(prev_total_qty, 0) < @ArticleQuantity
END