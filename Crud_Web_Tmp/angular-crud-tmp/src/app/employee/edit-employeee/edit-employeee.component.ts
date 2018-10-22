import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { EmployeeService } from '../employee.service';
import { Employee } from '../Employee';

@Component({
  selector: 'app-edit-employeee',
  templateUrl: './edit-employeee.component.html',
  styleUrls: ['./edit-employeee.component.css']
})
export class EditEmployeeeComponent implements OnInit {

  employee: any = {};
  angForm: FormGroup;
  constructor(private route: ActivatedRoute,
    private router: Router,
    private employeeService: EmployeeService,
    private fb: FormBuilder) {
    this.createForm();
  }

  createForm() {
    this.angForm = this.fb.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      birthDate: ['', Validators.required],
      phoneNo: ['', Validators.required],
      email: ['', Validators.required],
    });
  }

  ngOnInit() {
    debugger;
    this.route.params.subscribe(params => {
      this.employeeService.editEmployee(params['id']).subscribe(res => {
        debugger;
        console.log('employee details', res);
        debugger;
        this.angForm.patchValue({
          firstName: res['firstName'],
          lastName: res['lastName'],
          birthDate: new String(res['birthDate']).split('T')[0],
          phoneNo: res['phoneNo'],
          email: res['email']
        });
      });
    });
  }

  updateEmployee(angForm){
    debugger;
    console.log(this.angForm.value);
    this.employee = {
      firstName:this.angForm.value['firstName'],
      lastName:this.angForm.value['lastName'],
      birthDate:this.angForm.value['birthDate'],
      phoneNo:this.angForm.value['phoneNo'],
      email:this.angForm.value['email']
    };

    console.log(this.employee);
    this.route.params.subscribe(params => {
      debugger;
      this.employeeService.updateEmployee(this.employee, params['id']);
      
    });
  }

}
