import { Component, OnInit } from '@angular/core';
import {BasketService} from '../../basket/basket.service';
import {Observable} from 'rxjs';
import {IBasket} from '../../shared/models/basket';
import {IUser} from '../../shared/models/user';
import {AccountService} from '../../account/account.service';
import {BsDropdownConfig} from 'ngx-bootstrap/dropdown';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss'],
  providers: [{ provide: BsDropdownConfig, useValue: { isAnimated: true, autoClose: true } }]
})
export class NavBarComponent implements OnInit {
  basket$: Observable<IBasket>;
  currentUser$: Observable<IUser>;

  constructor(private basketServices: BasketService, private accountService: AccountService) { }

  ngOnInit(): void {
    this.basket$ = this.basketServices.basket$;
    this.currentUser$ = this.accountService.currentUser$;
  }

  logout(): void{
    this.accountService.logout();
  }

}
