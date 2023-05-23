import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Pagination } from '../shared/models/pagination';
import { Product } from '../shared/models/product';
import { Brand } from '../shared/models/brand';
import { Type } from '../shared/models/type';
import { ShopParams } from '../shared/models/shopParams';

@Injectable({
  providedIn: 'root'
})
export class ShopService {

  baseUrl = "https://localhost:7068/api";
  shopParams = new ShopParams();

  constructor(private httpClient: HttpClient) { }

  getProducts(shopParams: ShopParams) {
    let params = new HttpParams();
    if(this.shopParams.brandId > 0) params = params.append('brandId', this.shopParams.brandId);
    if(this.shopParams.typeId) params = params.append('typeId', this.shopParams.typeId);
    params = params.append('sort', this.shopParams.sort);
    params = params.append('pageIndex', this.shopParams.pageIndex);
    params = params.append('pageSize', this.shopParams.pageSize);
    return this.httpClient.get<Pagination<Product[]>>(this.baseUrl + '/products', {params});
  }

  getBrands() {
    return this.httpClient.get<Brand[]>(this.baseUrl + "/products/brands");
  }

  getTypes() {
    return this.httpClient.get<Type[]>(this.baseUrl + '/products/types');
  }

  getShopParams() {
    return this.shopParams;
  }

  setShopParams(params: ShopParams) {
    this.shopParams = params;
  }

}
