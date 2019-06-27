export class Person {
  id: number;
  tz: string;
  name: string;
  mail?: string;
  birthdate?: Date;
  gender: number;
  telephone: string;

  constructor() {
    this.birthdate = null;
  }
}
