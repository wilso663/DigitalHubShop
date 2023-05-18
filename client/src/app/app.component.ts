import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Product } from './models/product';
import { Pagination } from './models/pagination';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'DigiShop';
  products: Product[] = [];

  constructor(private http: HttpClient) {
    this.http.get<Pagination<Product[]>>('https://localhost:7068/api/products').subscribe({
      next: response => this.products = response.data,
      error: error => console.log(error),
      complete: () => {
        console.log('request complete')
      }
    });
  }
}


