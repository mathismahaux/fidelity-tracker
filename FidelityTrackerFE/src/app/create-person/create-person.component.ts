import {Component, OnInit} from '@angular/core';
import {PersonService} from '../services/person.service';
import {FormsModule} from '@angular/forms';

@Component({
  selector: 'app-create-person',
  standalone: true,
  imports: [
    FormsModule
  ],
  templateUrl: './create-person.component.html',
  styleUrl: './create-person.component.css'
})
export class CreatePersonComponent implements OnInit {
  name: string = '';
  idSponsor: number | null = null;
  successMessage: string = '';
  errorMessage: string = '';

  constructor(private personService: PersonService) {}

  ngOnInit(): void {}

  createPerson(): void {
    if (!this.name) {
      this.errorMessage = 'Name is required';
      return;
    }

    this.personService.createPerson(this.name, this.idSponsor).subscribe({
      next: (response) => {
        this.successMessage = `Person created: ${response.name}`;
        this.errorMessage = '';
      },
      error: (error) => {
        this.errorMessage = 'Error creating person';
        console.error('Error creating person', error);
      }
    });
  }
}
