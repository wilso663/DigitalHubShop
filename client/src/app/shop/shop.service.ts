import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Pagination } from '../shared/models/pagination';
import { Product } from '../shared/models/product';

@Injectable({
  providedIn: 'root'
})
export class ShopService {

  baseUrl = "https://localhost:7068/api";
  constructor(private httpClient: HttpClient) { }

  getProducts() {
    return this.httpClient.get<Pagination<Product[]>>(this.baseUrl + '/products');
  }
}
