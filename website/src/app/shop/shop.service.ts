import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IPagination } from '../shared/models/pagination';
import { IBrands } from '../shared/models/brands';
import { IType } from '../shared/models/productType';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';
import {ShopParams} from '../shared/models/shopParams';
import {IProduct} from '../shared/models/product';

@Injectable({
  providedIn: 'root',
})
export class ShopService {
  basUrl = 'https://localhost:5001/api/';

  constructor(private http: HttpClient) {}

  getProducts(shopParams: ShopParams): Observable<IPagination> {
    let params = new HttpParams();
    if (shopParams.brand && shopParams.brand !== 'All') {
      params = params.append('productBrand', shopParams.brand);
    }
    if (shopParams.type && shopParams.type !== 'All') {
      params = params.append('productType', shopParams.type);
    }
    if (shopParams.search){
      params = params.append('search', shopParams.search);
    }

    params = params.append('sort', shopParams.sort);
    params = params.append('pageNumber', shopParams.pageNumber.toString());
    params = params.append('pageSize', shopParams.pageSize.toString());
    return this.http.get<IPagination>(this.basUrl + 'products', {observe: 'response', params})
      .pipe(map( response => {
        return response.body;
      }));
  }

  getProduct(id: string): Observable<IProduct>{
    return this.http.get<IProduct>(this.basUrl + 'products/' + id);
  }

  getBrands(): Observable<IBrands[]> {
    return this.http.get<IBrands[]>(this.basUrl + 'brands');
  }

  getProductTypes(): Observable<IType[]> {
    return this.http.get<IType[]>(this.basUrl + 'types');
  }
}
