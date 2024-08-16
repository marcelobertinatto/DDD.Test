import { Component, OnInit } from '@angular/core';
import { CallMyApiService } from '../Services/callMyApi.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-call-my-api',
  standalone: true,
  templateUrl: './call-my-api.component.html',
  styleUrls: ['./call-my-api.component.css']
})
export class CallMyApiComponent implements OnInit {

  response: any;
  private source$: Observable<number>;

  constructor(private service: CallMyApiService) { }

  ngOnInit() {    
  }

  callmyapi()
  {
    var result = this.service.getInfoFromAPI()
    .subscribe(data => {
      this.response = data;
      console.log(`data: ${this.response}`);
    });
  }

  anotherExample() {
    this.source$ = this.service.anotherExample();
    this.source$.subscribe(val => {
      console.log('Subscriber 1:', val)
    });
    setTimeout(() => this.source$.subscribe(val => {
      console.log('Subscriber 2:', val)
    }), 2000);
  }

}
