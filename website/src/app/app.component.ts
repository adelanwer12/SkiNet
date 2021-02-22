import {Component, OnInit} from '@angular/core';
import {BasketService} from './basket/basket.service';
import {AccountService} from './account/account.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {
  title = 'SkyNet Shop';

  constructor(private basketServices: BasketService, private accountService: AccountService) {
  }

  ngOnInit(): void {
    this.loadBasket();
    this.loadCurrentUser();
  }

  loadBasket(): void {
    const basketId = localStorage.getItem('basket-id');
    if (basketId) {
      this.basketServices.getBasket(basketId).subscribe(() => {
        console.log('initialised basket');
      }, error => {
        console.log(error);
      });
    }
  }

  loadCurrentUser(): void {
    const token = localStorage.getItem('token');
    this.accountService.loadCurrentUser(token).subscribe(() => {
      console.log('loaded User');
    }, error => {
      console.log(error);
    });
  }
}
