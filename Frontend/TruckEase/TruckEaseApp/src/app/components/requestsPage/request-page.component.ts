import { Component, OnInit } from '@angular/core';
import { RequestInfoViewModel } from '../../models/view-models/request-info.view-model';
import { TransportRequestApiService } from '../../services/transportRequest/transport-request-api.service';
import { switchMap } from 'rxjs';
import { CurrentUserViewModel } from '../../models/view-models/current-user.view-model';
import { MatDialog } from '@angular/material/dialog';
import { ErrorDialogComponent } from '../../services/dialogues/error-dialog.component';
import { CurrentUserApiService } from '../../services/auth-service/current-user-api.service';
import { Router } from '@angular/router';
import { EditRequestDialogComponent } from '../../services/dialogues/edit-transport-request-dialogue/edit-transport-request-dialog.component';

@Component({
  selector: 'app-request-page',
  templateUrl: './request-page.component.html',
  styleUrls: ['./request-page.component.scss']
})
export class RequestPageComponent implements OnInit {

  public requests: RequestInfoViewModel[] = [];
  public filteredRequests: RequestInfoViewModel[] = [];
  public toggledIndexes: Set<number> = new Set();
  public currentUser: CurrentUserViewModel = new CurrentUserViewModel();

  constructor(
    private transportRequestApiService: TransportRequestApiService,
    private currentUserService: CurrentUserApiService,
    private dialog: MatDialog,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.fetchRequests();
  }

  fetchRequests(): void {
    this.currentUserService.getCurrentUser()
    .pipe(
      switchMap(user => {
        this.currentUser = user;
        return this.transportRequestApiService.getAllRequestsForCompany(user.inCompanyFK);
      })
    )
    .subscribe({
      next: (result) => {
        this.requests = result;
        this.filteredRequests = result;
      },
      error: (error: { error: any; }) => {
        this.dialog.open(ErrorDialogComponent, {
          data: { message: 'Error fetching request, please contact support.' },
        });
      }
    });
  }

  toggleDetails(index: number): void {
    if (this.toggledIndexes.has(index)) {
      this.toggledIndexes.delete(index);
    } else {
      this.toggledIndexes.add(index);
    }
  }

  onEdit(request: RequestInfoViewModel): void {
    const dialogRef = this.dialog.open(EditRequestDialogComponent, {
      width: '400px',
      data: {
        ...request,
        transportId: request.id
      }
    });
  
    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.fetchRequests();
      }
    });
  }

  navigateToCreateRequest(): void {
    this.router.navigate(['admin-shipper/create-request']);
  }

  filterRequests(filterValue: string): void {
    if (filterValue === 'all') {
      this.filteredRequests = this.requests;
    } else if (filterValue === 'draft') {
      this.filteredRequests = this.requests.filter(request => request.isDraft);
    } else if (filterValue === 'published') {
      this.filteredRequests = this.requests.filter(request => !request.isDraft);
    }
  }
}
