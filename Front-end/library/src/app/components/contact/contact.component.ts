import { Component, OnInit, Injectable } from '@angular/core';

import * as moment from 'moment';
import { Contact } from './contact.model';
// import { ProductForm } from './product.model';

@Component({
  selector: 'lib-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.scss']
})
export class ContactComponent implements OnInit {
  public title: string = 'Information request';
  // public ProductForm: FormGroup;

  public item: Contact = {
    name: '',
    password: '',
    email: '',
    data: moment(),
    phone: 0,
    isActive: true,
    message: ''
  };

    constructor() {}

  ngOnInit() {
  }
}
