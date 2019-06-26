import { Pipe, PipeTransform } from '@angular/core';
import { IdName } from '../models/id-name';
import { ApiService } from '../services/api.service';

@Pipe({
  name: 'gender'
})
export class GenderPipe implements PipeTransform {

  constructor(private api: ApiService) { }
  transform(value: any): string {
    if (this.api.genders && this.api.genders.length > 0) {
      var g = this.api.genders.find(f => f.id == value);
      if (g)
        return g.name;
      return this.api.genders[0].name;
    }
    return '';
  }

}
