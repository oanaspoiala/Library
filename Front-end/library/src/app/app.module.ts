import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';
import { HttpModule, Http } from '@angular/http';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import {
  NavigationComponent, 
  HomeComponent, 
  GridComponent, 
  SidebarComponent, 
  FooterComponent,
  AuthorsComponent,
  BooksComponent,
  GendersComponent,
  LoansComponent } from './components';
import { ContactComponent } from './components/contact/contact.component';
import { UiComponentsModule } from './ui-components/ui-components.module';
import { PageTitleComponent } from './components/page-title/page-title.component';
import { ApiClientService } from './services/api-client.service';



@NgModule({
  declarations: [
    AppComponent,
    NavigationComponent,
    HomeComponent,
    GridComponent,
    ContactComponent,
    FooterComponent,
    SidebarComponent,
    AuthorsComponent,
    BooksComponent,
    GendersComponent,
    LoansComponent,
    PageTitleComponent,
  ],
  imports: [
    BrowserModule,
    HttpModule,
    NgbModule.forRoot(),
    AppRoutingModule,
    UiComponentsModule,
    HttpClientModule,
  ],
  providers: [ApiClientService],
  bootstrap: [AppComponent]
})
export class AppModule { }
