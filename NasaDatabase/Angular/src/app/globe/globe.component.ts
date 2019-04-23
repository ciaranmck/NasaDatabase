import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { trigger, transition, animate, style } from '@angular/animations';

import { NasaDatabaseService } from '../shared/api/nasa-database.service';

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
        animate('200ms ease-in', style({ transform: 'translateX(50%)' }))
      ])
    ])
  ]
})

export class GlobeComponent implements OnInit {
  fireballData: Fireball[] = [];
  visible = false;

  constructor(
    private nasaDatabaseService: NasaDatabaseService,
    private cdr: ChangeDetectorRef
  ) {}

  ngOnInit() {
    this.getAllFireballData();
  }

  public getAllFireballData(): void {
    this.nasaDatabaseService.getAllFireballs().subscribe(fireBallData => {
      this.fireballData = fireBallData;
      console.log('fireballData: ', this.fireballData);
    });
  }

  public changeGlobeVisibility(): void {
    this.visible = !this.visible;
  }

}
