import { Component, OnInit, Input } from '@angular/core';

let nextId = 0;

@Component({
  selector: 'lib-label',
  templateUrl: './label.component.html',
  styleUrls: ['./label.component.scss']
})
export class LabelComponent implements OnInit {

  @Input() id = `label-${++nextId}`;
  constructor() { }

  ngOnInit() {
  }

}
