import {Component, OnInit} from '@angular/core';
import {PersonService} from '../services/person.service';
import {GiftService} from '../services/gift.service';
import {FormsModule} from '@angular/forms';

@Component({
  selector: 'app-give-gift',
  standalone: true,
  imports: [
    FormsModule
  ],
  templateUrl: './give-gift.component.html',
  styleUrl: './give-gift.component.css'
})
export class GiveGiftComponent implements OnInit {
  people: any[] = [];
  gifts: any[] = [];
  selectedPersonId: number = 0;
  selectedGiftId: number = 0;
  successMessage: string = '';
  errorMessage: string = '';

  constructor(private personService: PersonService, private giftService: GiftService) {
  }

  ngOnInit(): void {
    this.personService.getPeople().subscribe({
      next: (data) => this.people = data,
      error: (error) => {
        this.errorMessage = 'Error fetching people list';
        console.error('Error fetching people', error);
      }
    });

    this.giftService.getGifts().subscribe({
      next: (data) => this.gifts = data,
      error: (error) => {
        this.errorMessage = 'Error fetching gifts list';
        console.error('Error fetching gifts', error);
      }
    });
  }

  giveGift(): void {
    if (this.selectedPersonId === 0 || this.selectedGiftId === 0) {
      this.errorMessage = 'Please select both a person and a gift.';
      return;
    }

    this.personService.giveGift(this.selectedPersonId, this.selectedGiftId).subscribe({
      next: (response) => {
        this.successMessage = response;
        this.errorMessage = '';
      },
      error: (error) => {
        this.errorMessage = 'Error giving the gift';
        console.error('Error giving gift', error);
      }
    });
  }
}
