import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'lib-books',
  templateUrl: './books.component.html',
  styleUrls: ['./books.component.scss']
})
export class BooksComponent implements OnInit {
  public title:string='Books';
  constructor() { }

  ngOnInit() {
  }

}
