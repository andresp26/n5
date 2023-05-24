import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Permission } from '../models/permission';

@Injectable({
  providedIn: 'root',
})
export class ServiceService {
  private url = 'https://localhost:7108/api/';

  constructor(private http: HttpClient) {}

  getPermissions() {
    return this.http.get(`${this.url}Permission`);
  }

  getPermissionsTypes() {
    return this.http.get(`${this.url}PermissionType`);
  }

  createPermission(permission: Permission) {
    return this.http.post(`${this.url}Permission`, permission);
  }

  deletePermission(id: number) {
    return this.http.delete(`${this.url}Permission/${id}`);
  }

  updatePermission(permission: Permission) {
    return this.http.put(`${this.url}Permission/${permission.id}`, permission);
  }
}
