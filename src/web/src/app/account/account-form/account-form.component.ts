import { AccountService } from './../../services/account.service';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-account-form',
  templateUrl: './account-form.component.html',
  styleUrls: ['./account-form.component.css']
})
export class AccountFormComponent implements OnInit {
  form: FormGroup;
  sumitted: boolean = false;

  @Output() saveItem = new EventEmitter();

  constructor(private fb: FormBuilder, private service: AccountService) {}

  ngOnInit(): void {
    this.form = this.fb.group({
      name: [null, [Validators.required]],
      originalValue: [null, [Validators.required]],
      paymentDate: [null, [Validators.required]],
      dueDate: [null, [Validators.required]],
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
          alert('Conta Salva com sucesso!');
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
