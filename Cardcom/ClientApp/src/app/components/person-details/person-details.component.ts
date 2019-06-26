import { Component, OnInit, ViewChildren, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Person } from '../../models/person';
import { ApiService } from '../../services/api.service';
import { DatepickerOptions } from 'ng2-datepicker';
import * as moment from 'moment';
import * as enLocale from 'date-fns/locale/en';

@Component({
  selector: 'app-person-details',
  templateUrl: './person-details.component.html',
  styleUrls: ['./person-details.component.scss']
})
export class PersonDetailsComponent implements OnInit {
  person: Person
  birthdate;
  options: DatepickerOptions = {
    minYear: 1970,
    maxYear: 2030,
    displayFormat: 'DD/MM/YYYY',
    barTitleFormat: 'MMMM YYYY',
    dayNamesFormat: 'dd',
    addClass: 'form-control',
    addStyle: { 'backgroundColor': 'unset' },
    firstCalendarDay: 0, // 0 - Sunday, 1 - Monday
    locale: enLocale,
  };
  constructor(private route: ActivatedRoute, public api: ApiService) {
    this.getPerson();
    this.api.messages.subscribe(res => {
      this.getPerson();
    });
   
  }

  ngOnInit() {
  }

  getPerson() {
    if (this.api.persons) {
      this.person = this.api.persons.find(f => f.id.toString() == this.route.snapshot.paramMap.get('id'));
      if (this.person) {
        this.person.gender = this.person.gender ? this.person.gender : 0;
        this.birthdate = moment(this.person.birthdate).toDate();
        setTimeout(this.setDatePickerStyle, 500);
      }
    }
  }

  setDatePickerStyle() {
    var elems = <any>document.getElementsByClassName('ngx-datepicker-input');
    if (elems.length > 0) {
      elems[0].classList.remove('ngx-datepicker-input');
    }

  }

}
