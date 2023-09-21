import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { AddEditShipperComponent } from './add-edit-shipper/add-edit-shipper.component';
import { ApiService } from './service/api.service';
import { ConfirmationDialogComponent } from './confirmation-dialog/confirmation-dialog.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'AngularPractica8';

  data: any[] = [];

  constructor(private apiService: ApiService,
     private dialog: MatDialog) { }

  ngOnInit(): void {
    this.getData();

  }

  openAddEditShipperForm() {
    const dialogRef = this.dialog.open(AddEditShipperComponent);
    dialogRef.afterClosed().subscribe({
      next: (val) => {
        if (val){
          this.getData();
        }
      },
    });
  }

  getData() {
    this.apiService.getShipper().subscribe({
      next: (data) =>{
        this.data = data;
      },
      error: console.log
    });
  }

  openDeleteConfirmationDialog(id: number): void {
    const dialogRef = this.dialog.open(ConfirmationDialogComponent, {
      width: '250px',
      data: 'The item will be deleted.\nDo you want to continue?'
    });
  
    dialogRef.afterClosed().subscribe(result => {
      if (result === true) {
        this.deleteShipper(id);
      }
    });
  }

  deleteShipper(id: number){
    this.apiService.deleteShipper(id).subscribe({
      next: (res) => {
        alert('Shipper deleted');
        this.getData();
      },
      error: console.log,
      })
  }

  openEditForm(data: any){
    const dialogRef = this.dialog.open(AddEditShipperComponent, {
      data,
    });
    dialogRef.afterClosed().subscribe({
      next: (val) => {
        if (val){
          this.getData();
        }
      },
    });
  }
}
