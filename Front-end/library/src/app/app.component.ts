import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'lib-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit{
  title = 'My library';
  constructor(){
  }

  ngOnInit() { 
  }
}
