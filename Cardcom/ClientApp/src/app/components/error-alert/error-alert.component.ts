import { Component, OnInit, Input,OnChanges } from '@angular/core';

@Component({
  selector: 'app-error-alert',
  templateUrl: './error-alert.component.html',
  styleUrls: ['./error-alert.component.scss']
})
export class ErrorAlertComponent implements OnChanges {
  @Input() errors;

  errorsList = [];
  patterns = [
    { name: "^\\d*$", text: "על השדה להכיל מספרים בלבד" },
    { name: "^[a-z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,4}$", text: 'על השדה להכיל טקסט בפורמט מייל' }
  ];
  constructor() { }

  ngOnChanges() {
    this.getErrors();
  }

  getErrors() {
    this.errorsList = [];
    for (var error in this.errors) {
      if (error == 'required')
        this.errorsList.push("השדה הינו שדה חובה");
      if (error == 'pattern')
        this.errorsList.push(this.patterns.find(f => f.name == this.errors[error].requiredPattern).text);

    }
  }

}
