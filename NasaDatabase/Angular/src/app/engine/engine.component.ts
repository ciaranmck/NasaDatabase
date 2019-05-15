import { Component, OnInit } from '@angular/core';

import { EngineService } from './engine.service';
import { NasaDatabaseService } from '../shared/api/nasa-database.service';

import Fireball from '../shared/models/Fireball';

@Component({
  selector: 'app-engine',
  templateUrl: './engine.component.html',
  styleUrls: [],
})
export class EngineComponent implements OnInit {
  private canEleId = 'renderCanvas';
  private fireballData: Fireball[] = [];

  constructor(
    private engServ: EngineService,
    private nasaDatabaseService: NasaDatabaseService,
  ) { }

  ngOnInit() {
    this.engServ.createScene(this.canEleId);
    this.engServ.animate();
    this.getAllFireballData();
  }

  public getAllFireballData(): void {
    this.nasaDatabaseService.getAllFireballs().subscribe(fireBallData => {
      this.fireballData = fireBallData;
      this.getXYZCoordinates(this.fireballData);
    });
  }

  public getXYZCoordinates(fireballData): void {
    this.engServ.getXYZCoordinates(fireballData);
  }

}
