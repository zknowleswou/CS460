import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DesignHomeComponent } from './components/design-home/design-home.component';
import { DesignWorkoutComponent } from './design-workout.component';
import { BuilderComponent } from './components/builder/builder.component';


const designRoutes: Routes = [
  {
    path: 'design', component: DesignWorkoutComponent,
    children: [
      {
        path: "",
        component: DesignHomeComponent
      },
      {
        path:":workoutId",
        component: BuilderComponent
      }
    ]
  }
];

@NgModule({
  imports: [
    RouterModule.forChild(designRoutes)
  ],
  exports: [
    RouterModule
  ],
  declarations: []
})
export class DesignWorkoutRoutingModule { }
