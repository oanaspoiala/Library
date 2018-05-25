import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';
import { HttpModule, Http } from '@angular/http';
import { HttpClientModule } from '@angular/common/http';
import { AngularFontAwesomeModule } from 'angular-font-awesome';
import { AppComponent } from './app.component';
import {
  NavigationComponent,
  HomeComponent,
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
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ContactReactiveComponent } from './components/contact-reactive/contact-reactive.component';



@NgModule({
  declarations: [
    AppComponent,
    NavigationComponent,
    HomeComponent,
    ContactComponent,
    FooterComponent,
    SidebarComponent,
    AuthorsComponent,
    BooksComponent,
    GendersComponent,
    LoansComponent,
    PageTitleComponent,
    ContactReactiveComponent,
  ],
  imports: [
    BrowserModule,
    HttpModule,
    FormsModule,
    ReactiveFormsModule,
    // FormControl,
    // FormArray,
    // FormBuilder,
    // FormGroup,
    // Validators,
    NgbModule.forRoot(),
    AngularFontAwesomeModule,
    AppRoutingModule,
    UiComponentsModule,
    HttpClientModule,
  ],
  providers: [ApiClientService],
  bootstrap: [AppComponent]
})
export class AppModule { }
