import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'lib-authors',
  templateUrl: './authors.component.html',
  styleUrls: ['./authors.component.scss']
})
export class AuthorsComponent implements OnInit {
  public title:string = 'Autori';
  constructor() { }

  ngOnInit() {
  }

}
