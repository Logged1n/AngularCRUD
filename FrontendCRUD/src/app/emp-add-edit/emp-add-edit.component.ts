import {Component, Inject, OnInit} from '@angular/core';
import {FormBuilder, FormGroup} from "@angular/forms";
import {EmployeeService} from "../services/employee.service";
import {DialogRef} from "@angular/cdk/dialog";
import {MAT_DIALOG_DATA} from "@angular/material/dialog";
import {CoreService} from "../core/core.service";
@Component({
  selector: 'app-emp-add-edit',
  templateUrl: './emp-add-edit.component.html',
  styleUrl: './emp-add-edit.component.css'
})
export class EmpAddEditComponent implements OnInit {
  empForm: FormGroup;
  education: string[] = [
    'None',
    'Basic',
    'Intermediate',
    'Advanced'
  ]

  constructor(
    private _fb: FormBuilder,
    private _empService: EmployeeService,
    private _dialogRef: DialogRef<EmpAddEditComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private _coreService: CoreService) {
    this.empForm = this._fb.group({
      firstName: "",
      lastName: "",
      email: "",
      dob: "",
      gender: "",
      education: "",
      company: "",
      experience: "",
      salary: "",
      photoSVG: ""
    })
  }

  ngOnInit(): void {
    this.empForm.patchValue(this.data);
  }

  onFormSubmit() {
    if (this.empForm.valid) {
      const formData = this.empForm.value;
      if (this.data) {
        formData.id = this.data.id; // id assign on sending form
        this._empService
          .updateEmployee(formData)
          .subscribe({
            next: (val: any) => {
              this._coreService.openSnackBar('Employee detail updated!');
              this._dialogRef.close();
            },
            error: (err: any) => {
              console.error(err);
            },
          });
      } else {
        this._empService.addEmployee(formData).subscribe({
          next: (val: any) => {
            this._coreService.openSnackBar('Employee added successfully');
            this._dialogRef.close();
          },
          error: (err: any) => {
            console.error(err);
          },
        });
      }
    }
  }
}
