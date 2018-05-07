import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent, AuthorsComponent, BooksComponent, GendersComponent, LoansComponent } from './components';
import { ContactComponent } from './components/contact/contact.component';

const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'home', redirectTo: ''},
  {path: 'find', redirectTo: 'search'},
  {path: 'contact', component: ContactComponent},
  {path: 'authors', component: AuthorsComponent},
  {path:'books', component: BooksComponent},
  {path:'genders', component: GendersComponent},
  {path:'loans', component: LoansComponent},
  {path: '**', redirectTo: 'home'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
