import { Component, OnInit, Input } from '@angular/core';
import { Tile } from '../models/tile.models';
import { Router } from '@angular/router';

@Component({
  selector: 'lib-tile',
  templateUrl: './tile.component.html',
  styleUrls: ['./tile.component.scss']
})
export class TileComponent implements OnInit {
  @Input() tile: Tile;
  constructor(
    private router: Router
  ) { }

  ngOnInit() {
  }
  public onTileClick() {
    console.log(`tile ${this.tile.title} clicked`);
    this.router.navigate([this.tile.route]);
  }
}
