import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EditEmployeeeComponent } from './edit-employeee.component';

describe('EditEmployeeeComponent', () => {
  let component: EditEmployeeeComponent;
  let fixture: ComponentFixture<EditEmployeeeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EditEmployeeeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EditEmployeeeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
