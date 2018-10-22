import { Component, OnInit } from '@angular/core';
import { Employee } from '../Employee';
import { EmployeeService } from '../employee.service';


@Component({
  selector: 'app-index-employeee',
  templateUrl: './index-employeee.component.html',
  styleUrls: ['./index-employeee.component.css']
})
export class IndexEmployeeeComponent implements OnInit {

  employees: Employee[];

  constructor(private employeeService: EmployeeService) { }

  ngOnInit() {
     this.employeeService.getEmployees()
      .subscribe((data: Employee[]) => {
        debugger;
        this.employees = data;
      });
  }
}
