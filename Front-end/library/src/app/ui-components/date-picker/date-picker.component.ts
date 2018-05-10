import { Component, OnInit, Input, forwardRef } from '@angular/core';
import { DMY, DateUtils } from '../../shared';
import { ControlValueAccessor, NG_VALUE_ACCESSOR } from '@angular/forms';

let nextId: number = 0;

@Component({
  selector: 'lib-date-picker',
  templateUrl: './date-picker.component.html',
  styleUrls: ['./date-picker.component.scss'],
  providers: [{provide: NG_VALUE_ACCESSOR, useExisting: forwardRef(() => DatePickerComponent), multi: true}],
})
export class DatePickerComponent implements OnInit, ControlValueAccessor {

  @Input() id: string = `datepicker-${++nextId}`;

  public _model: DMY;
  public set model(value: any) {
    this._model = DateUtils.dateToDmy(value);
    this.fncOnChange(this.model);
  }

  public get model(): any {
    return DateUtils.dmyToDate(this._model);
  }

  isDisabled: boolean = false;
  public fncOnChange = (_: any) => {};
  public fncOnTouched = (_: any) => {};

  constructor() { }

  ngOnInit() {
  }
  public onDataChanged() {
    this.fncOnChange(this.model);
  }
  writeValue(obj: any): void {
    this.model = obj;
  }
  registerOnChange(fn: any): void {
    this.fncOnChange = fn;
  }
  registerOnTouched(fn: any): void {
    this.fncOnTouched = fn;
  }
  setDisabledState?(isDisabled: boolean): void {
    this.isDisabled = isDisabled;
  }

}
