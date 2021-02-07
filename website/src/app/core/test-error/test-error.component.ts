import { Component, OnInit } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {environment} from '../../../environments/environment';

@Component({
  selector: 'app-test-error',
  templateUrl: './test-error.component.html',
  styleUrls: ['./test-error.component.css']
})
export class TestErrorComponent implements OnInit {
  baseUrl = environment.apiUrl;
  validationErrors: any[];

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
  }

  get404Error(): void{
    this.http.get(this.baseUrl + 'products/068F838D-6687-4991-17B8-08D8C6B6ABE7').subscribe(response => {
      console.log(response);
    }, error => {
      console.log(error);
    });
  }

  get400Error(): void{
    this.http.get(this.baseUrl + 'buggy/badRequest').subscribe(response => {
      console.log(response);
    }, error => {
      console.log(error);
    });
  }

  get500Error(): void{
    this.http.get(this.baseUrl + 'buggy/servererror').subscribe(response => {
      console.log(response);
    }, error => {
      console.log(error);
    });
  }

  get400ValidationError(): void{
    this.http.get(this.baseUrl + 'products/test').subscribe(response => {
      console.log(response);
    }, error => {
      console.log(error);
      this.validationErrors = error.error.errors.id;
      console.log(this.validationErrors);
    });
  }
}
