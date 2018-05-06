import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'lib-loans',
  templateUrl: './loans.component.html',
  styleUrls: ['./loans.component.scss']
})
export class LoansComponent implements OnInit {
  public title:string='Loans';
  constructor() { }

  ngOnInit() {
  }

}
