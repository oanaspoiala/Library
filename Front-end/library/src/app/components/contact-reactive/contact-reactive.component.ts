import { Component, OnInit } from '@angular/core';
import {
  FormsModule,
  ReactiveFormsModule,
  FormControl,
  FormBuilder,
  FormGroup,
  FormArray,
  Validators
} from '@angular/forms';
import * as moment from 'moment';

import { Contact } from '../contact/contact.model';

@Component({
  selector: 'lib-contact-reactive',
  templateUrl: './contact-reactive.component.html',
  styleUrls: ['./contact-reactive.component.scss']
})
export class ContactReactiveComponent implements OnInit {
  public title: string = 'Contact form';
  public item: Contact = {
    name: 'Farafastoaca',
    password: '',
    email: '',
    data: moment(),
    phone: 0,
    isActive: true,
    message: ''
  };

  public formGroup: FormGroup;

  constructor(private fb: FormBuilder) {
    this.createForm();
    this.formGroup.setValue(this.item);
   }

  ngOnInit() {
  }


  createForm() {
     this.formGroup = this.fb.group({
      name: new FormControl(null, [Validators.required, Validators.minLength(3)]),
      password: new FormControl(null, [Validators.required, Validators.maxLength(530)]),
      email: new FormControl(null, [Validators.required, Validators.maxLength(530)]),
      data: new FormControl(null, [Validators.required, Validators.maxLength(530)]),
      phone: new FormControl(null, [Validators.required, Validators.maxLength(530)]),
      isActive: new FormControl(null, [Validators.required, Validators.maxLength(530)]),
      message: new FormControl()
    });
  }

  public onSubmit() {
    const result = {...this.formGroup.value};
    console.log(this.formGroup.controls['name'].errors);
  }

  public revert() {
    this.formGroup.reset();
  }
}
