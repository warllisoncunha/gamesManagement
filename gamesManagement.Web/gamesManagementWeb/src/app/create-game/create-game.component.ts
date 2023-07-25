import { Component } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { FormBuilder } from "@angular/forms";


@Component({
  selector: 'app-create-game',
  templateUrl: './create-game.component.html',
  styleUrls: ['./create-game.component.scss']
})
export class CreateGameComponent {
  public form: any;
  private formBuilder: FormBuilder;
  urlBase = '';

  constructor(privateformBuilder:FormBuilder, private http: HttpClient) {
    this.formBuilder = privateformBuilder
    this.createForm();
  }

  createForm(){
    this.form = this.formBuilder.group({
      name: [''],
      description: ['']
    });
}
}
