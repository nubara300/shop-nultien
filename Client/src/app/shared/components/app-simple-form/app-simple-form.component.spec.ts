import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AppSimpleFormComponent } from './app-simple-form.component';

describe('AppSimpleFormComponent', () => {
  let component: AppSimpleFormComponent;
  let fixture: ComponentFixture<AppSimpleFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AppSimpleFormComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AppSimpleFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
