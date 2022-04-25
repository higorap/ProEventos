import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-Topo',
  templateUrl: './Topo.component.html',
  styleUrls: ['./Topo.component.scss']
})
export class TopoComponent implements OnInit {

     @Input() titulo = '\'\'';
  constructor() { }

  ngOnInit() {
  }

}
