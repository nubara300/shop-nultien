export interface ActionType {
  label: string;
  icon: string;
  event: string;
  btnClass?: string;
  hover?: string;
  iconClass?:string;
  tooltip:string;
}

export interface ColumnType {
  key: string;
  label: string;
  sortKey?: string;
}
