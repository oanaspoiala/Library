import { Component, OnInit, Input, forwardRef, HostBinding } from '@angular/core';
import { ControlValueAccessor, NG_VALUE_ACCESSOR, FormControl } from '@angular/forms';

let nextId = 0;
const CHECKBOX_VALUE_ACCESSOR = forwardRef(() => CheckboxComponent);
@Component({
  selector: 'lib-checkbox',
  templateUrl: './checkbox.component.html',
  styleUrls: ['./checkbox.component.scss'],
  providers: [{ provide: NG_VALUE_ACCESSOR, useExisting: CHECKBOX_VALUE_ACCESSOR, multi: true}]
})
export class CheckboxComponent implements OnInit, ControlValueAccessor {

  @Input() id = `checkbox-${++nextId}`;
  @Input() type: boolean = false;
  @Input() inputClass: string = 'form-control';

  public value: boolean;
  public isDisabled: boolean = false;

  public onChangeFnc = (_: boolean) => {};
  public onTouchedFnc = (_: any) => {};

  constructor() { }

  ngOnInit() {
  }

  writeValue(obj: boolean): void {
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

  onModelChanged(event) {
    this.value = event;
    this.onChangeFnc(this.value);
  }
}


