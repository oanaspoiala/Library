import { Component, OnInit } from '@angular/core';
import { Author } from '../../models';
import { ApiClientService } from '../../services/api-client.service';
import { environment } from '../../../environments/environment';

@Component({
  selector: 'lib-authors',
  templateUrl: './authors.component.html',
  styleUrls: ['./authors.component.scss']
})
export class AuthorsComponent implements OnInit {
  public title: string = 'Autori';
  public apiUrl: string = `${environment.apiUrl}/Authors`;
  public items: Author[] = [];
  constructor(
    private readonly api: ApiClientService
  ) { }

  ngOnInit() {
    this.getData();
  }

  getData() {
    this.api.get<Author[]>(this.apiUrl)
      .subscribe((result: Author[]) => {
        console.log(result);
      }, (error) => {
        console.error(error);
      });
  }
}
