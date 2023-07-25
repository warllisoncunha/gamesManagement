import { Component } from '@angular/core';
import { FormBuilder } from "@angular/forms";
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
  public form: any;
  private formBuilder: FormBuilder;
  private router : Router;

  urlFireBase = 'https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key=AIzaSyAtPcjbxwmbhKeNNbZnSTCa9MXZloMQKWE';

  
  constructor(privateformBuilder:FormBuilder, private http: HttpClient, router: Router) {
    this.formBuilder = privateformBuilder
    this.router = router;
    this.createForm();
    localStorage.removeItem('token');
  }

  createForm(){
      this.form = this.formBuilder.group({
          email: [''],
          senha: ['']
      });
  }

  login(){
    this.http.post<any>(this.urlFireBase, { returnSecureToken: true, email: this.form?.value.email , password:  this.form?.value.senha}).subscribe(data => {
      if(data.idToken){
        localStorage.setItem('token', data?.idToken)
        this.router.navigate(['/home']);
      }
    })
  };
}
