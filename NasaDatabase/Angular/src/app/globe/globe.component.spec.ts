import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FireballListComponent } from './globe.component';

describe('FireballListComponent', () => {
  let component: FireballListComponent;
  let fixture: ComponentFixture<FireballListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FireballListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FireballListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
