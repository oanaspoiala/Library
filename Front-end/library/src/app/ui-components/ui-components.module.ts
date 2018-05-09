import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TileComponent } from './tile/tile.component';
import { NgbModule} from '@ng-bootstrap/ng-bootstrap';
import { GridComponent } from './grid/grid.component';
import { LabelComponent } from './label/label.component';
import { InputTextComponent } from './input-text/input-text.component';
import { InputNumberComponent } from './input-number/input-number.component';
import { DatePickerComponent } from './date-picker/date-picker.component';
import { DropdownComponent } from './dropdown/dropdown.component';
import { FormsModule } from '@angular/forms';

const moduleComponents = [
  TileComponent,
  GridComponent,
  LabelComponent,
  InputTextComponent,
  InputNumberComponent,
  DatePickerComponent,
  DropdownComponent,
];
@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    NgbModule,
  ],
  declarations: [moduleComponents, InputTextComponent, InputNumberComponent, DatePickerComponent, DropdownComponent],
  exports: [moduleComponents]
})
export class UiComponentsModule { }
