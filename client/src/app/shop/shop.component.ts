import { Component, OnInit } from '@angular/core';
import { Product } from '../shared/models/product';
import { ShopService } from './shop.service';
import { Brand } from '../shared/models/brand';
import { Type } from '../shared/models/type';
import { ShopParams } from '../shared/models/shopParams';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit {
  
  products: Product[] = [];
  brands: Brand[] = [];
  types: Type[] = [];
  totalCount: number = 0;
  shopParams: ShopParams;
  sortOptions = [
    {name: "Alphabetical", value: 'name'},
    {name: "Price: Low to High", value: 'priceAsc'},
    {name: "Price: High to Low", value: 'priceDesc'},
  ];
  sortSelected = 'name';

  constructor(private shopService: ShopService) {
    this.shopParams = this.shopService.getShopParams();
  }

  ngOnInit(): void {
    this.getProducts();
    this.getTypes();
    this.getBrands();
  }

  getProducts() {
    this.shopService.getProducts(this.shopParams).subscribe({
      next: response => {
        this.products = response.data;
        this.shopParams.pageIndex = response.pageIndex;
        this.shopParams.pageSize = response.pageSize;
        this.totalCount = response.count;
      },
      error: error => console.log(error)
    })
  }

  getTypes() {
    this.shopService.getTypes().subscribe({
      next: response => this.types = [{id: 0, name: 'All'}, ...response],
      error: error => console.log(error)
    })
  }

  getBrands() {
    this.shopService.getBrands().subscribe({
      next: response => this.brands = [{id: 0, name: 'All'}, ...response],
      error: error => console.log(error)
    })
  }

  onTypeSelected(typeId: number){
    this.shopParams.typeId = typeId;
    this.getProducts();
  }

  onBrandSelected(brandId: number){
    this.shopParams.brandId = brandId;
    this.getProducts();
  }

  onSortSelected(event: any){
    this.shopParams.sort = event.target.value;
    this.getProducts();
  }

  onPageChanged(event: any){
    if(this.shopParams.pageIndex !== event.page){
      this.shopParams.pageIndex = event.page;
      this.getProducts();
    }
  }
}
