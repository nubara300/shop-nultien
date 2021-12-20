import {
  Component,
  EventEmitter,
  Inject,
  Input,
  OnInit,
  Optional,
  Output,
} from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  ValidatorFn,
} from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ActionType } from 'src/app/models';

@Component({
  selector: 'app-app-simple-form',
  templateUrl: './app-simple-form.component.html',
  styleUrls: ['./app-simple-form.component.scss'],
})
export class AppSimpleFormComponent implements OnInit {
  @Input() title: string = '';
  @Input() formConfiguration: FormControlConfig[] = [];
  @Input() actions: ActionType[] = [];
  @Output()
  emitAction = new EventEmitter();

  formGroup: FormGroup = this.fb.group({});
  constructor(
    private fb: FormBuilder,
    @Optional() public dialogRef: MatDialogRef<AppSimpleFormComponent>,
    @Optional()
    @Inject(MAT_DIALOG_DATA)
    public data: { title: string; formConfiguration: FormControlConfig[] }
  ) {
    if (this.dialogRef) {
      this.title = data.title;
      this.formConfiguration = data.formConfiguration;
    }
    this.formConfiguration?.forEach((control) => {
      this.formGroup?.addControl(
        control.key,
        new FormControl(null, control.validators ?? [])
      );
    });
  }

  ngOnInit(): void {}

  actionClicked(action: ActionType) {
    if (this.dialogRef) {
      this.dialogRef.close({
        action: action.event,
        formValue: this.formGroup.value,
      });
    } else {
      this.emitAction.emit({
        action: action.event,
        formValue: this.formGroup.value,
      });
    }
  }
}

export interface FormControlConfig {
  key: string;
  label: string;
  validators?: ValidatorFn[];
  type: 'input' | 'select' | 'checkbox'; //add other types
  isRequired?: boolean;
}
