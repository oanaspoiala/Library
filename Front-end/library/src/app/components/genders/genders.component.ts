import { Component, OnInit } from '@angular/core';
import { Gender } from '../../models';
import { ApiClientService } from '../../services/api-client.service';
import { environment } from '../../../environments/environment';
import { GridColumn } from '../../ui-components';

@Component({
  selector: 'lib-genders',
  templateUrl: './genders.component.html',
  styleUrls: ['./genders.component.scss']
})
export class GendersComponent implements OnInit {
  public title: string = 'Genders';
  public apiUrl: string = `${environment.apiUrl}/Genders`;
  public items: Gender[] = [];
  public columns: GridColumn[] = [
    { title: 'Nume', fieldName: 'name', isSortable: true},
  ];

  constructor(
    private readonly api: ApiClientService
  ) { }

  ngOnInit() {
    this.getData();
  }

  public onPageChange(page) {
    console.log(`Page changed to ${page}`);
  }

  public onAddClick() {
    console.log('Add item');
  }

  public onEditClick(itemId: any) {
    console.log(`Edit item id ${itemId}`);
  }

  public onDeleteClick(itemId: any) {
    console.log(`Delete item id ${itemId}`);
  }

  public onDetailsClick(itemId: any) {
    console.log(`Details item id ${itemId}`);
    // TODO - afiseaza lista de carti pt genul respectiv
  }

  private getData() {
    this.api.get<Gender[]>(this.apiUrl)
      .subscribe((result: Gender[]) => {
        this.items = result;
      }, (error) => {
        console.error(error);
      });
  }

}
