import { Component, OnInit } from '@angular/core';
import { Person } from '../../models';
import { ApiClientService } from '../../services/api-client.service';
import { environment } from '../../../environments/environment';
import { GridColumn, SortItem } from '../../ui-components';

@Component({
  selector: 'lib-people',
  templateUrl: './people.component.html',
  styleUrls: ['./people.component.scss']
})
export class PeopleComponent implements OnInit {
  public title: string = 'Person';
  public apiUrl: string = `${environment.apiUrl}/People`;
  public items: Person[] = [];
  public columns: GridColumn[] = [
    { title: 'Nume', fieldName: 'firstName', isSortable: true},
    { title: 'Prenume', fieldName: 'lastName', isSortable: true},
    { title: 'Cnp', fieldName: 'cnp', isSortable: true},
    { title: 'Adresa', fieldName: 'address', isSortable: true},
    { title: 'Telefon', fieldName: 'phone', isSortable: true},
    { title: 'Email', fieldName: 'email', isSortable: true},
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
  // TODO - afiseaza lista de loans pt persoana respectiva
  }

  private getData() {
    this.api.get<Person[]>(this.apiUrl)
      .subscribe((result: Person[]) => {
        this.items = result;
      }, (error) => {
        console.error(error);
      });
  }

}
