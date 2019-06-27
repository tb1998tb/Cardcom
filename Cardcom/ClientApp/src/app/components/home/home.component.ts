import { Component, OnInit } from '@angular/core';
import { ApiService } from '../../services/api.service';
import Swal from 'sweetalert2'
import { Person } from '../../models/person';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  constructor(public api: ApiService) {
    this.api.getPersons();
  }

  ngOnInit() {
  }

  deletePerson(person: Person) {
    Swal.fire({
      title: `האם את/ה בטוח/ה שברצונך למחוק את ${person.name} ?`,
      text: "לא תוכל לשחזר את הפעולה!",
      type: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'כן, מחק אותו!',
      cancelButtonText: "לא"
    }).then((result) => {
      if (result.value) {
        this.api.deletePerson(person)
      }
    })
  }


}
