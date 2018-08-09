import { Component, OnInit } from '@angular/core';
import { ValueService } from './value.service';
import { Value } from './value-model';

@Component({
  selector: 'app-value',
  templateUrl: './value.component.html',
  styleUrls: ['./value.component.css']
})
export class ValueComponent implements OnInit {

  values: Value[];
  constructor(private valueService: ValueService) { }

  ngOnInit() {
   this.valueService.getValues().subscribe(response => this.values = response,
  error => console.log(error));
  }

}
