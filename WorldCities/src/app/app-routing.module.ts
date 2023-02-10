import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddCityComponent } from './components/cities/add-city/add-city.component';
import { CityListComponent } from './components/cities/city-list/city-list.component';
import { CountryListComponent } from './components/countries/country-list/country-list.component';
import { CityEditComponent } from './components/cities/city-edit/city-edit.component';
import { CountryEditComponent } from './components/countries/country-edit/country-edit.component';

const routes: Routes = [
  {
    path: '',
    component: CityListComponent
  },

  {   
    path: 'cities',
    component: CityListComponent
  },
  {
    path: 'add-city',
    component: AddCityComponent
  },
  {
    path: 'city/:id',
    component: CityEditComponent
  },
  {
    path: 'countries',
    component: CountryListComponent
  },
  {
    path: 'country/:id',
    component: CountryEditComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
