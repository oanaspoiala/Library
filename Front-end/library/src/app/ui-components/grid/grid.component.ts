import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { GridColumn } from '../models/grid-column.model';
import { SortItem } from '..';

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
  @Output() headerClick: EventEmitter<SortItem> = new EventEmitter<SortItem>();
  @Output() editClick: EventEmitter<any> = new EventEmitter();
  @Output() detailsClick: EventEmitter<any> = new EventEmitter();
  @Output() deleteClick: EventEmitter<any> = new EventEmitter();
  @Output() addClick: EventEmitter<any> = new EventEmitter();

  public sortItem: SortItem = {fieldName: '', descending: false};
  public page: number = 1;

  constructor() { }

  ngOnInit() {
  }

  public onHeaderClick(isSortable: boolean, fieldName: string) {
    if (isSortable) {
      if (this.sortItem.fieldName === fieldName) {
        this.sortItem.descending = ! this.sortItem.descending;
      } else {
        this.sortItem.fieldName = fieldName;
        this.sortItem.descending = false;
      }
      this.headerClick.emit(this.sortItem);
    }
  }

  public onAddClick() {
    this.addClick.emit(null);
  }

  public onEditClick(itemId: any) {
    this.editClick.emit(itemId);
  }

  public onDeleteClick(itemId: any) {
    this.deleteClick.emit(itemId);
  }

  public onDetailsClick(itemId: any) {
    this.detailsClick.emit(itemId);
  }
}
