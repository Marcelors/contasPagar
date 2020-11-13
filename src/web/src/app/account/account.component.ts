import { AccountService } from './../services/account.service';
import { accountModel } from './../model/account.model';
import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.css']
})
export class AccountComponent implements OnInit {

  accounts$: Observable<accountModel[]>

  constructor(private service: AccountService) { }

  ngOnInit(): void {
    this.onRefresh();
  }

  onRefresh(){
    this.accounts$ = this.service.get();
  }

  remove(id){
    this.service.remove(id).subscribe(
      (success) => {
        alert('Conta Removida com sucesso!');
        this.onRefresh()
      },
      (error) => {
        alert(error.error.message);
      }
    );
  }

  formatedDate(value) {
    return new Date(value).toLocaleDateString()
  }

}
