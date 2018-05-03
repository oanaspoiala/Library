import { Component } from '@angular/core';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'lib-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'My library';
  form: FormGroup;

  constructor(){
    //this.createForm();
  }
}
