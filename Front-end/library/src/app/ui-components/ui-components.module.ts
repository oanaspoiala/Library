import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TileComponent } from './tile/tile.component';

const moduleComponents = [TileComponent];
@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [moduleComponents],
  exports: [moduleComponents]
})
export class UiComponentsModule { }
