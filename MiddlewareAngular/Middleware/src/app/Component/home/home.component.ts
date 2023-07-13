import { Component } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent {
  numbers = [1,3,10,6,4,7,6,9,2,5,8];

  generateNumber() {
    this.numbers.push(20,12,15,13,11,14,19,17,16,18);
  }
}
