import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ApiService } from '../service/api.service';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';


@Component({
  selector: 'app-add-edit-shipper',
  templateUrl: './add-edit-shipper.component.html',
  styleUrls: ['./add-edit-shipper.component.css']
})
export class AddEditShipperComponent implements OnInit{
  shipperForm: FormGroup;

  constructor(
    private fBuilder: FormBuilder, 
    private apiService: ApiService,
    private dialogRef: MatDialogRef<AddEditShipperComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any){

    this.shipperForm = this.fBuilder.group({
      CompanyName:[' ', [Validators.required, this.maxLenghtCompanyName]],
      Phone: [' ', [Validators.required, this.maxLenghtPhone]],
    });
  }

  ngOnInit(): void {
    this.shipperForm.patchValue(this.data);
  }

  onFormSubmit(){
    if(this.shipperForm.valid){
      if(this.data){
        this.apiService.updateShipper(this.data.Id, this.shipperForm.value).subscribe({
          next: (val: any) => {
            alert('Shipper updated');
            this.dialogRef.close(true);
          },
          error: (err: any) => {
            alert('Something gone wrong');
            console.error(err);
          }
        })
      }else{
        this.apiService.addShipper(this.shipperForm.value).subscribe({
          next: (val: any) => {
            alert('Shipper added successfully');
            this.dialogRef.close(true);
          },
          error: (err: any) => {
            alert('Something gone wrong');
            console.error(err);
          }
        })
      }
      
    }
  }

  maxLenghtCompanyName(control: FormControl){
    const value = control.value as string;
    if (value && value.length > 40) {
      return { maxLengthExceeded: true };
    }
    return null;
  }

  maxLenghtPhone(control: FormControl){
    const value = control.value as string;
    if (value && value.length > 25) {
      return { maxLengthExceeded: true };
    }
    return null;
  }
}
