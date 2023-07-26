import { AfterViewInit, Component, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Pet } from 'src/app/interface/pet';
import { PetService } from 'src/app/services/pet.service';


@Component({
  selector: 'app-pet-list',
  templateUrl: './pet-list.component.html',
  styleUrls: ['./pet-list.component.css']
})


export class PetListComponent implements AfterViewInit{

  constructor ( private _snackBar: MatSnackBar,
                private _petService:  PetService 
  ){}

  displayedColumns: string[] = ['name', 'age', 'breed', 'color', 'weight', 'actions'];
  dataSource = new MatTableDataSource<Pet>();
  loading: boolean = false;
  
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  ngOnInit(): void {
    this.getPets();
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
    if(this.dataSource.data.length > 0){
      this.paginator._intl.itemsPerPageLabel = 'Pets per page';
    }
    
    
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  getPets(){
    this.loading = true;
    this._petService.getListPets().subscribe(data => {
      this.dataSource.data = data;
      this.loading = false;
      
    }, error => {
      this.loading = false;
      this._snackBar.open('Error to get data, please try again later', '', {
        duration: 2500,
        horizontalPosition: 'right',
      });
    })
  }

  deletePet(id: number){
    this.loading = true;
    this._petService.deletePet(id).subscribe(() => {
      this.successMessage();
      this.loading = false;
      this.getPets();
  });
  }

  successMessage(){
    this._snackBar.open('Pet Data Was Delete Succesfully!', '', {
      duration: 2500,
      horizontalPosition: 'right',
    });
  }
}