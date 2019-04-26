import {autoinject} from 'aurelia-framework';
import {HttpClient} from 'aurelia-fetch-client';
import Api from './api';

@autoinject
export class Users {
  public heading: string = 'Github Users';
  public users: any[] = [];

  constructor(private http: HttpClient, private api : Api) {
    http.configure(config => {
      config
        .useStandardConfiguration()
        .withBaseUrl('https://api.github.com/');
    });
  }

  async activate(): Promise<void> {
    const response = await this.http.fetch('users');
    const users = await this.api.get('users');
    console.log(await users.json());
    this.users = await response.json();
  }
}
