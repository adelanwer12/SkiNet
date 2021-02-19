import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SeeddataService {
  basUrl = 'https://localhost:5001/seeddata/';

  constructor(private http: HttpClient) { }

  seedProductsBrands(): Observable<any>{
    return this.http.post(this.basUrl + 'brands', null);
  }

  seedProductsTypes(): Observable<any>{
    return this.http.post(this.basUrl + 'types', null);
  }

  seedProducts(): Observable<any>{
    return this.http.post(this.basUrl + 'product', null);
  }

  seedUsers(): Observable<any>{
    return this.http.post(this.basUrl + 'users', null);
  }
}
