import { Component, OnInit } from '@angular/core';
import { Order } from '../shared/models/order';
import { OrdersService } from './orders.service';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.scss']
})
export class OrdersComponent implements OnInit {

  orders: Order[] = [];
  selectedOrder?: Order;

  ngOnInit(): void {
    this.getOrders();
  }

  constructor(private ordersService: OrdersService ){}

  getOrders(){
    this.ordersService.getOrdersForUser().subscribe({
      next: items => this.orders = items
    })
  }

}
