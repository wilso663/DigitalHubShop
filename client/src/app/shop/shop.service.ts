import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Pagination } from '../shared/models/pagination';
import { Product } from '../shared/models/product';
import { Brand } from '../shared/models/brand';
import { Type } from '../shared/models/type';

@Injectable({
  providedIn: 'root'
})
export class ShopService {

  baseUrl = "https://localhost:7068/api";
  constructor(private httpClient: HttpClient) { }

  getProducts(brandId? : number, typeId?: number) {
    let params = new HttpParams();
    if(brandId) params = params.append('brandId', brandId);
    if(typeId) params = params.append('typeId', typeId);
    
    return this.httpClient.get<Pagination<Product[]>>(this.baseUrl + '/products', {params});
  }

  getBrands() {
    return this.httpClient.get<Brand[]>(this.baseUrl + "/products/brands");
  }

  getTypes() {
    return this.httpClient.get<Type[]>(this.baseUrl + '/products/types');
  }
}
