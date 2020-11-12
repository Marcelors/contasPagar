import { RuleModel } from './../model/rule.model';
import { PaginedModel } from './../model/pagined.model';
import { environment } from './../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ReponseModel } from '../model/reponse.model';
import { map, take } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
export class RulesService {
  private readonly API = `${environment.apiUrl}v1/rules`;

  constructor(private http: HttpClient) {}

  get() {
    return this.http.get<ReponseModel<PaginedModel<RuleModel>>>(this.API).pipe(
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

  enable(id) {
    return this.http.post(`${this.API}/enable/${id}`, null).pipe(take(1));
  }

  disable(id) {
    return this.http.post(`${this.API}/disable/${id}`, null).pipe(take(1));
  }
}
