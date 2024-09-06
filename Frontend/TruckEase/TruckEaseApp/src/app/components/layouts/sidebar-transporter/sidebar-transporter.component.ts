import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { CompanyUserApiService } from '../../../services/companyUser/company-user-api.service';
import { MatDialog } from '@angular/material/dialog';
import { ErrorDialogComponent } from '../../../services/dialogues/error-dialog.component';

declare const $: any;

@Component({
  selector: 'app-sidebar-transporter',
  templateUrl: './sidebar-transporter.component.html',
  styleUrls: ['./sidebar-transporter.component.scss']
})
export class SidebarTransporterComponent {
  menuItems: any[] | undefined;

  constructor(private router: Router) { }

  isMobileMenu() {
    if ($(window).width() > 991) {
      return false;
    }
    return true;
  }

  logout(): void {
    localStorage.removeItem('jwtToken'); 
    sessionStorage.removeItem('jwtToken');
    this.router.navigate(['/login']);
  }
}
