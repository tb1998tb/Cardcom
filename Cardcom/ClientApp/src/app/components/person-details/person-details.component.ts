import { Component, OnInit, ViewChildren, ViewChild, HostListener } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Person } from '../../models/person';
import { ApiService } from '../../services/api.service';
import { DatepickerOptions } from 'ng2-datepicker';
import * as moment from 'moment';
import * as enLocale from 'date-fns/locale/en';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-person-details',
  templateUrl: './person-details.component.html',
  styleUrls: ['./person-details.component.scss']
})
export class PersonDetailsComponent implements OnInit {
  person: Person = new Person();
  birthdate;
  submitted = false;
  options: DatepickerOptions = {
    minYear: 1900,
    maxYear: 2030,
    displayFormat: 'DD/MM/YYYY',
    barTitleFormat: 'MMMM YYYY',
    dayNamesFormat: 'dd',
    addClass: 'form-control',
    addStyle: { 'backgroundColor': 'unset' },
    maxDate: new Date(),
    firstCalendarDay: 0, // 0 - Sunday, 1 - Monday,
  };
  constructor(private route: ActivatedRoute, public api: ApiService, private router: Router) {
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
        //this.birthdate = moment(this.person.birthdate).toDate();
      }
      else {
        this.person = new Person();
      }
      this.person.gender = this.person.gender ? this.person.gender : 0;
      setTimeout(this.setDatePickerStyle, 100);
    }
  }

  setDatePickerStyle() {
    var elems = <any>document.getElementsByClassName('ngx-datepicker-input');
    if (elems.length > 0) {
      elems[0].classList.remove('ngx-datepicker-input');
    }

  }
  @HostListener('click', ['$event.target'])
  onClick(target) {
    var elem2 = document.getElementsByClassName('ngx-datepicker-calendar-container');
    if (elem2 && elem2.length > 0) {
      var elem = target.closest(".ngx-datepicker-container");
      elem = elem == null ? target.closest(".main-calendar-years") : elem;
      if (!elem) elem2[0].remove();
    }

  }

  onSubmit(form: NgForm) {
    this.submitted = true;
    if (form.valid) {
      this.api.showSpinner();
      this.person.birthdate.setHours(10);
      this.api.setPerson(this.person).subscribe(res => {
        this.api.hideSpinner();
        alert(res.message);
        if (res.success) {
          this.api.getPersons();
          this.router.navigate(['']);
        }
      })
    }
  }

}
