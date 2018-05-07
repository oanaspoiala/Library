import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { GridColumn } from '../models/grid-column.model';

@Component({
  selector: 'lib-grid',
  templateUrl: './grid.component.html',
  styleUrls: ['./grid.component.scss']
})
export class GridComponent implements OnInit {
  @Input() class: string = 'table table-bordered table-striped table-hover table-condensed';
  @Input() columns: GridColumn[] = [];
  @Input() items: object[] = [];
  @Output() pageChange: EventEmitter<number> = new EventEmitter<number>();

  public page:number = 1;

  constructor() { }

  ngOnInit() {
  }

}
