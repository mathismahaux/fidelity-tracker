import { Routes } from '@angular/router';
import {SearchPersonComponent} from './search-person/search-person.component';
import {CreatePersonComponent} from './create-person/create-person.component';
import {CreateGiftComponent} from './create-gift/create-gift.component';
import {AssignSponsorComponent} from './assign-sponsor/assign-sponsor.component';

export const routes: Routes = [
  {path: 'search-person', component: SearchPersonComponent},
  {path: 'create-person', component: CreatePersonComponent},
  {path: 'create-gift', component: CreateGiftComponent},
  {path: 'assign-sponsor', component: AssignSponsorComponent}

];
