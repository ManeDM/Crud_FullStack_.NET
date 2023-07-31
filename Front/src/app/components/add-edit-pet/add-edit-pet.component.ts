import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
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
id: number;
operation: string = 'Add';

constructor( private fb: FormBuilder,
             private _petService: PetService,
             private _snackBar: MatSnackBar,
             private router: Router,
             private aRoute: ActivatedRoute) {

  this.form = this.fb.group({
    name: ['', Validators.required],
    age: ['', Validators.required],
    breed: ['', Validators.required],
    color: ['', Validators.required],
    weight: ['', Validators.required],

 })
 this.id = Number(this.aRoute.snapshot.paramMap.get('id'))
 }

 ngOnInit(): void{
  if(this.id != 0){
    this.operation = 'Edit'
    this.getDataPet(this.id)
  }
 }

getDataPet(id: number){
  this.loading = true;
  this._petService.getPet(id).subscribe(data => {
    this.form.setValue({
      name: data.name,
      age: data.age,
      breed: data.breed,
      color: data.color,
      weight: data.weight
    })
    this.loading = false;
  })
} 

addeditPet(){
  const pet: Pet = {
    name: this.form.value.name,
    age: this.form.value.age,
    breed: this.form.value.breed,
    color: this.form.value.color,
    weight: this.form.value.weight, 
  }

  if (this.id != 0){
    pet.id = this.id;
    this.editPet(this.id, pet);
  } else {
    this.addPet(pet);
  }
}

addPet(pet: Pet){
  this._petService.addPet(pet).subscribe(data => {
    this.successMessage('added');
    this.router.navigate(['/petlist']);
  });
}

editPet(id: number, pet: Pet){
  this.loading = true;
  this._petService.updatePet(id, pet).subscribe(() =>{
    this.loading = false;
    this.successMessage('edited');
    this.router.navigate(['/petlist']);
  })
}

successMessage(text: string){
  this._snackBar.open(`Pet Data Was ${text} Succesfully!`, '', {
    duration: 2500,
    horizontalPosition: 'right',
  });
}
}
