import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { WebResult } from '../models/web-result';
import { IdName } from '../models/id-name';
import { Person } from '../models/person';
import { Subject } from 'rxjs';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  genders: IdName[];
  persons: Person[];
  messages: Subject<any> = new Subject<any>();
  spinnerView: number = 0;
  constructor(private http: HttpClient, public alert: ToastrService) {
    this.getGenders();
    this.getPersons();
  }

  getGenders() {
    this.showSpinner();
    this.http.get<WebResult>('/api/person/getgenders').subscribe((res) => {
      this.genders = res.value;
      this.hideSpinner();
      this.nextMessage({ name: 'genders', value: this.genders });
    });
  }

  getPersons() {
    
    this.showSpinner();
    this.http.get<WebResult>('/api/person/getAll').subscribe((res) => {
      this.persons = res.value;
      this.hideSpinner();
      this.nextMessage({ name: 'persons', value: this.persons });

    });
  }

  hideSpinner() {
    this.spinnerView = this.spinnerView == 0 ? 0 : this.spinnerView - 1;
  }

  showSpinner(actions: number = 1) {
    this.spinnerView = this.spinnerView + actions;
  }

  nextMessage(data) {
    this.messages.next(data);
  }

  setPerson(person: Person) {
    return this.http.post<WebResult>('/api/person/setPerson', person)
  }

  message(data: WebResult) {
    if (data.success)
      this.alert.success(data.message);
    else
      this.alert.error(data.message);
  }

  deletePerson(person) {
    this.showSpinner()
    this.http.post<WebResult>('/api/person/deletePerson', person).subscribe((res) => {
      this.persons = this.persons.filter(f => f.id != person.id);
      this.hideSpinner();
      this.message(res);
    });
  }
}
