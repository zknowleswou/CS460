import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { JwtModule, JwtInterceptor } from '@auth0/angular-jwt';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './/app-routing.module';

import { SignInComponent } from './accounts/sign-in/sign-in.component';

import { AuthenticationService } from './_services/authentication.service';
import { AuthGuard } from './auth.guard';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RegisterComponent } from './accounts/register/register.component';
import { LandingPageComponent } from './landing-page/landing-page.component';
import { SessionSummaryComponent } from './info/session-summary/session-summary.component';
import { TermsOfServiceComponent } from './terms-of-service/terms-of-service.component';

import { DesignWorkoutModule } from './design-workout/design-workout.module';
import { TrackWorkoutModule } from './track-workout/track-workout.module';
import { AuthInterceptor } from './accounts/auth.interceptor';
import { SessionHistoryModule } from './session-history/session-history.module';
import { NavBarModule } from './nav-bar/nav-bar.module';


export function tokenGetter() {
  return localStorage.getItem('access_token');
}

@NgModule({
  declarations: [
    AppComponent,
    SignInComponent,
    RegisterComponent,
    LandingPageComponent,
    SignInComponent,
    SessionSummaryComponent,
    TermsOfServiceComponent
  ],
  exports: [
  ],
  imports: [
    BrowserModule,
    SessionHistoryModule,
    DesignWorkoutModule,
    TrackWorkoutModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    NavBarModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        whitelistedDomains: ['https://localhost:44346/'],
        blacklistedRoutes: ['https://localhost:44346/api/authentication/login']
      }
    })
  ],
  providers: [
    AuthenticationService,
    AuthGuard,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: JwtInterceptor,
      multi: true
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
