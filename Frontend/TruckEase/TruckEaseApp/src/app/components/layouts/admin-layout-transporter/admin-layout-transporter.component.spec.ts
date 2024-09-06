import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { AdminLayoutTransporterComponent } from './admin-layout-transporter.component';


describe('AdminLayoutComponent', () => {
  let component: AdminLayoutTransporterComponent;
  let fixture: ComponentFixture<AdminLayoutTransporterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdminLayoutTransporterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminLayoutTransporterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
