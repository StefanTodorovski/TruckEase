import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { AdminLayoutShipperComponent } from './admin-layout-shipper.component';


describe('AdminLayoutComponent', () => {
  let component: AdminLayoutShipperComponent;
  let fixture: ComponentFixture<AdminLayoutShipperComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdminLayoutShipperComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminLayoutShipperComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
