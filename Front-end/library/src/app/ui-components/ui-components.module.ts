import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TileComponent } from './tile/tile.component';
import { NgbModule} from '@ng-bootstrap/ng-bootstrap';
import { GridComponent } from './grid/grid.component';

const moduleComponents = [TileComponent, GridComponent];
@NgModule({
  imports: [
    CommonModule,
    NgbModule,
  ],
  declarations: [moduleComponents],
  exports: [moduleComponents]
})
export class UiComponentsModule { }
