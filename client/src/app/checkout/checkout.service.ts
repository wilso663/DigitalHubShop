import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environment/environment';
import { DeliveryMethod } from '../shared/models/deliveryMethod';
import { map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CheckoutService {
  baseUrl = environment.apiUrl;

  constructor(private httpClient: HttpClient) { }

  getDeliveryMethods() {
    return this.httpClient.get<DeliveryMethod[]>(this.baseUrl + 'orders/deliveryMethods').pipe(
      map(methods => {
        return methods.sort((a,b) => b.price - a.price)
      })
    )
  }
}
