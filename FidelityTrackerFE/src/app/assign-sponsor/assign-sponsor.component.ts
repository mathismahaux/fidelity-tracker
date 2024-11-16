import {Component, OnInit} from '@angular/core';
import {PersonService} from '../services/person.service';
import {FormsModule} from '@angular/forms';

@Component({
  selector: 'app-assign-sponsor',
  standalone: true,
  imports: [
    FormsModule
  ],
  templateUrl: './assign-sponsor.component.html',
  styleUrl: './assign-sponsor.component.css'
})
export class AssignSponsorComponent implements OnInit {
  people: any[] = [];
  sponsors: any[] = [];
  selectedPersonId: number | null = null;
  selectedSponsorId: number | null = null;
  successMessage: string = '';
  errorMessage: string = '';

  constructor(private personService: PersonService) {}

  ngOnInit(): void {
    this.fetchPeople();
  }

  fetchPeople(): void {
    this.personService.getPeople().subscribe({
      next: (response) => {
        this.people = response;
        this.sponsors = response;
      },
      error: (error) => {
        console.error('Error fetching people', error);
      }
    });
  }

  assignSponsor(): void {
    if (this.selectedPersonId === null || this.selectedSponsorId === null) {
      this.errorMessage = 'Please select both a person and a sponsor.';
      return;
    }

    this.personService.assignSponsor(this.selectedPersonId, this.selectedSponsorId).subscribe({
      next: (response) => {
        this.successMessage = 'Sponsor successfully assigned.';
        this.errorMessage = '';
      },
      error: (error) => {
        this.errorMessage = 'Error assigning sponsor.';
        console.error('Error assigning sponsor', error);
      }
    });
  }
}
