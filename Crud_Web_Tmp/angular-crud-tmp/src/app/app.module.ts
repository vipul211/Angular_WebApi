import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { ReactiveFormsModule } from '@angular/forms';
import { CreateEmployeeComponent } from './employee/create-employee/create-employee.component';
import { EditEmployeeeComponent } from './employee/edit-employeee/edit-employeee.component';
import { IndexEmployeeeComponent } from './employee/index-employeee/index-employeee.component';

import { RouterModule, Routes } from '@angular/router';
import {HttpClientModule} from '@angular/common/http';
import { EmployeeService } from './employee/employee.service';

const routes:Routes = [
  {
    path:'Create',
    component:CreateEmployeeComponent
  },
  {
    path:'Edit/:id',
    component:EditEmployeeeComponent
  },
  {
    path:'Index',
    component:IndexEmployeeeComponent
  }
]



@NgModule({
  declarations: [
    AppComponent,
    CreateEmployeeComponent,
    EditEmployeeeComponent,
    IndexEmployeeeComponent
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot(routes),
    HttpClientModule,
    ReactiveFormsModule
  ],
  providers: [EmployeeService],
  bootstrap: [AppComponent]
})
export class AppModule { }
