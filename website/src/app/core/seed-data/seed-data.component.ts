import { Component, OnInit } from '@angular/core';
import {SeeddataService} from '../services/seeddata.service';

@Component({
  selector: 'app-seed-data',
  templateUrl: './seed-data.component.html',
  styleUrls: ['./seed-data.component.css']
})
export class SeedDataComponent implements OnInit {
  response: any;

  constructor(private seedData: SeeddataService) { }

  ngOnInit(): void {
  }

  seedProductsBrands(): void{
    this.seedData.seedProductsBrands().subscribe(response => {
      this.response = response;
    }, error => {
      console.log(error);
    });
  }

  seedProductsTypes(): void{
    this.seedData.seedProductsTypes().subscribe(response => {
      this.response = response;
    }, error => {
      console.log(error);
    });
  }

  seedProducts(): void{
    this.seedData.seedProducts().subscribe(response => {
      this.response = response;
    }, error => {
      console.log(error);
    });
  }

  seedUsers(): void{
    this.seedData.seedUsers().subscribe(response => {
      this.response = response;
    }, error => {
      console.log(error);
    });
  }
}
