import { Component } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-games',
  templateUrl: './games.component.html',
  styleUrls: ['./games.component.scss']
})
export class GamesComponent {

public gamesList: any;
private apiURL = 'https://localhost:63890/api/Game';
private errorMessage: any;


  constructor(private http: HttpClient) {
    this.getGames();
  }

  getGames(){
    this.http.get<any>(`${ this.apiURL }/Get`).subscribe({
        next: data => {
          this.gamesList = data;
        },
        error: error => {
            this.errorMessage = error.message;
            console.error('There was an error!', error);
        }
    })
  }
}
