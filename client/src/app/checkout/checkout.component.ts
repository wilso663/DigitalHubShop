import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.scss']
})
export class CheckoutComponent {

  constructor(private formBuilder: FormBuilder){}
  
  checkoutForm = this.formBuilder.group({
    addressForm: this.formBuilder.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      street: ['', Validators.required],
      city: ['', Validators.required],
      state: ['', Validators.required],
      zipCode: ['', Validators.required]
    }),
    deliveryForm: this.formBuilder.group({
      deliveryMethod: ['', Validators.required]
    }),
    paymentForm: this.formBuilder.group({
      nameOnCard: ['', Validators.required]
    })
  });
}
