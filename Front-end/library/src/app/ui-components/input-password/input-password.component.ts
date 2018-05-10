import { Component, OnInit, Input, forwardRef, HostBinding } from '@angular/core';
import { ControlValueAccessor, NG_VALUE_ACCESSOR, FormControl } from '@angular/forms';

let nextId = 0;
const INPUT_PASSWORD_VALUE_ACCESSOR = forwardRef(() => InputPasswordComponent);

@Component({
  selector: 'lib-input-password',
  templateUrl: './input-password.component.html',
  styleUrls: ['./input-password.component.scss'],
  providers: [{ provide: NG_VALUE_ACCESSOR, useExisting: INPUT_PASSWORD_VALUE_ACCESSOR, multi: true}]
})
export class InputPasswordComponent implements OnInit, ControlValueAccessor {

  @Input() id = `input-password-${++nextId}`;
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

