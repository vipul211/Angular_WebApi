import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { IndexEmployeeeComponent } from './index-employeee.component';

describe('IndexEmployeeeComponent', () => {
  let component: IndexEmployeeeComponent;
  let fixture: ComponentFixture<IndexEmployeeeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ IndexEmployeeeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(IndexEmployeeeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
