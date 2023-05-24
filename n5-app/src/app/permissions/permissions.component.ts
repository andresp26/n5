import { Component } from '@angular/core';
import { ServiceService } from '../api/service.service';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Permission } from '../models/permission';
import Swal from 'sweetalert2';
import { PermissionType } from '../models/permissionType';
import { DatePipe } from '@angular/common';
import { MatDialog } from '@angular/material/dialog';
import { AddPermissionComponent } from '../add-permission/add-permission.component';

@Component({
  selector: 'app-permissions',
  templateUrl: './permissions.component.html',
  styleUrls: ['./permissions.component.scss'],
})
export class PermissionsComponent {
  permissions!: Permission[];
  permissionsTypes!: PermissionType[];
  contactForm: any;
  displayedColumns: string[] = [
    'id',
    'nombreEmpleado',
    'apellidoEmpleado',
    'tipoPermiso',
    'fechaPermiso',
    'acciones',
  ];
  panelOpenState = false;
  constructor(private httpService: ServiceService, public dialog: MatDialog) {}

  openDialog(row: Permission): void {
    const dialogRef = this.dialog.open(AddPermissionComponent, {
      data: row,
    });
    dialogRef.afterClosed().subscribe((result) => {
      console.log('The dialog was closed');
    });
  }

  ngOnInit() {
    this.contactForm = new FormGroup({
      nombreEmpleado: new FormControl('', Validators.required),
      apellidoEmpleado: new FormControl('', Validators.required),
      type: new FormControl('', Validators.required),
    });
    this.loadPermissions();
    this.httpService.getPermissionsTypes().subscribe((types: any) => {
      this.permissionsTypes = types;
      console.log(this.permissionsTypes);
    });
  }

  ngOnchanges() {
    debugger;
    this.loadPermissions();
  }
  loadPermissions() {
    this.httpService.getPermissions().subscribe((x: any) => {
      this.permissions = x;
      console.log(this.permissions);
    });
  }

  deletePermission(id: number) {
    Swal.fire({
      title: 'Esta seguro de eliminar este permiso?',

      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Si',
      cancelButtonText: 'No',
      // deepcode ignore PromiseNotCaughtGeneral: <please specify a reason of ignoring this>
    }).then((result) => {
      if (result.isConfirmed) {
        //  deepcode ignore PromiseNotCaughtGeneral: <please specify a reason of ignoring this>
        this.httpService.deletePermission(id).subscribe((data) => {
          debugger;
          if (data) {
            console.log(data);
            Swal.fire('Elminado!', 'Permiso eliminado.', 'success');
            this.loadPermissions();
          }
        });
      }
    });
  }

  editPermission(row: Permission) {
    console.log(row);
    this.openDialog(row);
  }

  getValueTypePermission(id: number) {
    if (this.permissionsTypes) {
      return this.permissionsTypes.find((x) => x.id == id)?.descripcion;
    }
    return '';
  }

  createdPermissionChild() {
    this.loadPermissions();
    this.panelOpenState = false;
  }
}
