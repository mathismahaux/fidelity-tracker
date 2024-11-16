import {Component, OnInit} from '@angular/core';
import {PersonService} from '../services/person.service';
import {GiftService} from '../services/gift.service';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';

@Component({
  selector: 'app-create-gift',
  standalone: true,
  imports: [
    FormsModule,
    ReactiveFormsModule
  ],
  templateUrl: './create-gift.component.html',
  styleUrl: './create-gift.component.css'
})
export class CreateGiftComponent implements OnInit {
  name: string = '';
  successMessage: string = '';
  errorMessage: string = '';

  constructor(private giftService: GiftService) {}

  ngOnInit(): void {}

  createGift(): void {
    if (!this.name) {
      this.errorMessage = 'Name is required';
      return;
    }

    this.giftService.createGift(this.name).subscribe({
      next: (response) => {
        this.successMessage = `Gift created: ${response.name}`;
        this.errorMessage = '';
      },
      error: (error) => {
        this.errorMessage = 'Error creating gift';
        console.error('Error creating gift', error);
      }
    });
  }
}
