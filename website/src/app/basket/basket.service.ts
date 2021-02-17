import { Injectable } from '@angular/core';
import {environment} from '../../environments/environment';
import {HttpClient} from '@angular/common/http';
import {BehaviorSubject, Observable} from 'rxjs';
import {Basket, IBasket, IBasketItem, IBasketTotals} from '../shared/models/basket';
import {map} from 'rxjs/operators';
import {IProduct} from '../shared/models/product';



@Injectable({
  providedIn: 'root'
})
export class BasketService {
  baseUrl = environment.apiUrl;
  private basketSource = new BehaviorSubject<IBasket>(null);
  basket$ = this.basketSource.asObservable();
  private basketTotalSource = new BehaviorSubject<IBasketTotals>(null);
  basketTotal$ = this.basketTotalSource.asObservable();

  constructor(private http: HttpClient) { }

  getBasket(id: string): Observable<void>{
    return this.http.get(this.baseUrl + 'basket?id=' + id)
      .pipe(
        map((basket: IBasket) => {
          this.basketSource.next(basket);
          this.calculateTotals();
        })
      );
  }

  setBasket(basket: IBasket): void {
     this.http.post(this.baseUrl + 'basket' , basket).subscribe((response: IBasket) => {
      this.basketSource.next(response);
      this.calculateTotals();
    }, error => {
      console.log(error);
    });
  }

  getCurrentBasketValue(): IBasket{
    return this.basketSource.value;
  }

  addItemToBasket(item: IProduct, quantity= 1): void{
    const itemToAdd: IBasketItem = {
      brand: item.productBrand,
      id: item.id,
      pictureUrl: item.pictureUrl,
      price: item.price,
      productName: item.name,
      quantity,
      type: item.productType
    };
    const basket = this.getCurrentBasketValue() ?? this.crateBasket();
    const index = basket.items.findIndex(i => i.id === itemToAdd.id);
    if (index >= 0){
      basket.items[index].quantity += quantity;
    }
    else {
      itemToAdd.quantity = quantity;
      basket.items.push(itemToAdd);
    }
    this.setBasket(basket);
  }

  incrementItemQuantity(item: IBasketItem): void{
    const basket = this.getCurrentBasketValue();
    const foundItemIndex = basket.items.findIndex(i => i.id === item.id);
    basket.items[foundItemIndex].quantity++;
    this.setBasket(basket);
  }
  decrementItemQuantity(item: IBasketItem): void{
    const basket = this.getCurrentBasketValue();
    const foundItemIndex = basket.items.findIndex(i => i.id === item.id);
    if (basket.items[foundItemIndex].quantity > 1){
      basket.items[foundItemIndex].quantity--;
      this.setBasket(basket);
    }else {
      this.removeItemFromBasket(item);
    }
  }

  private crateBasket(): IBasket {
    const basket = new Basket();
    localStorage.setItem('basket-id', basket.id);
    return basket;
  }

  private calculateTotals(): void{
    const basket = this.getCurrentBasketValue();
    const shipping = 0;
    const subtotal = basket.items.reduce((a, b) => (b.price * b.quantity) + a, 0);
    const total = subtotal + shipping;
    this.basketTotalSource.next({shipping, total, subtotal});
  }

  removeItemFromBasket(item: IBasketItem): void {
    const basket = this.getCurrentBasketValue();
    if (basket.items.some(i => i.id === item.id)){
      basket.items = basket.items.filter(i => i.id !== item.id);
      if (basket.items.length > 0){
        this.setBasket(basket);
      } else {
        this.deleteBasket(basket);
      }
    }
  }

  deleteBasket(basket: IBasket): void {
    this.http.delete(this.baseUrl + 'basket?id=' + basket.id).subscribe(() => {
      this.basketSource.next(null);
      this.basketTotalSource.next(null);
      localStorage.removeItem('basket-id');
    }, error => {
      console.log(error);
    });
  }
}
