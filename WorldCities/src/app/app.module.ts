import { AppRoutingModule } from './app-routing.module';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { CityListComponent } from './components/cities/city-list/city-list.component';
import { AddCityComponent } from './components/cities/add-city/add-city.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AngularMaterialModule } from './angular-material.module';
import { CountryListComponent } from './components/countries/country-list/country-list.component';
import { ReactiveFormsModule } from '@angular/forms';
import { CityEditComponent } from './components/cities/city-edit/city-edit.component';
import { CountryEditComponent } from './components/countries/country-edit/country-edit.component';
import { BaseFormComponent } from './components/base-form/base-form.component';



@NgModule({
  declarations: [
    AppComponent,
    CityListComponent,
    AddCityComponent,
    CountryListComponent,
    CityEditComponent,
    CountryEditComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    AngularMaterialModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
