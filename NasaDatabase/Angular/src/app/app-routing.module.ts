import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { GlobeComponent } from './globe/globe.component';

const routes: Routes = [
  { path: '', component: GlobeComponent }
];

@NgModule({
  imports: [ RouterModule.forRoot(routes) ],
  exports: [ RouterModule ]
})
export class AppRoutingModule {}


