import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

//Componentes
import { PetListComponent } from './components/pet-list/pet-list.component';
import { AddEditPetComponent } from './components/add-edit-pet/add-edit-pet.component';
import { PetCardComponent } from './components/pet-card/pet-card.component';

const routes: Routes = [
{ path: '', redirectTo: '/petlist', pathMatch: 'full' },
{ path: 'petlist', component: PetListComponent },
{ path: 'addpet', component: AddEditPetComponent },
{ path: 'petcard/:id', component: PetCardComponent },
{ path: 'editpet/:id', component: AddEditPetComponent },
{ path: '**', redirectTo: '/petlist', pathMatch: 'full' }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
