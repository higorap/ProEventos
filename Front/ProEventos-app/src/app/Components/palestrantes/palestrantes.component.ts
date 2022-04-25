import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-palestrantes',
  templateUrl: './palestrantes.component.html',
  styleUrls: ['./palestrantes.component.scss']
})
export class PalestrantesComponent implements OnInit {

  public eventos : any  ;

  constructor(private http: HttpClient ) { }

  ngOnInit(): void {
    this.getEventos();
  }

  public getEventos():void{
    this.http.get('https://localhost:5001/api/eventos').subscribe(
      response=> this.eventos=response,
      error => console.log(error)
    );
  
  }
}
