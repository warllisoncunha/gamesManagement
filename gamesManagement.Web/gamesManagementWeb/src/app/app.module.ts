import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { HttpClientModule } from '@angular/common/http';
import { Interceptor } from './app.interceptor.module';
import { HomeComponent } from './home/home.component';
import { GamesComponent } from './games/games.component';
import { FriendsComponent } from './friends/friends.component';
import { BorrowedGameComponent } from './borrowed-game/borrowed-game.component';
import { RouterModule, Routes } from "@angular/router";


export  const routes: Routes = 
[
  { path: "login", component: LoginComponent },
  {path: 'home',component: HomeComponent},
  {path: 'games',component: GamesComponent},
  {path: 'friends',component: FriendsComponent},
  {path: 'borrowedGame',component: BorrowedGameComponent}
];
  

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    HomeComponent,
    GamesComponent,
    FriendsComponent,
    BorrowedGameComponent
  ],
  imports: [
    RouterModule.forRoot(routes),
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    Interceptor
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
