import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { trigger, transition, animate, style } from '@angular/animations';

import Fireball from '../shared/models/Fireball';

@Component({
  selector: 'app-globe',
  templateUrl: './globe.component.html',
  styleUrls: ['./globe.component.css'],
  animations: [
    trigger('slideInOut', [
      transition(':enter', [
        style({ transform: 'translateX(100%)' }),
        animate('2000ms ease-in', style({ transform: 'translateY(0%)' }))
      ]),
      transition(':leave', [
        animate('2000ms ease-in', style({ transform: 'translateX(100%)' }))
      ])
    ])
  ]
})

export class GlobeComponent implements OnInit {
  fireballData: Fireball[] = [];
  visible = true;

  constructor(
    private cdr: ChangeDetectorRef,
  ) {}

  ngOnInit() {
  }

  public changeGlobeVisibility(): void {
    this.visible = !this.visible;
  }

}
