import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'lib-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  public title: string = 'Welcome to my library';
  constructor() { }

  ngOnInit() {
  }

}
