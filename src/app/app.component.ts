import { Component } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import {Validators } from '@angular/forms'
import { SurveyService } from './survey.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  surveyForm: FormGroup;
  question2Values: string[] = [];
  question5Values: string[] = []; 
  surveyResults: any;
  showResults = false;

  constructor(private formBuilder: FormBuilder, private surveyService: SurveyService){
    this.surveyForm = formBuilder.group({
      'question1': ['', Validators.required],
      'question2': ['', Validators.required],
      'question3': ['', Validators.required],
      'question4': ['', Validators.required],
      'question5': ['', Validators.required]
    })
  }

  onSubmit(){
    console.log(this.surveyForm.invalid);
    console.log(this.surveyForm.value);
    
    if(this.surveyForm.invalid){
      window.alert('Please ensure all answers have been selected')
    }
    
    let response = {
        question1Answer: this.surveyForm.value.question1,
        question2Answer: this.question2Values,
        question3Answer: this.surveyForm.value.question3,
        question4Answer: this.surveyForm.value.question4,
        question5Answer: this.question5Values
    }
    this.surveyService.submitResponse(response).subscribe(res => {
      if(res.success){
        this.surveyService.getResults().subscribe(surveyRes => {
          this.surveyResults = surveyRes;
          this.showResults = true;
        })
      }
      else{
        window.alert('Submit Failed. Please try again or reload page')
      }
    });
  }

  question2ValueChange(value: string){
    let index = this.question2Values.indexOf(value); 
    if(index === -1){
      this.question2Values.push(value)
    }
    else{
      this.question2Values.splice(index, 1)
    }    
  }

  question5ValueChange(value: string){
    let index = this.question5Values.indexOf(value); 
    if(index === -1){
      this.question5Values.push(value)
    }
    else{
      this.question5Values.splice(index, 1)
    }    
  }
  resetForm(){
    this.showResults = false;
    this.surveyForm.reset();
  }
}
