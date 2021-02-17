import { Component, OnInit } from '@angular/core';
import {BasketService} from './basket/basket.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {
  title = 'SkyNet Shop';

  constructor(private basketServices: BasketService) {}

  ngOnInit(): void {
    const basketId = localStorage.getItem('basket-id');
    if (basketId){
      this.basketServices.getBasket(basketId).subscribe(response => {
        console.log(response);
      }, error => {
        console.log(error);
      });
    }
  }
}
