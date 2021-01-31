import {IProduct} from './product';

export interface IPagination {
  pageNumber: number;
  pageSize: number;
  productsCount: number;
  remainProducts: number;
  data: IProduct[];
}
