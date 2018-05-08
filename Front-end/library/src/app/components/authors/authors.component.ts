import { Component, OnInit } from '@angular/core';
import { Author } from '../../models';
import { ApiClientService } from '../../services/api-client.service';
import { environment } from '../../../environments/environment';
import { DateUtils } from '../../shared';
import { GridColumn, SortItem } from '../../ui-components';

@Component({
  selector: 'lib-authors',
  templateUrl: './authors.component.html',
  styleUrls: ['./authors.component.scss']
})
export class AuthorsComponent implements OnInit {
  public title: string = 'Autori';
  public apiUrl: string = `${environment.apiUrl}/Authors`;
  public items: Author[] = [];
  public columns: GridColumn[] = [
    { title: 'Prenume', fieldName: 'firstName', isSortable: true},
    { title: 'Nume', fieldName: 'lastName', isSortable: true},
    { title: 'Data nasterii', fieldName: 'birthDate', isSortable: true},
    { title: 'Data decesului', fieldName: 'deathDate', isSortable: true}
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

  public onSortChange(sortItem: SortItem) {
    console.log(`Sort by ${JSON.stringify(sortItem)}`);
  }
  private getData() {
    this.api.get<Author[]>(this.apiUrl)
      .subscribe((result: Author[]) => {
        result.forEach((item: Author) => {
          item.birthDate = DateUtils.dateFormat(item.birthDate);
          item.deathDate = DateUtils.dateFormat(item.deathDate);
          this.items = result;
          console.log(result);
        });
      }, (error) => {
        console.error(error);
      });
  }
}
