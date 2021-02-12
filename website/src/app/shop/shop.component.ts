import {Component, ElementRef, OnInit, ViewChild} from '@angular/core';
import { IProduct } from '../shared/models/product';
import { ShopService } from './shop.service';
import {IBrands} from '../shared/models/brands';
import {IType} from '../shared/models/productType';
import {ShopParams} from '../shared/models/shopParams';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss'],
})
export class ShopComponent implements OnInit {
  @ViewChild('search', {static: false}) searchTerm: ElementRef;
  products: IProduct[];
  brands: IBrands[];
  types: IType[];
  shopParams = new ShopParams();
  totalCount: number;
  sortOptions = [
    {name: 'Alphabetical', value: 'name'},
    {name: 'Price: Low to High', value: 'priceAsc'},
    {name: 'Price: High to Low', value: 'priceDesc'},
  ];

  constructor(private shopService: ShopService) {}

  ngOnInit(): void {
    this.getProducts();
    this.getBrand();
    this.getType();
  }

  getProducts(): void {
    this.shopService.getProducts(this.shopParams).subscribe(response => {
      this.products = response.data;
      this.shopParams.pageNumber = response.pageNumber;
      this.shopParams.pageSize = response.pageSize;
      this.totalCount = response.productsCount;
    }, error => {
      console.log(error);
    });
  }

  getBrand(): void {
    this.shopService.getBrands().subscribe(response => {
      this.brands = [{id: '', name: 'All'}, ...response];
    }, error => {
      console.log(error);
    });
  }

  getType(): void {
    this.shopService.getProductTypes().subscribe(response => {
      this.types = [{id: '', name: 'All'}, ...response];
    }, error => {
      console.log(error);
    });
  }

  onBrandSelected(ProductBrand: string): void {
    this.shopParams.brand = ProductBrand;
    this.shopParams.pageNumber = 1;
    this.getProducts();
  }

  onTypeSelected(ProductType: string): void {
    this.shopParams.type = ProductType;
    this.shopParams.pageNumber = 1;
    this.getProducts();
  }

  onSortSelected(sort: string): void {
    this.shopParams.sort = sort;
    this.getProducts();
  }

  onPageChanged(event: any): void {
    if (this.shopParams.pageNumber !== event)
    {
      this.shopParams.pageNumber = event;
      this.getProducts();
    }
  }

  onSearch(): void{
    this.shopParams.search = this.searchTerm.nativeElement.value;
    this.shopParams.pageNumber = 1;
    this.getProducts();
  }

  onReset(): void{
    this.searchTerm.nativeElement.value = '';
    this.shopParams = new ShopParams();
    this.getProducts();
  }
}


