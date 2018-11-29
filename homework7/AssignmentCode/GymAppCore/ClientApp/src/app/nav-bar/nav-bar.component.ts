import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../_services/authentication.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit {

  isNavbarCollapsed = true;

  constructor(private authService: AuthenticationService,
    private router: Router) { }

  ngOnInit() {
  }

  onLinkClicked(): void {
    this.isNavbarCollapsed = true;
  }

  isUserSignedIn(): boolean {
    return this.authService.signedIn;
  }

  signOut(): void {
    this.authService.signOut();
    this.isNavbarCollapsed = true;
    this.router.navigate(['']);
  }

}
