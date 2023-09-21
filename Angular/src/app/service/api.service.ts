import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  private apiUrl = 'https://localhost:44323/api/Shippers/';

  constructor(private client: HttpClient) { }

  getShipper(): Observable<any> {
    return this.client.get<any>(this.apiUrl);
  }

  addShipper(data:any): Observable<any>{
    return this.client.post(this.apiUrl, data);
  }

  updateShipper(id: number, data:any): Observable<any>{
    return this.client.put(this.apiUrl+id, data);
  }

  deleteShipper(id: number): Observable<any>{
    return this.client.delete(this.apiUrl+id);
  }
}
