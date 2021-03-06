import { RulesService } from './../../services/rules.service';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-rule-form',
  templateUrl: './rule-form.component.html',
  styleUrls: ['./rule-form.component.css'],
})
export class RuleFormComponent implements OnInit {
  form: FormGroup;
  sumitted: boolean = false;

  @Output() saveItem = new EventEmitter();

  constructor(private fb: FormBuilder, private service: RulesService) {}

  ngOnInit(): void {
    this.form = this.fb.group({
      days: [null, [Validators.required]],
      type: [null, [Validators.required]],
      interestPerDay: [null, [Validators.required]],
      penalty: [null, [Validators.required]],
    });
  }

  hasError(field: string) {
    return this.form.get(field).errors;
  }

  onSubmit() {
    this.sumitted = true;
    if (this.form.valid) {
      this.service.create(this.form.value).subscribe(
        (success) => {
          this.onCancel();
          alert('Regra Salva com sucesso!');
          this.saveItem.emit()
        },
        (error) => {
          alert(error.error.message);
        }
      );
    }
  }

  onCancel() {
    this.sumitted = false;
    this.form.reset();
  }
}
