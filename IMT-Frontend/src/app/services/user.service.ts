import {Injectable} from '@angular/core';
import {environment} from "../../environments/environment";
import {HttpClient} from "@angular/common/http";
import {User} from "../models/user.model";

@Injectable({
  providedIn: 'root'
})
export class UserService {
  readonly #baseUrl = environment.apiUrl;
  readonly #endpoint = '/api/Users';

  constructor(private _http: HttpClient) {
  }

  getUsers() {
    return this._http.get<Array<User>>(`${this.#baseUrl}${this.#endpoint}`);
  }

  getUserById(id: string) {
    return this._http.get<User>(`${this.#baseUrl}${this.#endpoint}/${id}`);
  }

  createUser(user: User) {
    return this._http.post(`${this.#baseUrl}${this.#endpoint}`, user);
  }
}
