import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'lib-genders',
  templateUrl: './genders.component.html',
  styleUrls: ['./genders.component.scss']
})
export class GendersComponent implements OnInit {
  public title: string='Genders';
  constructor() { }

  ngOnInit() {
  }

}
