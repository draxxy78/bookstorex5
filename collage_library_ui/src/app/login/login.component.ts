import { Component, OnInit } from '@angular/core';
import {HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  userId:string;
  password:string;
  host:string;

  constructor(private http: HttpClient,private router: Router) { }

  ngOnInit() {
  }

  public login(){
    this.userLogin();
  }

  public userLogin() {
    this.http.get<any>("./assets/config.json").subscribe(x=>{
      this.host = x.UserHost;
      var data = {userid: this.userId,password: this.password}
    var url = this.host+"user/login";
    this.http.post<any>(url,
      data,{
        headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    }).subscribe(response=>{
      if(response.loginStatus){
        localStorage.removeItem('CurrentUser');
        localStorage.setItem('CurrentUser',JSON.stringify(response));
        this.router.navigate(['mybooks']);
      }
      else{
        alert('Wrong credentials!')
      }
    })
    });  
}

}
