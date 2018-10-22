import { Component, OnInit } from '@angular/core';
import { FormGroup,  FormBuilder,  Validators } from '@angular/forms';
import { EmployeeService } from '../employee.service';
import { AddEmployee } from '../AddEmployee';

@Component({
  selector: 'app-create-employee',
  templateUrl: './create-employee.component.html',
  styleUrls: ['./create-employee.component.css']
})
export class CreateEmployeeComponent implements OnInit {

  title = 'Add Employee';
  angForm: FormGroup;
  employee: AddEmployee;
  constructor(private Employeeservice: EmployeeService, private fb: FormBuilder) {
    this.createForm();
   }

   createForm() {
    this.angForm = this.fb.group({
      firstname: ['', Validators.required ],
      lastname: ['', Validators.required ],
      birthdate:['',Validators.required],
      phone:['',Validators.required],
      email:['',Validators.required]
   });
  }

  addEmployee(angForm) {
    // debugger;
      console.log(this.angForm.value);
      this.employee = {
        firstname:this.angForm.value['firstname'],
        lastname:this.angForm.value['lastname'],
        birthdate:this.angForm.value['birthdate'],
        phone:this.angForm.value['phone'],
        email:this.angForm.value['email']
      };

      console.log(this.employee);
      
      this.Employeeservice.addEmployee(this.employee);
  }

  ngOnInit() {
  }

}
