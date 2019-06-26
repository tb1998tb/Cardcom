import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { WebResult } from '../models/web-result';
import { IdName } from '../models/id-name';
import { Person } from '../models/person';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  genders: IdName[];
  persons: Person[];
  spinnerView: number=0;
  constructor(private http: HttpClient) {
    this.hideSpinner(2);
    this.http.get<WebResult>('/api/person/getgenders').subscribe((res) => {
      this.genders = res.value;
      this.showSpinner();
    });
    this.http.get<WebResult>('/api/person/getAll').subscribe((res) => {
      this.persons = res.value;
      this.showSpinner();
    });
  }

  showSpinner() {
    this.spinnerView = this.spinnerView == 0 ? 0 : this.spinnerView - 1;
  }

  hideSpinner(actions: number = 1) {
    this.spinnerView = this.spinnerView + actions;
  }
}
