import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http'
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { City } from '../models/city';
import { ApiResult, BaseService } from './base.service';
import { Country } from '../models/country';


@Injectable({
  providedIn: 'root'
})
export class CityService extends BaseService<City> {
  

  baseApiUrl: string = environment.baseApiUrl;

  constructor(http: HttpClient) {
    super(http);
  }
  getData(pageIndex: number, pageSize: number, sortColumn: string,
    sortOrder: string, filterColumn: string | null, filterQuery: string | null): Observable<ApiResult<City>> {
    var url = this.getUrl("/api/City/GetAllCities");
    var params = new HttpParams()
      .set("pageIndex", pageIndex.toString())
      .set("pageSize", pageSize.toString())
      .set("sortColumn", sortColumn)
      .set("sortOrder", sortOrder);

    if (filterColumn && filterQuery) {
      params = params
        .set("filterColumn", filterColumn)
        .set("filterQuery", filterQuery);
    }

    return this.http.get<ApiResult<City>>(url, { params });

  }
  
  
  get(id: number): Observable<City> {
    var url = this.getUrl("/api/City/GetCityDetails/" + id);
    return this.http.get<City>(url);
  }
  put(item: City): Observable<City> {
    var url = this.getUrl("/api/City/EditCity/");
    return this.http.put<City>(url, item);
  }
  post(item: City): Observable<City> {
    var url = this.getUrl("/api/City/CreateCity/");
    return this.http.post<City>(url, item);
  }
  getCountries(
    pageIndex: number,
    pageSize: number,
    sortColumn: string,
    sortOrder: string,
    filterColumn: string | null,
    filterQuery: string | null
  ): Observable<ApiResult<Country>> {
    var url = this.getUrl("/api/Country/GetAllCountries/");
    var params = new HttpParams()
      .set("pageIndex", pageIndex.toString())
      .set("pageSize", pageSize.toString())
      .set("sortColumn", sortColumn)
      .set("sortOrder", sortOrder);

    if (filterColumn && filterQuery) {
      params = params
        .set("filterColumn", filterColumn)
        .set("filterQuery", filterQuery);
    }

    return this.http.get<ApiResult<Country>>(url, { params });
  }

  isDupeCity(item: City): Observable<boolean> {
    var url = this.getUrl("/api/City/IsDupeCity/");
    return this.http.post<boolean>(url, item);
  }
}
