import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

let nextId: number = 0;

@Component({
  selector: 'lib-input-button',
  templateUrl: './input-button.component.html',
  styleUrls: ['./input-button.component.scss']
})
export class InputButtonComponent implements OnInit {
  @Input() id: string = `button-${++nextId}`;
  @Input() targetId: any;

  @Output() editClick: EventEmitter<any> = new EventEmitter();
  @Output() deleteClick: EventEmitter<any> = new EventEmitter();
  @Output() detailsClick: EventEmitter<any> = new EventEmitter();

  constructor() { }

  ngOnInit() {
  }

  public onEditClick() {
    this.editClick.emit(this.targetId);
  }

  public onDeleteClick() {
    this.deleteClick.emit(this.targetId);
  }

  public onDetailsClick() {
    this.detailsClick.emit(this.targetId);
  }
}
