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
import { Article, IPageableResponse } from 'src/app/models';

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

  @Input() columns: { key: string; label: string; sortKey?: string }[] = [];
  columnKeys: string[] = [];

  @Input()
  set response(value: IPageableResponse<Article[]>) {
    if (value) {
      this.currentPage = value.currentPage ?? 0;
      this.total = value.total ?? 0;

      this.tableData.data = value.entries ?? [];
    } else {
      this.tableData.data = [];
    }
  }

  @Input() actions = [];

  @Input() showLoader$: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(
    false
  );

  constructor() {}

  ngOnInit(): void {
    this.columnKeys = this.columns.map((c) => c.key);
  }

  sortChange = (event: Sort) => {
    this.onSortChange.emit(event);
  };

  pageChange = (event: PageEvent) => {
    this.onPageChange.emit(event);
  };

  rowAction = (event: any) => {
    this.onAction.emit(event);
  };
}
