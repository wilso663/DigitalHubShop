import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { environment } from 'src/environment/environment';

@Component({
  selector: 'app-test-error',
  templateUrl: './test-error.component.html',
  styleUrls: ['./test-error.component.scss']
})
export class TestErrorComponent {
  baseUrl = environment.apiUrl;

  constructor(private httpClient: HttpClient){

  }

  get404Error() {
    this.httpClient.get(this.baseUrl + 'products/42').subscribe({
      next: response => console.log(response),
      error: error => console.log(error),
    })
  }

  get500Error() {
    this.httpClient.get(this.baseUrl + 'buggy/servererror').subscribe({
      next: response => console.log(response),
      error: error => console.log(error),
    })
  }

  get400Error() {
    this.httpClient.get(this.baseUrl + 'buggy/badrequest').subscribe({
      next: response => console.log(response),
      error: error => console.log(error),
    })
  }
  get400ValidationError() {
    this.httpClient.get(this.baseUrl + 'products/fourtytwo').subscribe({
      next: response => console.log(response),
      error: error => console.log(error),
    })
  }
}
