import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { map, catchError } from 'rxjs/operators';
import { RegisterUser } from '../classes/RegisterUser';
import { RegisterResult } from '../classes/RegisterResult';
import { SignInResult } from '../classes/SignInResult';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable()
export class AuthenticationService {
  constructor(private http: HttpClient) { }

  private authApiUrl = "/api/authentication";


  signIn(username: string, password: string): Observable<SignInResult> {
    return this.http.post<SignInResult>(`${this.authApiUrl}/signin`, { email: username, password: password }, httpOptions)
      .pipe(
        map(result => {
          if (result.succeeded) {
            localStorage.setItem('access_token', result.token.authToken);
          }
          return result;
        })
      );
  }

  register(user: RegisterUser): Observable<RegisterResult> {
    return this.http.post<RegisterResult>(`${this.authApiUrl}/register`, user, httpOptions)
      .pipe(
        map(result => {
          if (result.succeeded) {
            localStorage.setItem('access_token', result.authToken);
          }
          return result;
        })
      );
  }

  signOut() {
    localStorage.removeItem('access_token');
  }

  public get signedIn(): boolean {
    return (localStorage.getItem('access_token') !== null);
  }
}