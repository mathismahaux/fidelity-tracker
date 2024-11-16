import {Component, OnInit} from '@angular/core';
import {PersonService} from '../services/person.service';
import {FormsModule} from '@angular/forms';
import {GiftService} from '../services/gift.service';
import {GiveGiftComponent} from '../give-gift/give-gift.component';

@Component({
  selector: 'app-search-person',
  standalone: true,
  imports: [
    FormsModule,
    GiveGiftComponent
  ],
  templateUrl: './search-person.component.html',
  styleUrl: './search-person.component.css'
})
export class SearchPersonComponent implements OnInit {
  gifts: any[] = [];
  searchedName: string = '';
  results: any = [];
  errorMessage: string = '';
  selectedDetails: any = null;
  selectedGiftId: number | null = null;
  giftMessage: string = '';

  constructor(private personService: PersonService, private giftService: GiftService) {}

  ngOnInit(): void {
    this.giftService.getGifts().subscribe({
      next: (data) => {
        this.gifts = data;
      },
      error: (error) => {
        console.error('Error fetching gifts', error);
      },
    });
  }

  search(): void {
    if (this.searchedName.trim() === '') {
      this.errorMessage = 'Please enter a name.';
      this.results = [];
      return;
    }

    this.personService.searchByName(this.searchedName).subscribe({
      next: (data) => {
        this.results = data;
        this.errorMessage = '';
      },
      error: (error) => {
        this.errorMessage = "No results found.";
      }
    })
  }

  showDetails(id: number): void {
    this.personService.getDetailsById(id).subscribe({
      next: (details) => {
        this.selectedDetails = details;
        this.errorMessage = '';
      },
      error: (error) => {
        this.errorMessage = 'Error fetching details';
        console.error('Error fetching details', error);
      },
    });
  }
}
