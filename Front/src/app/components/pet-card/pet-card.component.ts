import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Pet } from 'src/app/interface/pet';
import { PetService } from 'src/app/services/pet.service';

@Component({
  selector: 'app-pet-card',
  templateUrl: './pet-card.component.html',
  styleUrls: ['./pet-card.component.css']
})
export class PetCardComponent {
  id: number;
  pet!: Pet;
  loading: boolean = false;

  constructor (private _petService: PetService,
    private _aRoute: ActivatedRoute ) {
      this.id = Number(this._aRoute.snapshot.paramMap.get('id'));
      console.log(this.id)
    }

  ngOnInit(): void {
    this.getPet();
  }

  getPet(){
    this.loading = true;
    this._petService.getPet(this.id).subscribe(data => {
      this.pet = data;
      this.loading = false;
    },)
  }
}
