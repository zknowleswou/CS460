import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SignInComponent } from './accounts/sign-in/sign-in.component';
import { LandingPageComponent } from './landing-page/landing-page.component';
import { RegisterComponent } from './accounts/register/register.component';
import { TermsOfServiceComponent } from './terms-of-service/terms-of-service.component';

const routes: Routes = [
  {
    path: '',
    component: LandingPageComponent
  },
  {
    path: 'register',
    component: RegisterComponent
  },
  {
    path: 'signin',
    component: SignInComponent
  },
  {
    path: 'terms',
    component: TermsOfServiceComponent
  },{
    path:'design',
    loadChildren: './design-workout/design-workout-routing.module#DesignWorkoutRoutingModule'
  },
  {
    path:'track',
    loadChildren:'./track-workout/track-workout-routing.module#TrackWorkoutRoutingModule'
  },
  {
    path:'history',
    loadChildren:'./session-history/session-history-routing.module#SessionHistoryRoutingModule'
  }
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class AppRoutingModule { }
