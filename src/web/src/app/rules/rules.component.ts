import { PaginedModel } from './../model/pagined.model';
import { RulesService } from '../services/rules.service';
import { Component, OnInit } from '@angular/core';
import { RuleModel } from '../model/rule.model';
import { Observable } from 'rxjs';
import { ReponseModel } from '../model/reponse.model';

@Component({
  selector: 'app-rules',
  templateUrl: './rules.component.html',
  styleUrls: ['./rules.component.css']
})
export class RulesComponent implements OnInit {

  rules$: Observable<RuleModel[]>

  constructor(private service: RulesService) {
  }

  ngOnInit(): void {
    this.onRefresh();
  }

  onRefresh(){
    this.rules$ = this.service.get();
  }

  remove(id){
    this.service.remove(id).subscribe(
      (success) => {
        alert('Regra Removida com sucesso!');
        this.onRefresh()
      },
      (error) => {
        alert(error.error.message);
      }
    );
  }

  enable(id){
    this.service.enable(id).subscribe(
      (success) => {
        alert('Regra Habilitada com sucesso!');
        this.onRefresh()
      },
      (error) => {
        alert(error.error.message);
      }
    );
  }

  disable(id){
    this.service.disable(id).subscribe(
      (success) => {
        alert('Regra Desabilitada com sucesso!');
        this.onRefresh()
      },
      (error) => {
        alert(error.error.message);
      }
    );
  }

}
