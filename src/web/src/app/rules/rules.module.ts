import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RulesComponent } from './rules.component';
import { RuleFormComponent } from './rule-form/rule-form.component';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [RulesComponent, RuleFormComponent],
  imports: [
    CommonModule,
    ReactiveFormsModule
  ],
  exports: [
    RulesComponent
  ]
})
export class RulesModule { }
