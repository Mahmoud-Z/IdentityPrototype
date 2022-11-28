import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-login-side',
  templateUrl: './login-side.component.html',
  styleUrls: ['./login-side.component.css']
})
export class LoginSideComponent implements OnInit{
  trialForm!: FormGroup;
  email : string = "";
  password : string = "";
  constructor(private _fb : FormBuilder){}
  ngOnInit(): void {
    this.trialForm = this._fb.group({
      email : [''],
      password : [''] 
    })
  }
  login():void{
    console.log("dsdsdsd")
    console.log(this.trialForm.value.email);
  }
}
