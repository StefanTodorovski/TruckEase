import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { SidebarTransporterComponent } from './sidebar-transporter.component';


describe('SidebarComponent', () => {
  let component: SidebarTransporterComponent;
  let fixture: ComponentFixture<SidebarTransporterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SidebarTransporterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SidebarTransporterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
