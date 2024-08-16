import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable, refCount, shareReplay, throwError, catchError, of, delay } from 'rxjs';
import { Product } from '../Model/Product';

@Injectable({
  providedIn: 'root'
})
export class CallMyApiService {

  constructor(private httpClient: HttpClient) { }

  getInfoFromAPI(): Observable<Product> {
    
    const headers = new HttpHeaders({
      'Content-Type': 'application/json' 
    });

    const result$ = this.httpClient.get<Product>("https://localhost:7112/api/Product/getallproducts"
      , { headers }
    ).pipe(
      shareReplay({ bufferSize: 1, refCount: true }),
      catchError(this.handleError)
    );

    return result$;
  }

  anotherExample(): Observable<number>{
    const source$ = of(1,2,3).pipe(
      delay(1000),  // Simulate an async operation
      shareReplay(1) // Cache the last emission
    );

    return source$;
  }

  private handleError(error: any) {
    console.error('An error occurred', error);
    return throwError(error);
  }

}
