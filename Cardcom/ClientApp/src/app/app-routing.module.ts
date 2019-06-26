import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { PersonDetailsComponent } from './components/person-details/person-details.component';

//This is my case 
const routes: Routes = [
  {path: "", component: HomeComponent },
  { path: "person-details/:id", component: PersonDetailsComponent },
  { path: "**", redirectTo:"''" }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
