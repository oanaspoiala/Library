import { Component, OnInit, Input, forwardRef, HostBinding } from '@angular/core';
import { ControlValueAccessor, NG_VALUE_ACCESSOR } from '@angular/forms';

let nextId = 0;
const INPUT_TEXT_VALUE_ACCESSOR = forwardRef(() => InputTextComponent);
@Component({
  selector: 'lib-input-text',
  templateUrl: './input-text.component.html',
  styleUrls: ['./input-text.component.scss'],
  providers: [{provide: NG_VALUE_ACCESSOR, useExisting: INPUT_TEXT_VALUE_ACCESSOR, multi: true}]
})
export class InputTextComponent implements OnInit, ControlValueAccessor {

  @Input() id = `input-text-${++nextId}`;
  // TODO: find the right way to pass the class to inner control
  @Input() inputClass: string = 'form-control';

  public value: string;
  public isDisabled: boolean = false;

  public onChangeFnc = (_: any) => {};
  public onTouchedFnc = (_: any) => {};

  constructor() { }

  ngOnInit() {
  }

  writeValue(obj: any): void {
    if (obj === undefined) {
      return;
    }
    this.value = obj;
    this.onChangeFnc(this.value);
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

  onModelChanged() {
    this.onChangeFnc(this.value);
  }
}
