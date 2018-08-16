import { Component, OnInit, Input, forwardRef } from '@angular/core';
import { ControlValueAccessor, NG_VALUE_ACCESSOR } from '@angular/forms';
import * as _ from 'lodash';
import { FieldTypes } from '..';

let nextId = 0;

@Component({
  selector: 'lib-input',
  templateUrl: './input.component.html',
  styleUrls: ['./input.component.scss'],
  providers: [{ provide: NG_VALUE_ACCESSOR, useExisting: forwardRef(() => InputComponent), multi: true}]
})
export class InputComponent implements OnInit, ControlValueAccessor {
  public FieldTypes = FieldTypes;
  @Input() id: string = `input-${++nextId}`;
  @Input() fieldType: FieldTypes = FieldTypes.Text;
  @Input() isDisabled: boolean = false;
  @Input('value')
  set value(val: any) {
    this._value = val;
    this.onChangeFnc(this._value);
  }
  get value(): any {
    return this._value;
  }

  public onChangeFnc: (_: any) => {};
  public onTouchedFnc: (_: any) => {};

  public _value: any;

  constructor() { }

  ngOnInit() {
  }

  writeValue(obj: any): void {
    this.value = _.cloneDeep(obj);
  }

  registerOnChange(fn: any): void {
    this.onChangeFnc = fn;
  }

  registerOnTouched(fn: any): void {
    this.onTouchedFnc = fn;
  }

  setDisabledState?(isDisabled: boolean): void {
    this.isDisabled = isDisabled;
  }

  public onValueChange(value: any) {
    this.onChangeFnc(this.value);
  }
}
