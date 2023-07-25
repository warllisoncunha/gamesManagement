import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent {
  private router : Router;

  constructor(router: Router) {
    this.router = router;
  }

  redirectLogin(){
    this.router.navigate(['/login']);
  }

  redirectGames(){
    this.router.navigate(['/games']);
  }

  redirectFriends(){
    this.router.navigate(['/friends']);
  }

  redirectBorrowedGame(){
    this.router.navigate(['/borrowedGame']);
  }

}
