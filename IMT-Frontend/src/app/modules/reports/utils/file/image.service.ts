import {Injectable} from '@angular/core';
import {environment} from "../../../../../environments/environment";
import {HttpClient} from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class ImageService {
  readonly #baseUrl = environment.apiUrl;
  readonly #endpoint = '/api/Images';


  constructor(private _http: HttpClient) { }

  getImageByStoreId(storeId: string) {
    return this._http.get(`${this.#baseUrl}${this.#endpoint}/${storeId}`, { responseType: 'blob' });
  }
}
