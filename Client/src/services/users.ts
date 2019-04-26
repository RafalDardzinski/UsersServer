import { inject } from 'aurelia-framework';
import IService from './iservice';
import Api from '../api';

@inject(Api)
export default class UsersService implements IService {

  constructor(private api : Api) {  }

  async getAll() {
      return this.api.get('users')
  }

}
