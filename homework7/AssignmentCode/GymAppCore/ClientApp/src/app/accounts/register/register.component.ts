import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../../_services/authentication.service';
import { Router } from '@angular/router';
import { FormControl, FormGroup, Validators, ValidatorFn, ValidationErrors } from '@angular/forms';
import { RegisterUser } from '../../classes/RegisterUser';
import { AuthenticationError } from '../../classes/AuthenticationError';

const comparePasswords: ValidatorFn = (control: FormGroup): ValidationErrors | null => { // here we have the 'passwords' group
  const password = control.get('password');
  const confirmPassword = control.get('confirmPassword');

  return password && confirmPassword && password.value === confirmPassword.value ? null : { notSame: true }
}

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  registerForm: FormGroup;
  errors: AuthenticationError[];

  constructor(
    private authService: AuthenticationService,
    private router: Router
  ) { }

  ngOnInit() {
    this.registerForm = new FormGroup({
      'email': new FormControl('', [Validators.email, Validators.required]),
      'terms': new FormControl('', [Validators.required]),
      'password': new FormControl('', [Validators.required]),
      'confirmPassword': new FormControl('', [Validators.required])
    }, { validators: comparePasswords });
  }

  submitted = false;

  onSubmit() {
    this.submitted = true;
    let registerUser: RegisterUser = {
      email: this.registerForm.value.email,
      password: this.registerForm.value.password,
      confirmPassword: this.registerForm.value.confirmPassword,
      terms: this.registerForm.value.terms
    };
    this.authService.register(registerUser).subscribe(
      result => {
        if (result.succeeded) {
          this.router.navigate(['track']);
        } else {
          this.errors = result.errors;
          this.submitted = false;
        }
      }
    )
  }

  get f() { return this.registerForm.controls; }
}
