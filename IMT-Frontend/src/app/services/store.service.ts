import {Injectable} from '@angular/core';
import {environment} from "../../environments/environment";
import {HttpClient} from "@angular/common/http";
import {Store} from "../models/store.model";

@Injectable({
  providedIn: 'root'
})
export class StoreService {
  readonly #baseUrl = environment.apiUrl;
  readonly #endpoint = '/api/Stores';

  constructor(private _http: HttpClient) {
  }

  getStores() {
    return this._http.get<Store[]>(`${this.#baseUrl}${this.#endpoint}`);
  }
}
