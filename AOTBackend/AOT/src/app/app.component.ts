import { Component, OnInit } from '@angular/core';
import { pall } from './shared/pall.service';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
 
  title = 'AOT';
  
search()
{
  console.log("search called");
}
 
  }

