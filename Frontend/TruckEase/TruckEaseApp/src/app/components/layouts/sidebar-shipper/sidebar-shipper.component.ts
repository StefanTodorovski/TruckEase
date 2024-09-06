import { Component } from '@angular/core';
import { Router } from '@angular/router';

declare const $: any;

@Component({
  selector: 'app-sidebar-shipper',
  templateUrl: './sidebar-shipper.component.html',
  styleUrls: ['./sidebar-shipper.component.scss']
})
export class SidebarShipperComponent {
  menuItems: any[] | undefined;

  constructor(private router: Router) { }
  isMobileMenu() {
      if ($(window).width() > 991) {
          return false;
      }
      return true;
  };

  logout(): void {
    localStorage.removeItem('jwtToken'); 
    sessionStorage.removeItem('jwtToken');
    this.router.navigate(['/login']);
  }
}
