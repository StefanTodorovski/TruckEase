import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { SidebarShipperComponent } from './sidebar-shipper.component';


describe('SidebarComponent', () => {
  let component: SidebarShipperComponent;
  let fixture: ComponentFixture<SidebarShipperComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SidebarShipperComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SidebarShipperComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
