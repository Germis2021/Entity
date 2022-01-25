import { Injectable } from '@angular/core';
import { Router } from '@angular/router';


@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor (private router : Router) { 
    let browserToken = localStorage.getItem('token')
    if(browserToken != null){
      this.loggedIn = true;
      this.token = browserToken;
    }
  }

  loggedIn = false;
  token = ''

  atsijungti(){
    this.loggedIn = false;
    localStorage.removeItem('token');
    this.router.navigate(["login"]);
  }

  async prisijungti(data: any) {

    data.Id = 0
    data.Pastas = ""


    let atsakymasIsServerio = await fetch(' https://localhost:44369/login', {
      method: 'POST',
      headers: {
        'Accept': 'application/json, text/plain, */*',

        'Content-Type': 'application/json'

      },

      body: JSON.stringify(data)

    })


    let tokenas = await atsakymasIsServerio?.json()

    if (atsakymasIsServerio.status == 401) {

      alert("netinkamas slaptazodis")
    }

    if (tokenas != null && atsakymasIsServerio.status == 200) {
      console.log(tokenas)
      this.loggedIn = true;
      

      this.token =tokenas.token;
      localStorage.setItem('token', this.token)

      this.router.navigate(['main'])
      
    }

  }
  async registruotis(data: any) {

    data.Id = 0
    

    let atsakymasIsServerio = await fetch(' https://localhost:44369/register', {
      method: 'POST',
      headers: {
        'Accept': 'application/json, text/plain, */*',
        'Content-Type': 'application/json'
      },

      body: JSON.stringify(data)

    })


    let tokenas = await atsakymasIsServerio?.json()

    if (atsakymasIsServerio.status == 401) {

      alert("toks vartotojas jau egzistuoja")
    }

    if (tokenas != null && atsakymasIsServerio.status == 200) {
      console.log(tokenas)
      this.loggedIn = true;

      this.token = tokenas.token;
      localStorage.setItem('token', this.token)

      this.router.navigate(['main'])
      
    }




  }


}


