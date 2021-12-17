import {
  ChangeDetectionStrategy,
  Component,
  EventEmitter,
  Input,
  OnInit,
  Output,
  ViewChild,
} from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { Sort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { BehaviorSubject } from 'rxjs';
import { ActionType, ColumnType, IPageableResponse } from 'src/app/models';



@Component({
  selector: 'app-mat-table',
  templateUrl: './mat-table.component.html',
  styleUrls: ['./mat-table.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class MatTableComponent implements OnInit {
  @ViewChild(MatPaginator) paginator!: MatPaginator;

  total: number = 0;
  currentPage: number = 0;
  tableData = new MatTableDataSource<any>([]);

  @Output()
  onSortChange = new EventEmitter();

  @Output()
  onAction = new EventEmitter();

  @Output()
  onPageChange = new EventEmitter();

  @Input() columns: ColumnType[] = [];

  @Input() actions: ActionType[] = [];

  @Input()
  set data(value: IPageableResponse<any>|null) {
    if (value) {
      console.error(value);
      this.currentPage = value.currentPage ?? 0;
      this.total = value.total ?? 0;

      this.tableData.data = value.results ?? [];
      console.error(this.tableData.data);
    } else {
      this.tableData.data = [];
      this.total = 0;
      this.currentPage = 0;
    }
  }

  @Input() showLoader$: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(
    false
  );

  columnKeys: string[] = [];

  constructor() {}

  ngOnInit(): void {
    this.columnKeys = this.columns.map((c) => c.key);
    console.error(this.actions);
    if(this.actions.length>0){
      this.columnKeys.push('actions');
    }
    console.error(this.columnKeys);
  }

  sortChange = (event: Sort) => {
    this.onSortChange.emit(event);
  };

  pageChange = (event: PageEvent) => {
    this.onPageChange.emit(event);
  };

  rowAction = (event: any, element: any) => {
    this.onAction.emit({ actionEvent: event, row: element });
  };
}
