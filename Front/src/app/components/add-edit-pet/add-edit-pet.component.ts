import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { Pet } from 'src/app/interface/pet';
import { PetService } from 'src/app/services/pet.service';

@Component({
  selector: 'app-add-edit-pet',
  templateUrl: './add-edit-pet.component.html',
  styleUrls: ['./add-edit-pet.component.css']
})
export class AddEditPetComponent {

form: FormGroup  
loading = false;

constructor( private fb: FormBuilder,
             private _petService: PetService,
             private _snackBar: MatSnackBar,
             private router: Router) {

  this.form = this.fb.group({
    name: ['', Validators.required],
    age: ['', Validators.required],
    breed: ['', Validators.required],
    color: ['', Validators.required],
    weight: ['', Validators.required],

 })

}

addPet(){
  const pet: Pet = {
    name: this.form.value.name,
    age: this.form.value.age,
    breed: this.form.value.breed,
    color: this.form.value.color,
    weight: this.form.value.weight, 
    
  }
  this._petService.addPet(pet).subscribe(data => {
    console.log(data);
    this.successMessage();
    this.router.navigate(['/petlist']);
  });
}

successMessage(){
  this._snackBar.open('Pet Data Was Registered Succesfully!', '', {
    duration: 2500,
    horizontalPosition: 'right',
  });
}
}
