import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';


@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  public uri = 'https://localhost:44320/api/employee';

  constructor(private http: HttpClient,
    private router:Router) { }

  addEmployee(employee) {
    this.http.post(this.uri, employee)
        .subscribe(res => console.log('Done'));
  }

   getEmployees() {
    return this
           .http.get(`${this.uri}`);
  }

  editEmployee(id){
    return this
    .http
    .get(`${this.uri}/${id}`)
  }

  async updateEmployee(employee, id) {
    await
    this.http.put(`${this.uri}/${id}`, employee)
          .subscribe(res => {console.log('Done');
          debugger;
          this.router.navigate(['Index']);
        });
  }

  deleteEmployee(id) {
    return this
          .http
          .get(`${this.uri}/${id}`)
  }
}
