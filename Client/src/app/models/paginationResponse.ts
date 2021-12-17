export interface IPageableResponse<T> {
    total?: number;
    pageSize?: number;
    currentPage?: number;
    results: T[];
}

export interface IPageableRequest {
    page: number;
    pageSize: number;

    //add filters,sort, additional request data
}