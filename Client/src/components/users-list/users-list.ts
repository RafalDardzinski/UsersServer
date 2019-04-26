import { inject } from 'aurelia-framework';
import UsersService from '../../services/users';
import IService from '../../services/iservice';

@inject(UsersService)
export default class UsersList {
  users: Array<object> = [];

  constructor(private usersService: IService) { }

  created() {
    this.usersService.getAll().then(users => {
      this.users = users;
    })
  }

}
