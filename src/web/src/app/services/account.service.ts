import { accountModel } from './../model/account.model';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { PaginedModel } from '../model/pagined.model';
import { ReponseModel } from '../model/reponse.model';
import { map, take } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  private readonly API = `${environment.apiUrl}v1/accounts`;

  constructor(private http: HttpClient) {}

  get() {
    return this.http.get<ReponseModel<PaginedModel<accountModel>>>(this.API).pipe(
      map((x) => {
        return x.data.items;
      })
    );
  }

  create(rule) {
    return this.http.post(this.API, rule).pipe(take(1));
  }

  remove(id) {
    return this.http.delete(`${this.API}/${id}`).pipe(take(1));
  }
}
