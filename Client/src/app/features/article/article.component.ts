import {
  ChangeDetectionStrategy,
  Component,
  OnDestroy,
  OnInit,
} from '@angular/core';
import { BehaviorSubject, of, Subject } from 'rxjs';
import { catchError } from 'rxjs/operators';
import {
  ActionType,
  Article,
  ColumnType,
  IPageableResponse,
} from 'src/app/models';
import { CommonService } from 'src/app/services/common.service';

@Component({
  selector: 'app-article',
  templateUrl: './article.component.html',
  styleUrls: ['./article.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class ArticleComponent implements OnInit, OnDestroy {
  loader$: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);

  data$ = this.commonService
    .get<IPageableResponse<Article>>('article')
    .pipe(catchError((err) => of(null)));

  // 'articalId','articleName','articlePrice'
  displayedColumns: ColumnType[] = [
    { key: 'articleId', label: 'Article ID' },
    { key: 'articleName', label: 'Name' },
    { key: 'articlePrice', label: 'Article price' },
  ];

  actions: ActionType[] = [
    {
      event: 'order',
      icon: 'shopping_cart',
      label: 'buyArticle',
      tooltip: 'Order article',
    },
  ];

  constructor(private commonService: CommonService) {}

  ngOnDestroy(): void {}

  ngOnInit(): void {}
}
