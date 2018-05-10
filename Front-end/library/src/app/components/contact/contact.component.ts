import { Component, OnInit } from '@angular/core';
import {FormsModule} from '@angular/forms';

import * as moment from 'moment';
import { Contact } from './contact.model';

@Component({
  selector: 'lib-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.scss']
})
export class ContactComponent implements OnInit {
  public title: string = 'Information request';

  public item: Contact = {
    name: '',
    password: '',
    email: '',
    data: moment(),
    phone: 0,
    isActive: true
  };

  constructor() { }

  ngOnInit() {
  }

}
