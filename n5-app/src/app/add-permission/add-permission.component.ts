import { Component, EventEmitter, Inject, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ServiceService } from '../api/service.service';
import { Permission } from '../models/permission';
import Swal from 'sweetalert2';
import { PermissionType } from '../models/permissionType';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-add-permission',
  templateUrl: './add-permission.component.html',
  styleUrls: ['./add-permission.component.scss'],
})
export class AddPermissionComponent {
  contactForm: any;
  permissionsTypes!: PermissionType[];
  @Output() newItemEvent = new EventEmitter<string>();
  constructor(
    private httpService: ServiceService,
    @Inject(MAT_DIALOG_DATA) public data: Permission
  ) {
    this.contactForm = new FormGroup({
      nombreEmpleado: new FormControl('', Validators.required),
      apellidoEmpleado: new FormControl('', Validators.required),
      type: new FormControl('', Validators.required),
    });
    this.httpService.getPermissionsTypes().subscribe((types: any) => {
      this.permissionsTypes = types;
      console.log(this.permissionsTypes);
    });

    if (this.data) {
      this.contactForm.controls.nombreEmpleado.value = this.data.nombreEmpleado;
      this.contactForm.controls.apellidoEmpleado.value =
        this.data.apellidoEmpleado;
      this.contactForm.controls.type.value = this.data.tipoPermiso;
    }
  }

  submitForm() {
    debugger;
    try {
      if (this.data.id != undefined) {
        const permission: Permission = {
          id: this.data.id,
          nombreEmpleado: this.contactForm.get('nombreEmpleado').value,
          apellidoEmpleado: this.contactForm.get('apellidoEmpleado').value,
          tipoPermiso: this.contactForm.get('type').value,
          fechaPermiso: new Date().toISOString(),
        };
        console.log('permiso a enviar==>', permission);
        this.httpService.updatePermission(permission).subscribe((data: any) => {
          debugger;
          if (data) {
            console.log(data);
            Swal.fire({
              position: 'center',
              icon: 'success',
              title: 'Permiso actualizado satisfactoriamente',
              showConfirmButton: false,
              timer: 2000,
            });
          }
        });
      } else {
        const permission: Permission = {
          id: 0,
          nombreEmpleado: this.contactForm.get('nombreEmpleado').value,
          apellidoEmpleado: this.contactForm.get('apellidoEmpleado').value,
          tipoPermiso: this.contactForm.get('type').value,
          fechaPermiso: new Date().toISOString(),
        };
        console.log('permiso a enviar==>', permission);
        this.httpService.createPermission(permission).subscribe((data: any) => {
          debugger;
          if (data) {
            console.log(data);
            Swal.fire({
              position: 'center',
              icon: 'success',
              title: 'Permiso agregado',
              showConfirmButton: false,
              timer: 2000,
            });
            this.contactForm.reset();
          }
          this.newItemEvent.emit('creado');
        });
      }
    } catch (error) {
      Swal.fire({
        position: 'center',
        icon: 'error',
        title: `Error: ${error}`,
        showConfirmButton: false,
        timer: 2000,
      });
    }
  }
}
