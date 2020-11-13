import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AccountComponent } from './account.component';
import { AccountFormComponent } from './account-form/account-form.component';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [AccountComponent, AccountFormComponent],
  imports: [
    CommonModule,
    ReactiveFormsModule
  ],
  exports: [
    AccountComponent
  ]
})
export class AccountModule { }
