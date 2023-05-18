import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'DigiShop';
  products: any[] = [];

  constructor(private http: HttpClient) {
    this.http.get('https://localhost:7068/api/products').subscribe({
      next: (response: any) => this.products = response.data,
      error: error => console.log(error),
      complete: () => {
        console.log('request complete')
      }
    });
  }
}


