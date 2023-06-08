import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environment/environment';
import { Order } from '../shared/models/order';

@Injectable({
  providedIn: 'root'
})
export class OrdersService {
  
  baseUrl = environment.apiUrl;

  constructor(private httpClient: HttpClient) { }

  getOrdersForUser() {
    return this.httpClient.get<Order[]>(this.baseUrl + 'orders');
  }

  getOrderDetailed(id: string){
    return this.httpClient.get<Order>(this.baseUrl + 'orders/' + id)
  }
}
