export interface Article {
  articleId: number;
  articleName: string;
  articlePrice: number;
  dateCreated: Date;
}

export interface ArticleOrderRequest {
  articleId: number;

  quantity: number;

  maxPrice: number;

  customerId: number;
}
