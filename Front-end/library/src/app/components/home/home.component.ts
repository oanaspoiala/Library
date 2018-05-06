import { Component, OnInit } from '@angular/core';
import { Tile } from '../../ui-components/models/tile.models';

@Component({
  selector: 'lib-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  public title: string = 'Welcome to my library';
  public tiles: Tile[] = [
    {title:'Author', pictureUrl:'', route:'/authors'},
    {title:'Books', pictureUrl:'', route:'/books'},
    {title:'Genders', pictureUrl:'', route:'/genders'},
    {title:'Loans', pictureUrl:'', route:'/loans'}
    // 'Authors',
    // 'Genders',
    // 'Books',
    // 'Loans'
  ]
  constructor() { }

  ngOnInit() {
  }

}
