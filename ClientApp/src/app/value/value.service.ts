import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { map, tap, catchError } from 'rxjs/operators';

import { Value } from './value-model';


@Injectable()
export class ValueService {

  apiUrl = 'http://localhost:5000/api/values/';

  constructor(private http: HttpClient) { }

  getValues(): Observable<Value[]> {
    return this.http.get(this.apiUrl ).pipe(
      map(response => <Value[]>response),
      tap(data => console.log(data)),
      catchError(error => this.handlerError(error)));
  }

  protected handlerError(error: HttpErrorResponse) {
    // console.error('My Error: ' + error);

    if (error.status === 400) {
      return throwError(error.message || 'Bad request');
    } else if (error.status === 401) {
      return throwError(
        error.message ||
          'Unauthorized: Sorry you cannot access this service!'
      );
    } else if (error.status === 404) {
      return throwError(
        error.message || 'Service is not available!'
      );
    } else if (error.status === 500) {
      return throwError(error.message || 'Server Error!');
    } else {
      return throwError(
        error.message || 'Cannot make this request at this moment!'
      );
    }
  }
}

