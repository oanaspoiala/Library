import { Component, OnInit } from '@angular/core';
import {FormsModule} from '@angular/forms';

import * as moment from 'moment';

@Component({
  selector: 'lib-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.scss']
})
export class ContactComponent implements OnInit {

  public title: string = 'Information request';
  public name: string = '';
  public email: string = '';
  public phone: number = 0;
  public data = moment();
  constructor() { }

  ngOnInit() {
  }

}
