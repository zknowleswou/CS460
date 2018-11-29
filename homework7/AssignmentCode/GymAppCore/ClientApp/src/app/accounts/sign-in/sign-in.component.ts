import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../../_services/authentication.service';
import { Router } from '@angular/router';
import { first } from 'rxjs/operators';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AuthenticationError } from '../../classes/AuthenticationError';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html'
})
export class SignInComponent {
  public errors: AuthenticationError[];
  public submitted: boolean = false;


  constructor(private auth: AuthenticationService, private router: Router) { }

  signInForm = new FormGroup({
    'email': new FormControl('', [Validators.required]),
    'password': new FormControl('', [Validators.required])
  });


  public onSubmit() {
    this.submitted = true;
    this.auth.signIn(this.signInForm.value.email, this.signInForm.value.password)
      .pipe(first())
      .subscribe(
        result => {
          if (result.succeeded) {
            this.router.navigate(['track']);
          } else {
            this.submitted = false;
            this.errors = result.errors;
          }
        }
      );
  }
}