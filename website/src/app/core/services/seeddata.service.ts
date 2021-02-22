import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {environment} from '../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class SeeddataService {
  basUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  seedProductsBrands(): Observable<any>{
    return this.http.post(this.basUrl + 'seeddata/brands', null);
  }

  seedProductsTypes(): Observable<any>{
    return this.http.post(this.basUrl + 'seeddata/types', null);
  }

  seedProducts(): Observable<any>{
    return this.http.post(this.basUrl + 'seeddata/product', null);
  }

  seedUsers(): Observable<any>{
    return this.http.post(this.basUrl + 'seeddata/users', null);
  }
}
