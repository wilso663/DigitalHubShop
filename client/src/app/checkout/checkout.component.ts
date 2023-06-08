import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { AccountService } from '../account/account.service';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.scss']
})
export class CheckoutComponent implements OnInit {

  constructor(private formBuilder: FormBuilder, private accountService: AccountService){}
  
  ngOnInit(): void {
    this.getAddressFormValues();
  }
  
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

  getAddressFormValues() {
    this.accountService.getUserAddress().subscribe({
      next: address => {
        address && this.checkoutForm.get('addressForm')?.patchValue(address)
      }
    })
  }
}
