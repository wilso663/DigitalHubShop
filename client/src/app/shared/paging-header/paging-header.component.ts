import { Component, Input } from '@angular/core';
import { ShopService } from 'src/app/shop/shop.service';

@Component({
  selector: 'paging-header',
  templateUrl: './paging-header.component.html',
  styleUrls: ['./paging-header.component.scss']
})
export class PagingHeaderComponent {

  @Input() pageIndex?: number;
  @Input() pageSize?: number;
  @Input() totalCount?: number;
  
}
