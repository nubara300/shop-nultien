import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Article } from '../models';
import { IPageableResponse } from '../models/paginationResponse';

@Injectable({
  providedIn: 'root',
})
export class CommonService {
  constructor(private http: HttpClient) {
    
  }

  get<T>(path: EndopintsType): Observable<T> {
    return this.http
      .get<T>(`${environment.apiUrl}${path}`)
      .pipe(catchError((err) => of(err)));
  }

  post<T>(path: EndopintsType, body: any = {}): Observable<T> {
    return this.http
      .post<T>(`${environment.apiUrl}${path}`, body)
      .pipe(catchError((err) => of(err)));
  }
}

type EndopintsType = 'article' | 'order' | 'inventory' | 'customer';
